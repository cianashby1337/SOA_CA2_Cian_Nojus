﻿namespace SOA_CA2_Cian_Nojus.Models
{
    // Platform model
    public class Platform
    {
        public int Id { get; set; } // Primary Key
        public string name { get; set; }
        public string manufacturer { get; set; }

        public ICollection<GamePlatform> GamePlatforms { get; } = []; // Navigation Property
    }
}
