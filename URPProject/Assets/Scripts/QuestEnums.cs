using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame.QuestSystem
{

    public enum QuestStatus             //����Ʈ�� ���� ���¸� ��Ÿ���� ������
    {
        NotStarted,                     //����Ʈ�� ���� ������� ���� ����
        InProgress,                     //����Ʈ�� ���� �������� ����
        Completed,                      //����Ʈ�� �Ϸ�� ����
        Failed                          //����Ʈ�� ������ ����
    }

    public enum QuestType               //����Ʈ�� ������ �����ϴ� ������
    {
        Collection,                     //����
        Kill,                           //���
        Dialog,                         //��ȭ����Ʈ
        Exploration,                    //Ư�� ���� Ž��
        Escort                          //NPC�� ���ͷκ��� ��ȣ/ȣ�� �ϴ� ����Ʈ
    }
}
