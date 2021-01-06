using Akka.Actor;
using Akka.Actor.Internal;
using IMS.BL.Actors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace IMS.API
{
    public class Program
    {
        private static ActorSystem actorSystem;
        public static void Main(string[] args)
        {
            actorSystem = ActorSystem.Create("Test");
            Props playbackprops = Props.Create<PlaybackActor>();
            IActorRef playbackRef = actorSystem.ActorOf(playbackprops, "FirstActor");
            playbackRef.Tell("AKKA.Net");
            
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
