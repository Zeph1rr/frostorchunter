using FrostOrcHunter.Scripts.Data;
using FrostOrcHunter.Scripts.Data.Enums;
using FrostOrcHunter.Scripts.GameRoot;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zeph1rrGameBase.Scripts.Core.DI;
using Zeph1rrGameBase.Scripts.Core.Utils;

namespace FrostOrcHunter.Scripts.Tribe.UI
{
    [RequireComponent(typeof(Button))]
    public class TribeBuilding : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Image _mark;
        
        private TribeUIRoot _uiRoot;
        private GameData _gameData;
        
        public void Initialize(DIContainer container)
        {
            _uiRoot = container.Resolve<TribeUIRoot>();
            _gameData = container.Resolve<GameData>();
        }
        
        private void Start()
        {
            var button = GetComponent<Button>();
            if (gameObject.name.Contains("Hut"))
                button.onClick.AddListener(CreateUI);
            if (gameObject.name == CampBuildings.Firepit.ToString())
            {
                button.onClick.AddListener(RunRandomEvent);
                if (_uiRoot.RandomEvent != null)
                    _mark.gameObject.SetActive(true);
            }

            if (gameObject.name == CampBuildings.WallDoor.ToString())
            {
                button.onClick.AddListener(() => Coroutines.StartRoutine(GameEntryPoint.Instance.LoadScene(Scenes.TRIBE)));
            }
        }

        private void RunRandomEvent()
        {
            _uiRoot.RandomEvent?.Run(_gameData);
            _mark.gameObject.SetActive(false);
            _uiRoot.RemoveRandomEvent();
        }

        private void CreateUI()
        {
            var ui = Instantiate(Resources.Load<TribeBuildingUI>("Prefabs/UI/Tribe/TribeBuildingUI"),_uiRoot.transform);
            ui.Initialize(gameObject.name, _gameData);
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            transform.localScale = new Vector3(1.15f, 1.15f, 1f);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}