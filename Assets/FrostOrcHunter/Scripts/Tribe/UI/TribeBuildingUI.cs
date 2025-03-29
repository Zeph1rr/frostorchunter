using System;
using System.Collections.Generic;
using FrostOrcHunter.Scripts.Data;
using FrostOrcHunter.Scripts.Data.Enums;
using FrostOrcHunter.Scripts.Data.Stats;
using FrostOrcHunter.Scripts.GameRoot.Localization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FrostOrcHunter.Scripts.Tribe.UI
{
    public class TribeBuildingUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _label;
        [SerializeField] private Button _applyButton;
        
        [SerializeField] private List<UpgradeButton> _upgradeButtons;
        
        private string _buildingName;
        private GameData _gameData;
        
        private readonly Dictionary<string, StatNames[]> _hutToStats = new()
        {
            {CampBuildings.PriestHut.ToString(), new StatNames[] { StatNames.MaxHealth, StatNames.CritChance }},
            {CampBuildings.ChiefHut.ToString(), new StatNames[] { StatNames.Damage, StatNames.CritMultiplyer }},
            {CampBuildings.ShamanHut.ToString(), new StatNames[] { StatNames.Speed, StatNames.Defence }},
            {CampBuildings.HunterHut.ToString(), new StatNames[] { StatNames.MaxStamina, StatNames.AttackSpeed }},
            {CampBuildings.WolfHut.ToString(), new StatNames[] {}}
        };
        
        public void Initialize(string buildingName, GameData gameData)
        {
            _applyButton.onClick.AddListener(() => Destroy(gameObject));
            _label.text = LocalizationSystem.Translate(buildingName);
            _buildingName = buildingName;
            Debug.Log(_hutToStats[_buildingName]);
            _gameData = gameData;
            _gameData.ResourceStorage.OnResourcesChanged += DrawButtons;
            
            DrawButtons();
        }

        private void DrawButtons()
        {
            for (int i = 0; i < _upgradeButtons.Count; i++)
            {
                _upgradeButtons[i].Initialize(
                    _gameData.PlayerStats.GetStatByName(_hutToStats[_buildingName][i]),
                    _gameData.ResourceStorage
                );
            }
        }

        private void OnDestroy()
        {
            _gameData.ResourceStorage.OnResourcesChanged -= DrawButtons;
        }
    }
}