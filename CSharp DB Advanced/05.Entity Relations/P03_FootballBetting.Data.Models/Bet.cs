using System;

namespace P03_FootballBetting.Data.Models
{
    public class Bet
    {
        public int BetId { get; set; }

        public decimal Amount { get; set; }

        public string Prediction { get; set; }

        public DateTime DateTime { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }


        //•	Bet – BetId, Amount, Prediction, DateTime, UserId, GameId  mapping
        //•	A Bet can be placed by only one User 
        //•	Many Bets can be placed on one Game, but a Bet can be only on one Game
        //•	Each bet for given game must have Prediction result     ???
    }
}
