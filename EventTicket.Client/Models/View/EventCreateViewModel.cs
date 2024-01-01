using EventTicket.Web.Models.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventTicket.Web.Models.View
{
    public class EventCreateViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public string Artist { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        public string CategoryName { get; set; }

        [Required]
        public string City { get; set; }

        public IEnumerable<Event> Events { get; set; }

        public IEnumerable<Category> CategoryList { get; set; }
    }
}
