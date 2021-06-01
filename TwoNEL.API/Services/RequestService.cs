﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwoNEL.API.Domain.Models;
using TwoNEL.API.Domain.Persistence.Repositories;
using TwoNEL.API.Domain.Services;
using TwoNEL.API.Domain.Services.Communications;

namespace TwoNEL.API.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository requestRepository;
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;

        public RequestService(IRequestRepository requestRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            this.requestRepository = requestRepository;
            this.unitOfWork = unitOfWork;
            this.userRepository = userRepository;
        }

        public async Task<RequestResponse> DeleteAsync(int userId, int requestId)
        {
            var existingRequest = await requestRepository.FindById(requestId);
            if (existingRequest == null)
                return new RequestResponse("Request not found");

            try
            {
                requestRepository.Remove(existingRequest);
                await unitOfWork.CompleteAsync();

                return new RequestResponse(existingRequest);
            }
            catch (Exception ex)
            {
                return new RequestResponse($"An error ocurred while deleting the request: {ex.Message}");
            }
        }

        public async Task<RequestResponse> GetByIdAsync(int userId, int requestId)
        {
            var existingRequest = await requestRepository.FindById(requestId);
            if (existingRequest == null)
                return new RequestResponse("Request not found");

            return new RequestResponse(existingRequest);
        }

        public async Task<IEnumerable<Request>> ListByUserIdAsync(int userId)
        {
            return await requestRepository.ListByUserIdAsync(userId);
        }

        public async Task<RequestResponse> SaveAsync(int userId, Request request)
        {
            var existingUser = await userRepository.FindById(userId);
            if (existingUser == null)
                return new RequestResponse("Profile not found");
            try
            {
                request.SenderId = userId;
                await requestRepository.AddAsync(request);
                await unitOfWork.CompleteAsync();

                return new RequestResponse(request);
            }
            catch (Exception ex)
            {
                return new RequestResponse($"An error ocurred while saving the request: {ex.Message}");
            }
        }

        public async Task<RequestResponse> UpdateAsync(int userId, int requestId, Request request)
        {
            var existingRequest = await requestRepository.FindById(requestId);

            if (existingRequest == null)
                return new RequestResponse("Request not found");

            existingRequest.Subject = request.Subject;

            try
            {
                requestRepository.Update(existingRequest);
                await unitOfWork.CompleteAsync();

                return new RequestResponse(existingRequest);
            }
            catch (Exception ex)
            {
                return new RequestResponse($"An error ocurred while updating the request: {ex.Message}");
            }
        }
    }
}
