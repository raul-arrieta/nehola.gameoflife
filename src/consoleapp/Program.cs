using nehola.gameoflife.Entities;
using nehola.gameoflife.Entities.Logger;
using System;


namespace nehola.gameoflife.consoleapp
{
    public class Program : IObserver<World>
    {
        private IDisposable Unsubscriber { get; set; }

        private LifeSimulation Simulation { get; set; }

        private IWorldLogger Logger { get; set; }
        public static void Main(string[] args)
        {
            var program = new Program {Simulation = new LifeSimulation(40, 100), Logger = new ConsoleWorldLogger()
        };
            program.Subscribe(program.Simulation);
            program.Simulation.Start(1);
        }

        public void Subscribe(IObservable<World> provider)
        {
            if (provider != null)
                Unsubscriber = provider.Subscribe(this);
        }
        public void OnCompleted()
        {
            Console.WriteLine("Completed.");
            Unsubscribe();
            Environment.Exit(0);
        }

        public void OnError(Exception error)
        {
            Console.WriteLine(String.Format("! Error: {0}", error.Message));
            Environment.Exit(-1);
        }

        public void OnNext(World world)
        {
            Console.Clear();
            world.Print(Logger);
        }

        public virtual void Unsubscribe()
        {
            Unsubscriber.Dispose();
        }
    }
}