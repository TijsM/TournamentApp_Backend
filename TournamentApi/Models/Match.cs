﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentApi.Models
{
    public class Match
    {
        #region Fields
        int _amountOfGamesWonPlayer1 = 0;
        #endregion

        #region Properties
        public int MatchId { get; set; }
        public User Player1 { get; set; }
        public User Player2 { get; set; }
        public IEnumerable<UserMatch> UserMatches { get; set; }
        public int GamesWonPlayer1Set1 { get; set; }
        public int GamesWonPlayer1Set2 { get; set; }
        public int GamesWonPlayer1Set3 { get; set; }
        public int GamesWonPlayer2Set1 { get; set; }
        public int GamesWonPlayer2Set2 { get; set; }
        public int GamesWonPlayer2Set3 { get; set; }
        public bool Player1Won { get; set; }
        public bool Player2Won { get; set; }

        #endregion

        public Match(User player1, User player2)
        {
            Player1 = player1;
            Player2 = player2;
            Player1Won = false;
            Player2Won = false;
            
        }

        public Match()
        {

        }


        public void RegisterScore(int gp1s1, int gp1s2, int gp1s3, int gp2s1, int gp2s2 = 0, int gp2s3 = 0)
        {
            GamesWonPlayer1Set1 = gp1s1;
            GamesWonPlayer1Set2 = gp1s2;
            GamesWonPlayer1Set3 = gp1s3;

            GamesWonPlayer2Set1 = gp2s1;
            GamesWonPlayer2Set2 = gp2s2;
            GamesWonPlayer2Set3 = gp2s3;

            if (gp1s1 > gp2s1)
                _amountOfGamesWonPlayer1++;

            if (gp1s2 > gp2s2)
                _amountOfGamesWonPlayer1++;

            if (gp1s3 > gp2s3)
                _amountOfGamesWonPlayer1++;

            CalculateWinner();
        }

        private void CalculateWinner()
        {
            if (_amountOfGamesWonPlayer1 >= 2)
            {
                Player1Won = true;
            }
            else
            {
                Player2Won = true;
            }
        }

    }
}
