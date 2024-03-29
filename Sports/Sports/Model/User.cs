﻿using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Sports.Model
{
    public enum Role
    {
        Coach = 1,
        Captain = 2,
        Player = 3
    };
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int UserId { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        //[Required]
        //[MinLength(8), MaxLength(14)]
        //public string Password{ get; set; }
        [JsonIgnore]
        [Column("Password")]
        public string Password { get; set; }

        public int? TotalMatchesPlayed { get; set; }
        [Required]
        [Phone]
        public string ContactNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public virtual Role role { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
        public bool isMember { get; set; } = false;

    }
}
