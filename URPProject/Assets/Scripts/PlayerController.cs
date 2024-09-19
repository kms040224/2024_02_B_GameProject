using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public CommandManager CommandManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ICommand moveRight = new MoveCommand(transform, Vector3.right);
            CommandManager.ExcuteCommand(moveRight);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ICommand moveRigth = new MoveCommand(transform, Vector3.left);
            CommandManager.ExcuteCommand(moveRigth);
        }
        if(Input.GetKeyDown(KeyCode.Z))
        {
            CommandManager.UndoLastCommand();
        }
    }
}
