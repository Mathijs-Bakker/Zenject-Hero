using System;
using System.ComponentModel;
using UnityEditor;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using Zenject;

namespace Code.FlipScreen
{
    public enum ScreenBoundary
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

        private float offsetY = 5f;
        private float offsetX = 13f;
        
        public void LogEnum(ScreenBoundary boundary)
        {
            switch (boundary)
            {
                  case  ScreenBoundary.Top:
                      if (Math.Abs(transform.position.y) < 0.1f) break;
                      transform.position = new Vector2(
                          transform.position.x,
                          transform.position.y + offsetY);
                      break;
                  
                  case ScreenBoundary.Bottom:
                      transform.position = new Vector2(
                          transform.position.x,
                          transform.position.y - offsetY);
                      break;
                  
                case ScreenBoundary.Left:
                    transform.position = new Vector2(
                        transform.position.x - offsetX,
                        transform.position.y);
                    break;
                
                case ScreenBoundary.Right:
                    transform.position = new Vector2(
                        transform.position.x + offsetX,
                        transform.position.y);
                    break;
                  
                  default:
                      throw new InvalidEnumArgumentException();
            }
        }

    }
}