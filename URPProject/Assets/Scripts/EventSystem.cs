using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public static event Action<int> OnScoreChanged;                     //���ھ� ��ȯ Action ���
    public static event Action OnGameOver;                              //���� ���� Action ���

    public int score = 0;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            score += 10;
            OnScoreChanged?.Invoke(score);                              //���ھ� ������ ȣ��
        }
        if(score >= 100)
        {
            OnGameOver?.Invoke();                                        //���� ������ ȣ��
        }    
    }
}
