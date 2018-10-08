using Code;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace UI.Start_Game_Btn.Code
{
    public class StartGameButton : MonoBehaviour
    {
        private Button _startGameBtn;

        private void Start()
        {
            _startGameBtn = GetComponent<Button>();
            _startGameBtn.onClick.AddListener(StartGame);
        }

        private void StartGame()
        {
            SceneManager.LoadScene(1);
        }
    }
}