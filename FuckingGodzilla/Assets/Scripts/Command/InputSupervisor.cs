using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSupervisor : MonoBehaviour
{
    public ActionTimeline timeline;

    MovementCommand moveCommand;
    FireCommand fireCommand;
    AimCommand aimCommand;

    public int playerNumber = 1;
    string leftHorizontal, leftVertical, rightHorizontal, rightVertical, rightTrigger;

    Vector3 movement, aiming;

    private void Start()
    {
        moveCommand = new MovementCommand();
        fireCommand = new FireCommand();
        aimCommand = new AimCommand();

        if(playerNumber == 1)
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

        moveCommand = new MovementCommand();
    }

    // Update is called once per frame
    void Update()
    {
        float LSX = Input.GetAxis(leftHorizontal);
        float LSY = Input.GetAxis(leftVertical);
        float RSX = Input.GetAxis(rightHorizontal);
        float RSY = Input.GetAxis(rightVertical);
        float RT = Input.GetAxis(rightTrigger);

        movement = new Vector3(LSX, 0, LSY);
        aiming = new Vector3(RSX, 0, RSY);

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
            aimCommand.execute();

        }
    }
}