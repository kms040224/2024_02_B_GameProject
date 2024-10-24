using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame.QuestSystem
{
    //퀘스트 조건을 정의하는 인터페이스

    public interface IQuestCondition
    {

        bool IsMet();

        void Initialize();

        float GetProgress();

        string GetDescription();


    }
}
