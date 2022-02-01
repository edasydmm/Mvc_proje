﻿using System.ComponentModel.DataAnnotations;

namespace ItServiesApp.Models.Entities
{
    public class SubscriptionType: BaseEntity
    {
        [Required,StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Month { get; set; }
        public decimal Price { get; set; }
    }


}
