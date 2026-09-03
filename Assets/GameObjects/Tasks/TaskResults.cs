namespace GameObjects.Tasks
{
    public struct TaskResults
    {
        public TaskResults(float time = -1.0f, float score = -1.0f, int coinsEarned = -1, float repEarned = -1.0f)
        {
            Time = time;
            Score = score;
            
            CoinsEarned = coinsEarned;
            RepEarned = repEarned;
        }

        public float Time;
        public float Score;

        public int CoinsEarned;
        public float RepEarned;
    }
}