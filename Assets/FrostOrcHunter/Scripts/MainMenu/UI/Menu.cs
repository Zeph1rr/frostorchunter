using FrostOrcHunter.Scripts.Data;
using FrostOrcHunter.Scripts.GameRoot;
using TMPro;
using UnityEditor;
using UnityEngine;
using Zeph1rrGameBase.Scripts.Core.DI;
using Zeph1rrGameBase.Scripts.Core.SaveLoadSystem;
using Zeph1rrGameBase.Scripts.Core.Utils;

namespace FrostOrcHunter.Scripts.MainMenu.UI
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _playerNameInputField;
        [SerializeField] private GameObject _playerName;
        
        private PlayerPrefsSaveLoadSystem _saveLoadSystem;
        private GameData _gameData;
        
        public void Initialize(DIContainer container)
        {
            _saveLoadSystem = container.Resolve<PlayerPrefsSaveLoadSystem>();
            _gameData = container.Resolve<GameData>();
            
            _playerName.SetActive(false);
        }

        public void LoadGame()
        {
            var gameData = _saveLoadSystem.Load("hunter", new GameData());
            _gameData.UpdateGameData(gameData);
            StartGame();
        }
        
        public void NewGameButton()
        {
            _playerName.SetActive(true);
        }

        public void NewGame()
        {
            var playerName = _playerNameInputField.text;
            var gameData = new GameData(playerName);
            _gameData.UpdateGameData(gameData);
            StartGame();
        }
        
        public void QuitGame()
        {
            Application.Quit();
        }

        public void ReturnToMainMenu()
        {
            _playerName.SetActive(false);
        }

        private void StartGame()
        {
            Coroutines.StartRoutine(GameEntryPoint.Instance.LoadScene(Scenes.TRIBE));
        }
    }
}