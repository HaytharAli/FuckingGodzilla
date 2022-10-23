using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSupervisor : MonoBehaviour
{
    ActionTimeline timeline;
    CartersController controller;

    MovementCommand moveCommand;
    FireCommand fireCommand;
    AimCommand aimCommand;

    int playerNumber = 1;
    string leftHorizontal, leftVertical, rightHorizontal, rightVertical, rightTrigger;

    Vector3 movement, aiming;

    private void Start()
    {
        timeline = gameObject.GetComponent<ActionTimeline>();
        controller = GameObject.Find("Player 1").GetComponent<CartersController>();
        playerNumber = controller.PlayerNumber;

        moveCommand = ScriptableObject.CreateInstance<MovementCommand>();
        fireCommand = ScriptableObject.CreateInstance<FireCommand>();
        aimCommand = ScriptableObject.CreateInstance<AimCommand>();

        if (playerNumber == 1)
        {
            leftHorizontal = "P1LS_hori";
            leftVertical = "P1LS_vert";
            rightHorizontal = "P1RS_hori";
            rightVertical = "P1RS_vert";
            rightTrigger = "P1RT";

        }
        else
        {
            leftHorizontal = "P2LS_hori";
            leftVertical = "P2LS_vert";
            rightHorizontal = "P2RS_hori";
            rightVertical = "P2RS_vert";
            rightTrigger = "P2RT";
        }
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis(leftHorizontal);
        movement.z = Input.GetAxis(leftVertical);
        aiming.z = Input.GetAxis(rightHorizontal);
        aiming.x = -Input.GetAxis(rightVertical);
        float RT = Input.GetAxis(rightTrigger);

        if(movement.magnitude > 0)
        {
            moveCommand.execute(movement);
            timeline.record(moveCommand, movement);
        }
        if(RT > 0.8)
        {
            fireCommand.execute();
            timeline.record(fireCommand);
        }
        if(aiming.magnitude > 0)
        {
            aimCommand.execute(aiming);
            timeline.record(aimCommand, aiming);
        }
    }
}