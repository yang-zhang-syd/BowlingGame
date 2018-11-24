using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame
{
    public class Frame
    {
        private readonly int _numOfPins;
        private readonly bool _lastFrame;
        private readonly bool _autoPlay;

        public Frame(int numOfPins, bool lastFrame = false, bool autoPlay = true)
        {
            _numOfPins = numOfPins;
            _lastFrame = lastFrame;
            _autoPlay = autoPlay;
        }

        public int[] Play()
        {
            if (_lastFrame)
            {
                return lastFramePlay();
            }

            return normalFramePlay();
        }

        private int[] normalFramePlay()
        {
            var first = bowl(_numOfPins);
            if (first == _numOfPins)
            {
                return new[] { first };
            }

            var second = bowl(_numOfPins - first);
            return new[] { first, second };
        }

        private int[] lastFramePlay()
        {
            var first = bowl(_numOfPins);
            if (first == _numOfPins)
            {
                var strike1 = bowl(_numOfPins);
                var strike2 = bowl(_numOfPins);

                return new[] {first, strike1, strike2};
            }

            var second = bowl(_numOfPins - first);
            if (first + second == _numOfPins)
            {
                var spare = bowl(_numOfPins);
                return new[] { first, second, spare };
            }

            return new[] {first, second};
        }

        private int bowl(int pinsRemaining)
        {
            int result;
            if (_autoPlay)
            {
                var rand = new Random();
                result = rand.Next(0, pinsRemaining);
            }
            else
            {
                Console.WriteLine($"Pins remaining {pinsRemaining}, enter bowl result: ");
                result = int.Parse(Console.ReadLine());
                while (result > pinsRemaining)
                {
                    Console.WriteLine($"Result cannot be greater than Pins remaining {pinsRemaining}. Enter again: ");
                    result = int.Parse(Console.ReadLine());
                }
            }
            
            Console.WriteLine($"Bowling remaining {pinsRemaining} hit {result}.");
            return result;
        }
    }
}
