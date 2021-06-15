﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TwoNEL.API.Resources
{
    public abstract class SaveProfileResource
    {
        [Required]
        public string MembershipType { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Url]
        public string Portfolio { get; set; }
        //public List<ProfileTag> ProfileTag { get; set; }
        //public List<Request> Requests { get; set; }
    }
}
