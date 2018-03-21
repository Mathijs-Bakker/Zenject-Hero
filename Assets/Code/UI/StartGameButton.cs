using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code
{
    public class StartGameButton : MonoBehaviour
    {
        [Inject] private GameManager _gameManager;

        private Button _startGameBtn;

        private void Start()
        {
            _startGameBtn = GetComponent<Button>();
            _startGameBtn.onClick.AddListener(StartGame);
        }

        private void StartGame()
        {
            _gameManager.ChangeState(GameState.Play);
        }
    }
}
