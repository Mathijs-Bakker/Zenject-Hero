using UnityEngine;

namespace Code
{
    public class DynamiteCounter
    {
        private const int MaxDynamites = 6;

        public int DynamitesLeft { get; private set; }
        
        public void ResetDynamiteCounter()
        {
            DynamitesLeft = MaxDynamites;
            Debug.Log("ResetDynamiteCounter");
        }
        
        public void SubtractDynamite()
        {
            if (DynamitesLeft <=0) return;
            DynamitesLeft -= 1;
            Debug.Log("::: SubtractDynamite :::\n" +
                      "Dynamites Left: " + DynamitesLeft);
            
        }
    }
}