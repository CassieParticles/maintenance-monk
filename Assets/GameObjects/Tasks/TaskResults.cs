namespace GameObjects.Tasks
{
    public struct TaskResults
    {
        public TaskResults(float time = -1.0f, float score = -1.0f)
        {
            Time = time;
            Score = score;
        }

        public float Time;
        public float Score;
    }
}