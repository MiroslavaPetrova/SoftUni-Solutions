using System;
using System.Collections.Generic;

namespace P03_FootballBetting.Data.Models
{
    public class Game
    {
        public int GameId { get; set; }

        public DateTime DateTime { get; set; }

        public int HomeTeamId { get; set; }  
        public Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }  
        public Team AwayTeam { get; set; }

        public int HomeTeamGoals { get; set; }  

        public int AwayTeamGoals { get; set; }  

        public decimal HomeTeamBetRate { get; set; }  // data type?

        public decimal AwayTeamBetRate { get; set; }

        public decimal DrawBetRate { get; set; }

        public string Result { get; set; }

        public ICollection<Bet> Bets{ get; set; }

        public ICollection<PlayerStatistic> PlayerStatistics { get; set; }

        //•	Game – GameId, HomeTeamId, AwayTeamId, HomeTeamGoals, AwayTeamGoals, DateTime,
        //.        HomeTeamBetRate, AwayTeamBetRate, DrawBetRate, Result)

        //•	Many Bets can be placed on one Game, but a Bet can be only on one Game
        //•	in each Game, many Players take part (PlayerStatistics)
        //•	A Game has one HomeTeam and one AwayTeam 

    }
}
