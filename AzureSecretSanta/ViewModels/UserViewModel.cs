﻿namespace AzureSecretSanta.ViewModels
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string GiftDescription { get; set; }
        public int? SantaOf { get; set; }
    }
}