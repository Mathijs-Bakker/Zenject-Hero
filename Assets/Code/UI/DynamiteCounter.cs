namespace Code
{
    public class DynamiteCounter
    {
        private const int MaxDynamites = 6;

        private int _dynamitesLeft;

        private void ResetDynamiteCounter()
        {
            _dynamitesLeft = MaxDynamites;
        }
        
        private void RemoveDynamite()
        {
            if (_dynamitesLeft <=0) return;
            _dynamitesLeft -= 1;
        }
    }
}