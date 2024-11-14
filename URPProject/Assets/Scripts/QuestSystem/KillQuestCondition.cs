using MyGame.QuestSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mygame.QuestSystem
{
    //���� óġ�� ������ �����ϴ� Ŭ����

    public class KillQuestCondition : IQuestCondition
    {

        private string enemyType;   //óġ�ؾ� �� ���� ����
        private int requireKills;   //óġ�ؾ� �� �� ���� ��
        private int currentKills;   //������� óġ�� ���� ��

        public KillQuestCondition(string enemyType, int requireKills)       //óġ ����Ʈ ���� �ʱ�ȭ ������
        {
            this.enemyType = enemyType;
            this.requireKills = requireKills;
            this.currentKills = 0;
        }

        public bool IsMet() => currentKills >= requireKills;            //��ǥ óġ ���� �޼��ߴ��� Ȯ��

        public void Initialize() => currentKills = 0;                   //óġ ���� 0���� �ʱ�ȭ

        public float GetProgress() => (float)currentKills / requireKills;       //���� óġ ���൵�� �ۼ�Ʈ�� ��ȯ

        public string GetDescription() => $"Defeat {requireKills} {enemyType} ({currentKills} / {requireKills}";    //����Ʈ ���� ������ ���ڿ��� ��ȯ

        public void EnemyKilled()       //�� óġ�� ȣ��Ǵ� �ż���
        {
            if (this.enemyType == enemyType)
            {
                currentKills++;
            }
        }
    }
}
