﻿using System.Collections.Generic;

namespace P03_FootballBetting.Data.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public decimal Balance { get; set; }

        public ICollection<Bet> Bets { get; set; }

        //•	User – UserId, Username, Password, Email, Name, Balance
        //• one User and one User can place many Bets
    }
}
