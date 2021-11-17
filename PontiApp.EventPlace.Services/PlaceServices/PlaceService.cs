﻿using AutoMapper;
using PontiApp.Models.DTOs;
using PontiApp.Models.Entities;
using PontiApp.Models.Request;
using PontiApp.PlacePlace.Services.PlaceServices;
using PontiApp.Ponti.Repository.PontiRepository;
using PontiApp.Validators.EntityValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.PlacePlace.Services.PlaceServices
{
    public class PlaceService : IPlaceService
    {

        private readonly IMapper _mapper;
        private readonly PlaceDTOValidator _validator;
        private readonly PlaceRepository _placeRepo;

        public PlaceService(IMapper mapper, PlaceDTOValidator validator, PlaceRepository placeRepo)
        {
            _mapper = mapper;
            _validator = validator;
            _placeRepo = placeRepo;
        }

        public async Task AddGusestingPlace(PlaceGuestRequestDTO currPlaceGuestDTO)
        {
            await _placeRepo.InsertGuesting(currPlaceGuestDTO);
        }

        public async Task AddHostingPlace(PlaceRequest newPlaceDTO)
        {
            var newPlace = _mapper.Map<PlaceEntity>(newPlaceDTO);

            await _placeRepo.Insert(newPlace);
        }


        public async Task DeleteGuestingPlace(PlaceGuestRequestDTO currPlaceGuestDTO)
        {
            await _placeRepo.DeleteGuesting(currPlaceGuestDTO);
        }

        public async Task DeleteHostingPlace(int hostPlaceId)
        {
            PlaceEntity currPlace = await _placeRepo.GetByID(hostPlaceId);
            await _placeRepo.Delete(currPlace);
        }

        public async Task<List<PlaceListingResponseDTO>> GetAllGuestingPlace(int userGuestId)
        {
            List<PlaceEntity> guestingPlaces = await _placeRepo.GetAllGuesting(userGuestId);
            List<PlaceListingResponseDTO> guestingPlaceDTOs = _mapper.Map<List<PlaceListingResponseDTO>>(guestingPlaces);

            return guestingPlaceDTOs;
        }

        public async Task<List<PlaceListingResponseDTO>> GetAllHsotingPlace(long hostFbId)
        {
            var hostingPlaces = await _placeRepo.GetAllHosting(hostFbId);
            var hostingPlacesResponse = _mapper.Map<List<PlaceListingResponseDTO>>(hostingPlaces);

            return hostingPlacesResponse;
        }

        public async Task<List<PlaceListingResponseDTO>> GetAllPlace()
        {
            List<PlaceEntity> allPlace = await _placeRepo.GetAll();
            List<PlaceListingResponseDTO> allPlaceDTOs = _mapper.Map<List<PlaceListingResponseDTO>>(allPlace);

            return allPlaceDTOs;
        }

        public async Task<List<PlaceListingResponseDTO>> GetSearchedPlaces(SearchFilter searchFilter)
        {
            var searchResult = await _placeRepo.GetPlaceSearchResult(searchFilter);


            var searchResultDto = _mapper.Map<List<PlaceListingResponseDTO>>(searchResult);
            foreach(var place in searchResultDto)
            {
                place.WeekSchedules = _mapper.Map<List<WeekEntity>, List<WeekScheduleDTO>>(searchResult.Select(place => place.WeekSchedule).FirstOrDefault());
            }
            return searchResultDto;
        }

        public async Task<PlaceHostResponseDTO> GetDetailedHostingPlace(int placeId)
        {
            PlaceEntity currPlace = await _placeRepo.GetByID(placeId);
            return _mapper.Map<PlaceHostResponseDTO>(currPlace);
        }

        
        public async Task<PlaceGuestResponseDTO> GetDetailedGuestingPlace(PlaceGuestRequestDTO placeGuest)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateGuestingPlace(PlaceReviewDTO placeReviewDTO)
        {
            await _placeRepo.UpdateGuestingPlace(placeReviewDTO);
        }

        public async Task UpdateHostingPlace(PlaceHostRequestDTO currPlaceDTO)
        {
            PlaceEntity currPlace =  _mapper.Map<PlaceEntity>(currPlaceDTO);
            await _placeRepo.Update(currPlace);
        }
    }
}
