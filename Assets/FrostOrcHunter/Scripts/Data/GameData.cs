using System;
using FrostOrcHunter.Scripts.Data.Enums;
using FrostOrcHunter.Scripts.Data.Resource;
using UnityEngine;

namespace FrostOrcHunter.Scripts.Data
{
    [Serializable]
    public class GameData
    {
        public int MaxWaveNumber => _maxWaveNumber;
        public string PlayerName => _playerName;
        public ResourceStorage ResourceStorage => _resourceStorage;
        public HuntData HuntData => _huntData;
        public bool IsDead => _isDead;
        public bool IsLeaved => _isLeaved;
        
        [SerializeField] private int _maxWaveNumber;
        [SerializeField] private string _playerName;
        [SerializeField] private ResourceStorage _resourceStorage;
        
        private HuntData _huntData;
        private bool _isDead;
        private bool _isLeaved;
        public GameData()
        {
            //_playerStats = new();
            _maxWaveNumber = 1;
            _playerName = "hunter";
            _resourceStorage = new ResourceStorage(Enum.GetNames(typeof(ResourceType)));
            _huntData = new HuntData();
            _isDead = false;
            _isLeaved = false;
        }

        public GameData(/*PlayerStats playerStats, */int maxWaveNumber, int currentWaveNumber, string playerName, ResourceStorage resourceStorage)
        {
            //_playerStats = playerStats;
            _maxWaveNumber = maxWaveNumber;
            _playerName = playerName;
            _resourceStorage = resourceStorage;
            _huntData = new HuntData();
            _isDead = false;
            _isLeaved = false;
        }

        public GameData(GameData gameData)
        {
            UpdateGameData(gameData);
        }

        public GameData(string playerName)
        {
            //_playerStats = new();
            _maxWaveNumber = 1;
            _playerName = playerName;
            _resourceStorage = new(Enum.GetNames(typeof(ResourceType)));
            _huntData = new HuntData();
            _isDead = false;
            _isLeaved = false;
        }
        
        public void UpdateGameData(GameData gameData)
        {
            //_playerStats = gameData.PlayerStats;
            _maxWaveNumber = gameData.MaxWaveNumber;
            _playerName = gameData.PlayerName;
            _resourceStorage = gameData.ResourceStorage;
            _huntData = gameData.HuntData;
            _isDead = gameData.IsDead;
            _isLeaved = gameData.IsLeaved;
        }

        public void IncreaseWaveNumber()
        {
            _huntData.IncreaseWaveNumber();
            if (_huntData.CurrentWaveNumber > _maxWaveNumber) _maxWaveNumber = _huntData.CurrentWaveNumber;
        }

        public void ResetWaveNumber()
        {
            _huntData.ResetWaveNumber();
        }

        public void Leave()
        {
            _isLeaved = true;
        }

        public void Die()
        {
            _isDead = true;
        }

        public void ResetPlayerConditions()
        {
            _isLeaved = false;
            _isDead = false;
        }
    }
}