using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public static event Action<int> OnScoreChanged;                     //스코어 변환 Action 등록
    public static event Action OnGameOver;                              //게임 상태 Action 등록

    public int score = 0;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            score += 10;
            OnScoreChanged?.Invoke(score);                              //스코어 변동시 호출
        }
        if(score >= 100)
        {
            OnGameOver?.Invoke();                                        //게임 오버시 호출
        }    
    }
}
