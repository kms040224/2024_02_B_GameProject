using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame.QuestSystem
{

    public enum QuestStatus             //퀘스트의 현재 상태를 나타내는 열거형
    {
        NotStarted,                     //퀘스트가 아직 진행되지 않은 상태
        InProgress,                     //퀘스트가 현재 진행중인 상태
        Completed,                      //퀘스트가 완료된 상태
        Failed                          //퀘스트가 실패한 상태
    }

    public enum QuestType               //퀘스트의 유형을 구분하는 열거형
    {
        Collection,                     //수집
        Kill,                           //사냥
        Dialog,                         //대화퀘스트
        Exploration,                    //특정 지역 탐험
        Escort                          //NPC를 몬스터로부터 보호/호위 하는 퀘스트
    }
}
