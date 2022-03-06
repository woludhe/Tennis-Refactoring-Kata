using System;
using System.Collections.Generic;

namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int p1point = 0;
        private int p2point;
        public int SetP1Score
        {
            set { p1point += value; }  
        }

        public int SetP2Score
        {
            set { p2point += value; }
        }
        
        private string player1Name;
        private string player2Name;

        public TennisGame2(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public string GetScore()
        {
            var score = "";
            string p1res = "";
            string p2res = "";

            Dictionary<int, string> scorePoints = new Dictionary<int, string>();
            scorePoints.Add(0, "Love");
            scorePoints.Add(1, "Fifteen");
            scorePoints.Add(2, "Thirty");
            scorePoints.Add(3, "Forty");
            scorePoints.Add(4, "Game");

            if (p1point == p2point && p1point < 3)
            {
                scorePoints.TryGetValue(p1point, out score);
                score += "-All";
            }

            if (p1point == p2point && p1point > 2)
                score = "Deuce";

            if (p1point > 0 && p2point == 0)
            {
                scorePoints.TryGetValue(p1point, out p1res);
                p2res = "Love";
                score = p1res + "-" + p2res;
            }
            if (p2point > 0 && p1point == 0)
            {
                scorePoints.TryGetValue(p2point, out p2res);
                p1res = "Love";
                score = p1res + "-" + p2res;
            }

            if (p1point > p2point && p1point < 4)
            {
                if (p1point == 2 || p1point == 3)
                    scorePoints.TryGetValue(p1point, out p1res);

                if (p2point == 1 || p2point == 2)
                    scorePoints.TryGetValue(p2point, out p2res);
                score = p1res + "-" + p2res;
            }
            if (p2point > p1point && p2point < 4)
            {
                if (p2point == 2 || p2point == 3)
                    scorePoints.TryGetValue(p2point, out p2res);

                if (p1point == 1 || p1point == 2)
                    scorePoints.TryGetValue(p1point, out p1res);
                score = p1res + "-" + p2res;
            }

            if (p1point > p2point && p2point >= 3)
            {
                score = "Advantage player1";
            }

            if (p2point > p1point && p1point >= 3)
            {
                score = "Advantage player2";
            }

            if (p1point >= 4 && p2point >= 0 && (p1point - p2point) >= 2)
            {
                score = "Win for player1";
            }
            if (p2point >= 4 && p1point >= 0 && (p2point - p1point) >= 2)
            {
                score = "Win for player2";
            }
            return score;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                SetP1Score = 1;
            else if (player == "player2")
                SetP2Score = 1;
        }
    }
}

