﻿using DTOS.ImageTracking;
using Microsoft.AspNetCore.Http;

namespace DTOS.PlantTracking
{
    public class PlantTrackingCreate
    {
        public string PlantCodeID { get; set; }
        public string? ContentText { get; set; }
        public DateTime DateCreate { get; set; }
        public int Status { get; set; }

        public IEnumerable<IFormFile> PlantImageDetails { get; set; }
    }
}