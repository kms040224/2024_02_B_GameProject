using MyGame.QuestSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mygame.QuestSystem
{
    //몬스터 처치의 조건을 구현하는 클래스

    public class KillQuestCondition : IQuestCondition
    {

        private string enemyType;   //처치해야 할 적의 유형
        private int requireKills;   //처치해야 할 총 적의 수
        private int currentKills;   //현재까지 처치한 적의 수

        public KillQuestCondition(string enemyType, int requireKills)       //처치 퀘스트 조건 초기화 생성자
        {
            this.enemyType = enemyType;
            this.requireKills = requireKills;
            this.currentKills = 0;
        }

        public bool IsMet() => currentKills >= requireKills;            //목표 처치 수를 달성했는지 확인

        public void Initialize() => currentKills = 0;                   //처치 수를 0으로 초기화

        public float GetProgress() => (float)currentKills / requireKills;       //현재 처치 진행도를 퍼센트로 전환

        public string GetDescription() => $"Defeat {requireKills} {enemyType} ({currentKills} / {requireKills}";    //퀘스트 조건 설명을 문자열로 변환

        public void EnemyKilled()       //적 처치시 호출되는 매서드
        {
            if (this.enemyType == enemyType)
            {
                currentKills++;
            }
        }
    }
}
