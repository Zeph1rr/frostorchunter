using FrostOrcHunter.Scripts.Data;
using FrostOrcHunter.Scripts.Tribe.UI;
using UnityEngine;

namespace FrostOrcHunter.Scripts.Tribe.RandomEvents
{
    public abstract class RandomEvent
    {
        public string Title => _title;
        public string Description => _description;

        private string _title;
        private string _description;

        public RandomEvent(string title, string description)
        {
            _title = title;
            _description = description;
        }

        public abstract void Run(GameData gameData);

        public void ExpandDescription(string description)
        {
            _description += description;
        }

        public void Draw()
        {
            var eventPrefab = Resources.Load<RandomEventUI>("Prefabs/UI/Tribe/RandomEventUI");
            var tribeUIRoot = Object.FindFirstObjectByType<TribeUIRoot>();
            var eventUI = Object.Instantiate(eventPrefab, tribeUIRoot.transform);
            eventUI.Initialize(this);
        }
    }
}