using UnityEngine;
using UnityEngine.InputSystem;
using Zeph1rrGameBase.Scripts.Core.DI;

namespace FrostOrcHunter.Scripts.Tribe.UI
{
    public class TribeUIRoot : MonoBehaviour
    {
        private InputActions _inputActions;
        private TribeMenu _tribeMenu;
        public void Initialize(DIContainer container)
        {
            _tribeMenu = GetComponentInChildren<TribeMenu>();
            _tribeMenu.Initialize(container);
            
            _inputActions = container.Resolve<InputActions>();
            _inputActions.Enable();
            _inputActions.Global.Escape.performed += ToggleTribeMenu;
            Debug.Log("Escape performed");
        }

        private void OnDestroy()
        {
            Debug.Log("OnDestroy");
            _inputActions.Disable();
            _inputActions.Global.Escape.performed -= ToggleTribeMenu;
        }

        private void ToggleTribeMenu(InputAction.CallbackContext obj)
        {
            Debug.Log("TribeMenu Toggle");
            _tribeMenu.Toggle();
        }
    }
}