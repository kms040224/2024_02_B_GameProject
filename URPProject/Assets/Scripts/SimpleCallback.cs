using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCallback : MonoBehaviour
{
    private Action greetingAction;                  //�׼� ����
    // Start is called before the first frame update
    void Start()
    {
        greetingAction = SayHello;                  //Action �Լ� �Ҵ�
        PerformGreeting(greetingAction);
    }

    void SayHello()
    {
        Debug.Log("Hello, wolrd!");
    }

    void PerformGreeting(Action greetingFunc)
    {
        greetingFunc?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
