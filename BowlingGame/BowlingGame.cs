using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame
{
    public class BowlingGame
    {
        private readonly int _numOfFrames;
        private readonly bool _autoPlay;
        private int _score;

        public BowlingGame(int numOfFrames, bool autoPlay)
        {
            _numOfFrames = numOfFrames;
            _autoPlay = autoPlay;
        }

        public void roll(int numOfPins)
        {
            var match = new Match(numOfPins, _numOfFrames, _autoPlay);
            _score = match.Play();
        }

        public int score()
        {
            return _score;
        }
    }
}
