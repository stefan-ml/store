﻿using System;
using System.ComponentModel.DataAnnotations;

namespace EventTicket.Web.Models.Api
{
    public class BasketForCreation
    {
        [Required]
        public Guid UserId { get; set; }
    }
}
