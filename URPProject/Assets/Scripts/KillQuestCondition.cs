using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyGame.QuestSystem
{
    //���� óġ ����Ʈ�� ������ �����ϴ� Ŭ����

    public class KillQuestCondition : IQuestCondition
    {

        private string enemyType;           //óġ�ؾ��� ���� ����

        private int requireKills;           //óġ�ؾ� �� �� ���� ��

        private int currKills;      //������� óġ�� ���� ��


        public KillQuestCondition(string enemyType, int requireKills)
        {
            this.enemyType = enemyType;                 //óġ�ؾ� �� ���� ����
            this.requireKills = requireKills;           //óġ�ؾ� �� �� ���� ��
            this.currKills = 0;                         //������� óġ�� ���� ��
        }

        //��ǥ óġ ���� �޼� �ߴ��� Ȯ��

        public bool IsMet() => currKills >= requireKills;               //��ǥ óġ ���� �޼��ߴ��� Ȯ��
        public void Initialize() => currKills = 0;          //óġ ���� 0���� �ʱ�ȭ

        public float GetProgress() => (float)currKills / requireKills;      //���� óġ ���൵�� �ۼ�Ʈ�� ��ȯ

        public string GetDescription() => $"{requireKills} {enemyType} ({currKills}/{requireKills})";

        public void EnemyKilled(string enemyType)   //�� óġ �� ȣ��Ǵ� �ż���
        {
            if(this.enemyType == enemyType)
            {
                currKills++;
            }
        }
    }
}
