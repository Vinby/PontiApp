﻿using PontiApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.PlacePlace.Services.PlaceServices
{
    public interface IPlaceService
    {
        Task AddHostingPlace(PlaceHostRequestDTO newPlaceDTO);
        Task AddGusestingPlace(PlaceGuestRequestDTO currPlaceGuestDTO);
        Task UpdateHostingPlace(PlaceHostRequestDTO currPlaceHostDTO);
        Task UpdateGuestingPlace(PlaceReviewDTO placeReviewDTO);
        Task DeleteHostingPlace(int hostPlaceId);
        Task DeleteGuestingPlace(PlaceGuestRequestDTO currPlaceGuestDTO);
        Task<PlaceHostResponseDTO> GetDetailedHostingPlace(int placeId);
        Task<PlaceGuestResponseDTO> GetDetailedGuestingPlace(PlaceGuestRequestDTO placeGuest);
        Task<List<PlaceListingResponseDTO>> GetAllPlace();
        Task<List<PlaceListingResponseDTO>> GetSearchedPlaces(SearchBaseDTO searchBaseDTO);
        Task<List<PlaceListingResponseDTO>> GetAllHsotingPlace(int userHostId);
        Task<List<PlaceListingResponseDTO>> GetAllGuestingPlace(int userGuestId);
    }
}
