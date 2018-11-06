﻿using System;
using SQLite;
using System.Collections.Generic;
using System.Text;

namespace CocktailApp.Models
{
    class User
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public DateTime DayOfBirth { get; set; }

    }
}
