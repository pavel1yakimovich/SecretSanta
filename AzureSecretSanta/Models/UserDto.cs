﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureSecretSanta.Models
{
    [Table("Users")]
    public class UserDto
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string GiftDescription { get; set; }
        public UserDto SantaOf { get; set; }
    }
}