using FrostOrcHunter.Scripts.Tribe.RandomEvents;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FrostOrcHunter.Scripts.Tribe.UI
{
    public class RandomEventUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _title;
        [SerializeField] private TextMeshProUGUI _description;
        [SerializeField] private Button _button;
        
        public void Initialize(RandomEvent randomEvent)
        {
            _title.text = randomEvent.Title;
            _description.text = randomEvent.Description;
            _button.onClick.AddListener(() => Destroy(gameObject));
        }
    }
}