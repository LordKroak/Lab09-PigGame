using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace PigGame.Models
{
    public class PigSession
    {
        //property of type ISession that holds our session
        //constructor needed to accept session
        private const string GameKey = "piggame";
        
        private ISession session { get; set; }
        public PigSession(ISession session)
        {
            //TODO accept parameter of type ISession and save to property
            this.session = session;
        }
        //Set a Game
        public void SetGame(Pig pig)
        {
            session.SetObject(GameKey, pig);
        }
        //GetGame
        public Pig GetGame() =>
            session.GetObject<Pig>(GameKey) ?? new Pig();

    }
}
