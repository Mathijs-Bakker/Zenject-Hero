using System;
using System.ComponentModel;
using UnityEditor;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using Zenject;

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
        public void Start()
        {
            ResetScreen();
        }

        private void ResetScreen()
        {
            transform.position = new Vector2(0, 0);
        }

        private const float OffsetY = 5f;
        private const float OffsetX = 14f;

        public void FlipScreen(ScreenBorder borderPosition)
        {
            switch (borderPosition)
            {
                  case  ScreenBorder.Top:
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
            }
        }
    }
}