﻿namespace CarShop.Models.Issues
{
    public class CreateCarFormModel
    {
        public string Model { get; set; }

        public int Year { get; set; }

        public string Image { get; set; }

        public string PlateNumber { get; set; }

        public string OwnerId { get; set; }
    }
}
