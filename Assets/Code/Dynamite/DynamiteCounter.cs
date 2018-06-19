namespace Code
{
    public class DynamiteCounter
    {
        private const int MaxDynamites = 6;

        public int DynamitesLeft { get; private set; }
        
        public void ResetDynamiteCounter()
        {
            DynamitesLeft = MaxDynamites;
        }
        
        public void SubtractDynamite()
        {
            if (DynamitesLeft <=0) return;
            DynamitesLeft -= 1;
        }
    }
}