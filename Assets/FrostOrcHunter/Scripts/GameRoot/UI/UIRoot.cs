using UnityEngine;

namespace FrostOrcHunter.Scripts.GameRoot.UI
{
    public class UIRoot : MonoBehaviour
    {
        [SerializeField] private GameObject _loadingScreen;
        [SerializeField] private Transform _uiSceneContainer;
        [SerializeField] private AudioSource _music;

        public void AttachSceneUI(GameObject uiScene)
        {
            ClearSceneUI();

            var canvas = GetComponentInChildren<Canvas>();
            canvas.worldCamera = Camera.main;
            
            uiScene.transform.SetParent(_uiSceneContainer, false);
        }
        
        public void HideLoadingScreen()
        {
            _loadingScreen.SetActive(false);
        }
        
        public void ShowLoadingScreen()
        {
            _loadingScreen.SetActive(true);
            if (!_music.isPlaying)
                StartMusic();
        }

        public void StartMusic()
        {
            _music.Play();
        }

        public void PauseMusic()
        {
            _music.Pause();
        }

        public void StopMusic()
        {
            _music.Stop();
        }

        public void SetMusicVolume(float volume)
        {
            _music.volume = volume;
        }
            
        private void Awake()
        {
            HideLoadingScreen();
        }

        public void ClearSceneUI()
        {
            var childCount = _uiSceneContainer.childCount;
            for (var i = 0; i < childCount; i++)
            {
                Destroy(_uiSceneContainer.GetChild(i).gameObject);
            }
        }
    }
}