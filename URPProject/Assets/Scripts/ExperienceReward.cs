using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame.QuestSystem
{
    public class ExperienceReward : IQuestReward            //����ġ ������ �����ϴ� Ŭ����
    {
        private int experienceAmount;           //�������� ������ ����ġ��

        public ExperienceReward(int amount)             //����ġ ���� �ʱ�ȭ ������
        {
            this.experienceAmount = amount;
        }

        public void Grant(GameObject player)
        {
            Debug.Log($"Granted {experienceAmount} experience");            //TODO : ���� ����ġ ���� ���� ����
        }

        public string GetDescription() => $"{experienceAmount} Experience Points";              //���� ������ ���ڿ��� ��ȯ
    }

}
