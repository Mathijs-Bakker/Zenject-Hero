namespace Code.FlipScreen
{
    public class PlayerMovedOutOfScreenSignal
    {
        public PlayerMovedOutOfScreenSignal(ScreenBorder borderPosition)
        {
            BorderPosition = borderPosition;
        }

        public ScreenBorder BorderPosition
        {
            get; private set;
        }
    }
}