using UnityEngine;
using UnityEngine.UI;

namespace FrostOrcHunter.Scripts.MainMenu.UI
{
    [RequireComponent(typeof(Button))]
    public class ExitButton : MonoBehaviour
    {
        private void Awake()
        {
            var button = GetComponent<Button>();
            if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                button.interactable = false;
            }
        }
    }
}