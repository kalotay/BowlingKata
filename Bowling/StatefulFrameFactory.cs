﻿namespace Bowling
{
    public class StatefulFrameFactory : IStatefulFactory<IScorer<int>, int> 
    {
        public bool CanGenerate { get; private set; }

        private int _sinceLastGen;
        private int _frameCount;

        public StatefulFrameFactory()
        {
            _sinceLastGen = 0;
            _frameCount = 0;
            CanGenerate = true;
        }

        public IScorer<int> GetInstance()
        {
            _sinceLastGen = 0;
            _frameCount += 1;
            return new Frame();
        }

        public void Register(int roll)
        {
            _sinceLastGen += 1;
            CanGenerate = (_frameCount == 0) || ((_frameCount < 10) && (roll == 10 || (_sinceLastGen == 2)));
        }
    }
}