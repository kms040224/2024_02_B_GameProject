using MyGame.QuestSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mygame.QuestSystem
{

    public class ItemReward : IQuestReward
    {

        private string itemId;
        private int amount;

        public ItemReward(string itemId, int amount)
        {
            this.itemId = itemId;
            this.amount = amount;
        }

        public void Grant(GameObject plalyer)
        {
            Debug.Log($"Granted {amount} {itemId}");
        }

        public string GetDescription() => $"{amount} {itemId}";
    }
}
