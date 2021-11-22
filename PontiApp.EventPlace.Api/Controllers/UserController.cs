﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PontiApp.AuthService;
using PontiApp.EventPlace.Services.UserServices;
using PontiApp.GraphAPICalls;
using PontiApp.MessageSender;
using PontiApp.Models.DTOs;
using PontiApp.Models.Request;
using PontiApp.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontiApp.EventPlace.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly MessagingService _service;
        private readonly IJwtProcessor _jwtProcessor;
        private readonly IFbClient _fbClient;

        public UserController(IUserService userService, MessagingService service, IJwtProcessor jwtProcessor, IFbClient fbClient)
        {
            _service = service;
            _userService = userService;
            _jwtProcessor = jwtProcessor;
            _fbClient = fbClient;
        }

        [HttpPut]
        [Route(nameof(UpdateUser))]
        public async Task<ActionResult> UpdateUser([FromBody] UserRequest userRequest)
        {

            await _userService.Update(userRequest);
            return Ok();

        }

        [HttpDelete]
        [Route(nameof(DeleteUser))]
        public async Task<ActionResult> DeleteUser(long fbId)
        {

            await _userService.Delete(fbId);
            return Ok();

        }

        [HttpGet(nameof(GetUser))]
        public async Task<ActionResult<UserResponse>> GetUser(long FbId)
        {

            return Ok(await _userService.Get(FbId));

        }


        //[Authorize]
        //[HttpGet("GetAllUser")]
        //public async Task<ActionResult<IEnumerable<UserResponse>>> GetAllUser()
        //{
        //    try
        //    {                       
        //        return Ok(await _userService.GetAllUser());
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }
        //}

        [HttpPost]
        [AllowAnonymous]
        [Route(nameof(CreateUser))]
        public async Task<ActionResult> CreateUser(long fbkey, string accessToken)
        {
            var result = await _userService.AddUser(fbkey, accessToken);
            return Ok(result);
        }

        //[HttpGet]
        //[Route("Test")]
        //public ActionResult Test(string guid)
        //{
        //    _userService.DeleteImage(guid);
        //    return Ok();
        //}


        [HttpPost]
        [Route("UploadImages")]
        public async Task<ActionResult> Upload(long fbId, IFormFileCollection files)
        {
            var user = _userService.GetUser(fbId);
            await _service.SendUpdateMessage(user.MongoKey, files);
            return Ok();
        }
    }
}
