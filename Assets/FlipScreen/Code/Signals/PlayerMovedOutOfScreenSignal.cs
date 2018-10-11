namespace FlipScreen.Code.Signals
{
    public class PlayerMovedOutOfScreenSignal
    {
        public PlayerMovedOutOfScreenSignal(ScreenBorder borderPosition)
        {
            BorderPosition = borderPosition;
        }

        public ScreenBorder BorderPosition { get; }
    }
}