using System;
using UnityEngine;

namespace Code.FlipScreen
{
    public enum ScreenBorder
    {
        Left,
        Right,
        Top,
        Bottom
    }

    public class FlipScreenManager : MonoBehaviour
    {
        private const float OffsetY = 6f;
        private const float OffsetX = 14f;

        public void Start()
        {
            ResetPosition();
        }

        private void ResetPosition()
        {
            transform.position = new Vector2(0, 0);
        }

        public void FlipScreen(ScreenBorder borderPosition)
        {
            switch (borderPosition)
            {
                case ScreenBorder.Top:
                    if (Math.Abs(transform.position.y) < 0.1f) break;
                    transform.position = new Vector2(
                        transform.position.x,
                        transform.position.y + OffsetY);
                    break;

                case ScreenBorder.Bottom:
                    transform.position = new Vector2(
                        transform.position.x,
                        transform.position.y - OffsetY);
                    break;

                case ScreenBorder.Left:
                    transform.position = new Vector2(
                        transform.position.x - OffsetX,
                        transform.position.y);
                    break;

                case ScreenBorder.Right:
                    transform.position = new Vector2(
                        transform.position.x + OffsetX,
                        transform.position.y);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(borderPosition), borderPosition, null);
            }
        }
    }
}