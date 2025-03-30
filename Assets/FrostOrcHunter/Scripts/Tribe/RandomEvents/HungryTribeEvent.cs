using FrostOrcHunter.Scripts.Data;
using FrostOrcHunter.Scripts.Data.Enums;
using FrostOrcHunter.Scripts.Tribe.UI;
using UnityEngine;

namespace FrostOrcHunter.Scripts.Tribe.RandomEvents
{
    public class HungryTribeEvent : RandomEvent
    {
        private string _onSuccessExpand;
        private string _onFailureExpand;
        
        public HungryTribeEvent(string title, string description, string onSuccessExpand, string onFailureExpand) : base(title, description)
        {
            _onSuccessExpand = onSuccessExpand;
            _onFailureExpand = onFailureExpand;
        }

        public override void Run(GameData gameData)
        {
            var eat = gameData.ResourceStorage.GetResourceByName(ResourceType.Eat.ToString());
            if (eat.Value == 0)
            {
                ExpandDescription(_onFailureExpand);
            }
            else
            {
                ExpandDescription(_onSuccessExpand);
                gameData.ResourceStorage.DecreaseResource(ResourceType.Eat.ToString(), 0.9f);
            }

            
            Draw();
        }
    }
}