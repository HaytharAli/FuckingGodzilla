using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSupervisor : MonoBehaviour
{
    //CommandAbstract[] commands = new CommandAbstract[100];
    //MovementCommand moveCommand;
    public int playerNumber = 1;
    string horizontalAxis, verticalAxis;

    private void Start()
    {
        //moveCommand = new MovementCommand();
        if(playerNumber == 1)
        {
            horizontalAxis = "Horizontal1";
            verticalAxis = "Vertical1";

        }
        else
        {
            horizontalAxis = "Horizontal2";
            verticalAxis = "Vertical2";
        }
        //commands[1];
    }

    // Update is called once per frame
    void Update()
    {
        float LSX = Input.GetAxis("P1LS_hori");
        float LSY = Input.GetAxis("P1LS_vert");
        float RSX = Input.GetAxis("P1RS_hori");
        float RSY = Input.GetAxis("P1RS_vert");

        Debug.Log("Left Stick X: " + LSX + " Y: " + LSY + " Right Stick X: " + RSX + " Y: " + RSY);
    }
}