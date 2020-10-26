using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace PigGame.Models
{
    public class Pig
    {
        //TODO setup a class that does everything for the game.
        public bool IsOver = false;
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        [TempData]
        public int TempScore { get; set; }
        [TempData]
        public string Message { get; set; }
        public string P1Name = "player 1";
        public string P2Name = "player 2";
        public string CurrentPlayerName { get; set; }
        public int LastRoll { get; set; }
        
        public void Roll()
        {
            Random rand = new Random();
            int roll = rand.Next(1, 7);
            if (roll == 1)
            {
                
                //Set TempScore = 0.
                TempScore = 0;
                //Message = TempScore.ToString;
                //End player turn
                SwitchPlayer();
            }
            else
            {
                //Add Roll to TempScore.
                roll += TempScore;
                //Set roll -> Last Roll.
                LastRoll = roll;

            }
        }

        public void Hold()
        {
            //Add TempScore to TotalScore
            if (Player1.TotalScore >= 20)
            {
                //Player1 Wins
                //document writeout (CurrentPlayer()) + " " + "wins!"
                //set game -> over
                IsOver = true;
                NewGame();
            }
            else if (Player2.TotalScore >= 20)
            {
                //Player2 Wins
                //output player2 wins
                IsOver = true;
                NewGame();
            }
            //Add TempScore to TotalScore
            else if (Player1.IsTurn && Player1.TotalScore < 20)
            {
                TempScore += Player1.TotalScore;
            }
            else if (Player2.IsTurn && Player2.TotalScore < 20)
            {
                TempScore += Player2.TotalScore;
            }
            //Set TempScore to 0 again.
            TempScore = 0;
            //Switch Player Turn
            SwitchPlayer();
        }

        public void NewGame()
        {
            //begins new session / game
            LastRoll = 0;
            TempScore = 0;
            Player1.TotalScore = 0;
            Player2.TotalScore = 0;
            //set player1 IsTurn = true
            Player1.IsTurn = true;
            //set player2 IsTurn = false
            Player2.IsTurn = false;
            //set IsOver to false to show game is no longer "over"
            IsOver = false;
        }

        public void SwitchPlayer()
        {
            //determine who current player is
            if (Player1.IsTurn)
            {
                Player2.IsTurn = true;
                Player1.IsTurn = false;
            }
            else
            {
                Player1.IsTurn = true;
                Player2.IsTurn = false;
            }
            TempScore = 0;
            LastRoll = 0;
        }

        public Player CurrentPlayer()
        {
            if (Player1.IsTurn)
            {
                CurrentPlayerName = P1Name;
                return Player1;
                //display current player
            }
            CurrentPlayerName = P2Name;
            return Player2;
        }
    }
}
 