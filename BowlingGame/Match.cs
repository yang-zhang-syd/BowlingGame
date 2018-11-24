using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingGame
{
    public class Match
    {
        private readonly List<Frame> _frames;
        private readonly int[] _scores;
        private readonly int _numOfPins;

        public Match(int numOfPins, int numOfFrames, bool autoPlay = true)
        {
            _numOfPins = numOfPins;
            _frames = new List<Frame>();
            _scores = new int[numOfFrames];

            for (int i = 0; i < numOfFrames; ++i)
            {
                _frames.Add(new Frame(numOfPins, i == numOfFrames - 1, autoPlay));
            }
        }

        public int Play()
        {
            int[] lastScore = null;

            for(int i = 0; i < _frames.Count; ++i)
            {
                Console.WriteLine($"Frame {i}: ");
                var frame = _frames[i];
                var result = frame.Play();
                Console.WriteLine($"Result {string.Join(",", result)}");
                Console.WriteLine();
                _scores[i] = result.Sum();
                adjustScore(i, lastScore, result);
                lastScore = result;
            }

            Console.WriteLine($"Scores: {string.Join(",", _scores)}");
            return _scores.Sum();
        }

        private void adjustScore(int idx, int[] lastScore, int[] playResult)
        {
            // first play
            if (lastScore == null)
            {
                return;
            }

            // the bowler got a strike last time
            if (lastScore.Length == 1 && lastScore[0] == _numOfPins)
            {
                _scores[idx - 1] += playResult.Take(2).Sum();
            }

            // the bowler got a spare last time
            else if (lastScore.Length == 2 && lastScore.Sum() == _numOfPins)
            {
                _scores[idx - 1] += playResult[0];
            }
            
            // handle last frame result
            if(playResult.Length == 3 && playResult.Count(_ => _ == _numOfPins) == 3)
            {
                _scores[idx] = 300;
            }
        }
    }
}
