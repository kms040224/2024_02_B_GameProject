using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame.QuestSystem
{
   //����Ʈ�� ���� ���¸� ��Ÿ���� ������ 

    public enum QuestStatus             //����Ʈ�� ���� ���¸� ��Ÿ���� ������
    {
        NotStarted,                 //�������� ���� ����
        InProgress,                 //�������� ����
        Completed,                  //�Ϸ�� ����
        Failed                      //������ ����
    }

    public enum QuestType               //����Ʈ ������ �����ϴ� ������
    {
        Collection,                     //������ ����
        Kill,                           //���� óġ
        Dialog,                         //NPC�� ��ȭ
        Exploration,                    //Ư�� ���� Ž��
        Escort                          //NPC�� ��ȣ/ȣ���ϴ� ����Ʈ
    }
}

