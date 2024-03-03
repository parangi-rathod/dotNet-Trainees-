﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPatternSports.Repository.Models
{
    public static class Team
    {
        public static List<User> Players { get; set; }
        public static List<User> FinalTeam { get; } = new List<User>();
        static Team()
        {
            Players = new List<User>();
            FinalTeam = new List<User>();
        }
    }
}