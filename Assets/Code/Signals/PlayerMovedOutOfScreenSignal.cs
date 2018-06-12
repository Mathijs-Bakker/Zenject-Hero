using Zenject;

namespace Code.FlipScreen
{
    public class PlayerMovedOutOfScreenSignal : ISignal
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