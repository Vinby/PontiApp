﻿using System;
using System.Collections.Generic;
using System.Linq;
using RabbitMQ.Client;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Http;
using PontiApp.Utilities;

namespace PontiApp.MessageSender
{
    public class MessagingService
    {
        private IConfiguration _config;

        private readonly Utilities.RabbitMQ _rabbitConf;

        private readonly ConnectionFactory _factory;
        //private readonly ILogger<MessagingService> _logger;
        public IConnection Conn { get; set; }
        public IModel Channel { get; set; }
        public MessagingService(ConnectionFactory factory,Utilities.RabbitMQ rabbitConf)
        {

            _rabbitConf = rabbitConf ;
            _factory = factory;
            File.WriteAllText("./loggers.txt", $"{_rabbitConf.HostName} {_rabbitConf.Port}");
            _factory.HostName = _rabbitConf.HostName;
            _factory.UserName = _rabbitConf.UserName;
            _factory.Password = _rabbitConf.PassWord;
            _factory.VirtualHost = _rabbitConf.VirtualHost;
            _factory.Port = _rabbitConf.Port;
            Conn = factory.CreateConnection();
            Channel = Conn.CreateModel();
        }
        public async Task SendUpdateMessage(string guid, IFormFileCollection files)
        {
            var BytesList = await files.GetBytes();
            var dict = new Dictionary<string, object>();
            dict.Add(RabbitMQConsts.GUID, guid);
            dict.Add(RabbitMQConsts.LIST, BytesList);
            var body = dict.GetJsonBytes();
            Channel.BasicPublish(RabbitMQConsts.EXCHANGE, RabbitMQConsts.UPDATE_ADD_Q, null, body);
            // _logger.LogInformation($"Message sent to {RabbitMQConsts.UPDATE_ADD_Q} at {DateTime.Now}");
        }

        public void SendUpdateMessage(string guid, int[] indices)
        {
            var dict = new Dictionary<string, object>();
            dict.Add(RabbitMQConsts.GUID, guid);
            dict.Add(RabbitMQConsts.INDICES, indices);
            var body = dict.GetJsonBytes();
            Channel.BasicPublish(RabbitMQConsts.EXCHANGE, RabbitMQConsts.UPDATE_REMOVE_Q, null, body);
            //_logger.LogInformation($"Message sent to {RabbitMQConsts.UPDATE_REMOVE_Q} at {DateTime.Now}");
        }
        public async Task SendAddMessage(string guid, IFormFileCollection files)
        {
            var BytesList = await files.GetBytes();
            var dict = new Dictionary<string, object>();
            dict.Add(RabbitMQConsts.GUID, guid);
            dict.Add(RabbitMQConsts.LIST, BytesList);
            var body = dict.GetJsonBytes();
            Channel.BasicPublish(RabbitMQConsts.EXCHANGE, RabbitMQConsts.ADD_Q, null, body);
            //_logger.LogInformation($"Message sent to {RabbitMQConsts.ADD_Q} at {DateTime.Now}");
        }
        public void SendDeleteMessage(string guid)
        {
            var dict = new Dictionary<string, string>();
            dict.Add(RabbitMQConsts.GUID, guid);
            var body = dict.GetJsonBytes();
            Channel.BasicPublish(RabbitMQConsts.EXCHANGE, RabbitMQConsts.DELETE_Q, null, body);
            //logger.LogInformation($"Message sent to {RabbitMQConsts.DELETE_Q} at {DateTime.Now}");
        }

        public async Task SendAddMessage(string guid, string url)
        {
            try
            {
                var client = new HttpClient();
                var image = await client.GetByteArrayAsync(url);
                var list = new List<byte[]>()
                {
                    image
                };
                var dict = new Dictionary<string, object>();
                dict.Add(RabbitMQConsts.GUID, guid);
                dict.Add(RabbitMQConsts.LIST, list);
                var body = dict.GetJsonBytes();
                Channel.BasicPublish(RabbitMQConsts.EXCHANGE, RabbitMQConsts.ADD_Q, null, body);
            }
            catch
            {
                string[] str = new string[2];
                str[0] = url;
                str[1] = $"{DateTime.Now}";
                var file = "./Logs.txt";
                File.WriteAllLines(file,str);
            }
        }


    }
}
