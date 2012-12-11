namespace Bowling
{
    public class StatefulFrameFactory
    {
        public bool IsFrameToBeGenerated { get; private set; }

        private int _sinceLastGen;
        private int _frameCount;

        public StatefulFrameFactory()
        {
            _sinceLastGen = 0;
            _frameCount = 0;
            IsFrameToBeGenerated = true;
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
            IsFrameToBeGenerated = (_frameCount == 0) || ((_frameCount < 10) && (roll == 10 || (_sinceLastGen == 2)));
        }
    }
}