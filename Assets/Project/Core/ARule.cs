namespace AMGOLCore
{
    public abstract class ARule
    {
        public abstract bool WillSurvive(ATile tile);

        public abstract bool WillSurvive(bool is_alive, int alive_neighbors_count);
    }
}

