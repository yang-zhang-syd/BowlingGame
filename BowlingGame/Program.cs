using System;

namespace BowlingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of frames: ");
            int numOfFrames = int.Parse(Console.ReadLine());
            Console.WriteLine("Enable auto play? (Enter true or false.)");
            bool autoPlay = bool.Parse(Console.ReadLine());

            var bowlingGame = new BowlingGame(numOfFrames, autoPlay);
            bowlingGame.roll(10);
            var result = bowlingGame.score();
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
