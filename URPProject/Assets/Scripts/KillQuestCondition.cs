using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyGame.QuestSystem
{
    //몬스터 처치 퀘스트의 조건을 구현하는 클래스

    public class KillQuestCondition : IQuestCondition
    {

        private string enemyType;           //처치해야할 적의 유형

        private int requireKills;           //처치해야 할 총 적의 수

        private int currKills;      //현재까지 처치한 적의 수


        public KillQuestCondition(string enemyType, int requireKills)
        {
            this.enemyType = enemyType;                 //처치해야 할 적의 유형
            this.requireKills = requireKills;           //처치해야 할 총 적의 수
            this.currKills = 0;                         //현재까지 처치한 적의 수
        }

        //목표 처치 수를 달성 했는지 확인

        public bool IsMet() => currKills >= requireKills;               //목표 처치 수를 달성했는지 확인
        public void Initialize() => currKills = 0;          //처치 수를 0으로 초기화

        public float GetProgress() => (float)currKills / requireKills;      //현재 처치 진행도를 퍼센트로 변환

        public string GetDescription() => $"{requireKills} {enemyType} ({currKills}/{requireKills})";

        public void EnemyKilled(string enemyType)   //적 처치 시 호출되는 매서드
        {
            if(this.enemyType == enemyType)
            {
                currKills++;
            }
        }
    }
}
