using System;
using System.Collections.Generic;
using System.Linq;
using FrostOrcHunter.Scripts.Data;
using FrostOrcHunter.Scripts.Data.Enums;
using FrostOrcHunter.Scripts.GameRoot.UI.Resource;
using UnityEngine;
using UnityEngine.InputSystem;
using Zeph1rrGameBase.Scripts.Core.DI;

namespace FrostOrcHunter.Scripts.Tribe.UI
{
    public class TribeUIRoot : MonoBehaviour
    {
        [SerializeField] private TribeMenu _tribeMenu;
        [SerializeField] private ResourceStorageView _resourceStorageView;
        [SerializeField] private List<TribeBuilding> _buildings;
        
        private InputActions _inputActions;
        private GameData _gameData;
        
        public void Initialize(DIContainer container)
        {
            _gameData = container.Resolve<GameData>();
            
            _tribeMenu.Initialize(container);
            container.RegisterInstance(this);
            
            _inputActions = container.Resolve<InputActions>();
            _inputActions.Enable();
            _inputActions.Global.Escape.performed += ToggleTribeMenu;

            foreach (var tribeBuilding in _buildings)
            {
                tribeBuilding.gameObject.SetActive(false);
                if (_gameData.CampBuildings.Contains((CampBuildings)Enum.Parse(typeof(CampBuildings), tribeBuilding.name)))
                {
                    tribeBuilding.gameObject.SetActive(true);
                    tribeBuilding.Initialize(container);
                }
            }
            
            _resourceStorageView.Initialize(_gameData.ResourceStorage);
        }

        private void OnDestroy()
        {
            _inputActions.Disable();
            _inputActions.Global.Escape.performed -= ToggleTribeMenu;
        }

        private void ToggleTribeMenu(InputAction.CallbackContext obj)
        {
            _tribeMenu.Toggle();
        }

        public void AttachUIElement(GameObject uiElement)
        {
            uiElement.transform.SetParent(transform);
        }
    }
}