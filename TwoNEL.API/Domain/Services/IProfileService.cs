﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwoNEL.API.Domain.Models;
using TwoNEL.API.Domain.Services.Communications;

namespace TwoNEL.API.Domain.Services
{
    public interface IProfileService
    {
        Task<IEnumerable<Profile>> ListAsync();
        Task<ProfileResponse> GetByIdAsync(int id);
        Task<ProfileResponse> SaveAsync(Profile profile);
        Task<ProfileResponse> UpdateAsync(int id, Profile profile);
    }
}
