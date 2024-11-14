using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyGame.QuestSystem
{


    public interface IQuestCondition
    {
        bool IsMet();           //조건이 충족 되었는지 여부 반환

        void Initialize();      //조건을 초기화 하는 메서드

        float GetProgress();        //조건 충족도 범위

        string GetDescription();        //조건 설명 반환 매서드

    }
}




