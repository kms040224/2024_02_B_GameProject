using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame.QuestSystem
{

    public class CollectionQuestCondition : IQuestCondition     //�������� �����ϴ� ����Ʈ ������ �����ϴ� Ŭ����
    {
        private string itemId;                      //�����ؾ� �� ������ ID
        private int requireAmount;                  //�����ؾ� �� ������ ����
        private int currentAmount;                  //������� ������ ������ ����

        public CollectionQuestCondition(string itemId, int requireAmount)       //�����ڿ��� ������ ID�� �ʿ��� ������ ����
        {
            this.itemId = itemId;
            this.requireAmount = requireAmount;
            this.currentAmount = 0;
        }

        public bool IsMet() => currentAmount > requireAmount;           //����Ʈ ������ �����Ǿ����� ���� Ȯ��

        public void Initialize() => currentAmount = 0;                      //������ �ʱ�ȭ �Ͽ� ������ 0

        public float  GetProgress() => (float)currentAmount / requireAmount;            //���� ���� ��Ȳ�� 0���� 1������ ������ ��ȯ

        public string GetDescription() => $"{requireAmount} {itemId} ({currentAmount}/{requireAmount})";                 //����Ʈ ���� ������ ���ڿ��� ��ȯ

        public void ItemCollected(string itemId)
        {
            if(this.itemId == itemId)
            {
                currentAmount++;
            }
        }
    }
}
