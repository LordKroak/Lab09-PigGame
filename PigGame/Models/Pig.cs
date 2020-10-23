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
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public int TempScore { get; set; }
        public void Roll()
        {
            Random rand = new Random();
            int roll = rand.Next(1, 7);
            if (roll == 1)
            {
                
                //Set TempScore = 0.
                TempScore = 0;
                //End player turn
                SwitchPlayer();
            }
            else
            {
                //Add Roll to TempScore.
                roll += TempScore;

            }
        }

        public void Hold()
        {
            //Add TempScore to TotalScore
            if (Player1.TotalScore >= 20)
            {
                //Player1 Wins
                //document writeout (CurrentPlayer()) + " " + "wins!"
                NewGame();
            }
            else if (Player2.TotalScore >= 20)
            {
                //Player2 Wins
                //output player2 wins
                NewGame();
            }
            //Add TempScore to TotalScore
            else if (Player1.IsTurn && Player1.TotalScore < 20)
            {
                TempScore += Player1.TotalScore;
            }
            if (Player2.IsTurn && Player2.TotalScore < 20)
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
            //ends current session
            //begins new session / game
            //set player1 IsTurn = true
            Player1.IsTurn = true;
            //set player2 IsTurn = false
            Player2.IsTurn = false;
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
        }

        public void CurrentPlayer()
        {
            if (Player1.IsTurn)
            {
                Player1 = CurrentPlayer;
                //display current player
            }
            else
            {
                Player2 = CurrentPlayer;
                //display current player
            }
        }
    }
}
 