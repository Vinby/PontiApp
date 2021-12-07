﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using PontiApp.Exceptions;
using PontiApp.Images.Services.Generic_Services;
using PontiApp.MessageSender;
using PontiApp.Models.DTOs;
using PontiApp.Models.Entities;
using PontiApp.Models.Request;
using PontiApp.Models.Response;
using PontiApp.PlacePlace.Services.PlaceServices;
using PontiApp.Ponti.Repository.PontiRepository;
using PontiApp.Validators.EntityValidators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.PlacePlace.Services.PlaceServices
{
    public class PlaceService : IPlaceService
    {
        private readonly IMongoService _mongoService;
        private readonly IMapper _mapper;
        private readonly PlaceDTOValidator _validator;
        private readonly PlaceRepository _placeRepo;
        private readonly MessagingService _msgService;


        public PlaceService(IMongoService mongoService, IMapper mapper, PlaceDTOValidator validator, PlaceRepository placeRepo, MessagingService msgService)
        {
            _mongoService = mongoService;
            _mapper = mapper;
            _validator = validator;
            _placeRepo = placeRepo;
            _msgService = msgService;
        }

        public async Task AddGusestingPlace(PlaceGuestRequestDTO currPlaceGuestDTO)
        {
            await _placeRepo.InsertGuesting(currPlaceGuestDTO);
        }

        public async Task AddHostingPlace(CompositeObj<PlaceHostRequestDTO, IFormFileCollection> placeFile)
        {
            var newPlaceDTO = placeFile.Entity;
            var files = placeFile.Files;
            var newPlace = _mapper.Map<PlaceEntity>(newPlaceDTO);
            var guid = Guid.NewGuid().ToString();
            await _msgService.SendAddMessage(guid, files);
            var existingPlace = _placeRepo.GetByPredicate(plc => plc.UserEntityId == newPlace.UserEntityId && plc.Name == newPlace.Name && plc.Address == newPlace.Address).SingleOrDefault();
            if (existingPlace != null)
                throw new AlreadyExistsException("This Place Is Already Registered!");
            await _placeRepo.Insert(newPlace);
        }

        public async Task DeleteGuestingPlace(PlaceGuestRequestDTO currPlaceGuestDTO)
        {
            await _placeRepo.DeleteGuesting(currPlaceGuestDTO);
        }

        public async Task DeleteHostingPlace(int hostPlaceId)
        {
            PlaceEntity currPlace = await _placeRepo.GetByID(hostPlaceId);
            if (currPlace == null)
                throw new DoesNotExistsException();
            await _placeRepo.Delete(currPlace);
        }

        public async Task<List<PlaceListingResponseDTO>> GetAllGuestingPlace(int userGuestId)
        {
            List<PlaceEntity> guestingPlaces = await _placeRepo.GetAllGuesting(userGuestId);

            if (guestingPlaces.Count == 0 || guestingPlaces == null)
                throw new DoesNotExistsException();

            List<PlaceListingResponseDTO> guestingPlaceDTOs = _mapper.Map<List<PlaceListingResponseDTO>>(guestingPlaces);

            return guestingPlaceDTOs;
        }

        public async Task<List<PlaceBriefResponse>> GetAllHsotingPlace(long hostFbId)
        {
            var hostingPlaces = await _placeRepo.GetAllHosting(hostFbId);
            var hostingPlacesResponse = _mapper.Map<List<PlaceBriefResponse>>(hostingPlaces);

            return hostingPlacesResponse;
        }

        public async Task<List<PlaceBriefResponse>> GetAllPlace()
        {
            var allPlace = await _placeRepo.GetAllPlaceAsync();
            if (allPlace == null || allPlace.Count() == 0)
                throw new DoesNotExistsException("No Place Exists!");

            var allPlaceDTOs = _mapper.Map<List<PlaceBriefResponse>>(allPlace);

            return allPlaceDTOs;
        }

        public async Task<PlaceDetailedResponse> GetDetailedPlace(int placeId)
        {
            var place = await _placeRepo.GetDetaildPlaceAsync(placeId);
            var doc = await _mongoService.GetImage(place.PicturesId);
            var picAmnt = doc.Count;
            var picList = Enumerable.Range(0, doc.Count).Select(s => $"https://localhost:44389/api/Image/{place.PicturesId}/{s}");
            var placeMap = _mapper.Map<PlaceDetailedResponse>(place);
            placeMap.Pictures = picList;
            return placeMap;
        }

        public async Task<List<PlaceListingResponseDTO>> GetSearchedPlaces(SearchFilter searchFilter)
        {
            var searchResult = await _placeRepo.GetPlaceSearchResult(searchFilter);

            if (searchResult.Count == 0 || searchResult == null)
                throw new DoesNotExistsException();

            var searchResultDto = _mapper.Map<List<PlaceListingResponseDTO>>(searchResult);
            foreach (var place in searchResultDto)
            {
                place.WeekSchedules = _mapper.Map<List<WeekEntity>, List<WeekScheduleDTO>>(searchResult.Select(place => place.WeekSchedule).FirstOrDefault());
            }
            return searchResultDto;
        }


        public async Task UpdateGuestingPlace(PlaceReviewDTO placeReviewDTO)
        {
            await _placeRepo.UpdateGuestingPlace(placeReviewDTO);
        }

        public async Task UpdateHostingPlace(PlaceHostRequestDTO currPlaceDTO)
        {
            PlaceEntity currPlace = _mapper.Map<PlaceEntity>(currPlaceDTO);
            await _placeRepo.Update(currPlace);
        }
        public async Task AddToHostingImages(int placeId, IFormFileCollection files)
        {
            var currPlace = await _placeRepo.GetByID(placeId);
            var mongoKey = currPlace.PicturesId;
            List<byte[]> imgList = new List<byte[]>();
            foreach (var img in files)
            {
                using (var str = new MemoryStream())
                {

                    img.CopyTo(str);
                    var byteArr = str.ToArray();
                    imgList.Add(byteArr);
                }
            }
            await _mongoService.UpdateImage(mongoKey, imgList);
        }
        public async Task RemoveFromHostingImages(int placeId, int[] indices)
        {
            var currPlace = await _placeRepo.GetByID(placeId);
            var mongoKey = currPlace.PicturesId;
            await _mongoService.UpdateImage(mongoKey, indices);
        }


    }
}
