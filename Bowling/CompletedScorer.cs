namespace Bowling
{
    public class CompletedScorer<T>: IScorer<T>
    {
        private readonly int _score;

        public CompletedScorer(int score)
        {
            _score = score;
        }

        public int Score
        {
            get { return _score; }
        }

        public IScorer<T> Register(T move)
        {
            return this;
        }

        public bool IsComplete
        {
            get { return true; }
        }
    }
}