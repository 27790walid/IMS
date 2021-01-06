using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.BL.Actors
{
    public class PlaybackActor : UntypedActor
    {
        string message = string.Empty;
        public PlaybackActor()
        {
            //message ="";
        }
        protected override void OnReceive(object message)
        {
            if (message is string)
            {
                Console.WriteLine(" string message :" + message);
            }
            else
                Unhandled(message);
            this.message = message.ToString();
        }
    }
}
