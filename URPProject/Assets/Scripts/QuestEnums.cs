using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame.QuestSystem
{
   //퀘스트의 현재 상태를 나타내는 열거형 

    public enum QuestStatus             //퀘스트의 현재 상태를 나타내는 열거형
    {
        NotStarted,                 //시작하지 않은 상태
        InProgress,                 //진행중인 상태
        Completed,                  //완료된 상태
        Failed                      //실패한 상태
    }

    public enum QuestType               //퀘스트 유형을 구분하는 열거형
    {
        Collection,                     //아이템 수집
        Kill,                           //몬스터 처치
        Dialog,                         //NPC와 대화
        Exploration,                    //특정 지역 탐험
        Escort                          //NPC를 보호/호위하는 퀘스트
    }
}

