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

    int playerNumber, characterNumber;
    string leftHorizontal, leftVertical, rightHorizontal, rightVertical, rightTrigger;

    Vector3 movement, aiming;

    bool freshlySpawned = true;

    [SerializeField] bool takeInput = true;

    private void Start()
    {
        timeline = gameObject.GetComponent<ActionTimeline>();
        controller = gameObject.GetComponent<CartersController>();
        playerNumber = controller.PlayerNumber;
        characterNumber = controller.CharacterNumber;

        moveCommand = ScriptableObject.CreateInstance<MovementCommand>();
        moveCommand.AssignPlayer(characterNumber);
        fireCommand = ScriptableObject.CreateInstance<FireCommand>();
        fireCommand.AssignPlayer(characterNumber);
        aimCommand = ScriptableObject.CreateInstance<AimCommand>();
        aimCommand.AssignPlayer(characterNumber);

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
        float RT = 0;
        if (takeInput)
        {
            movement.x = Input.GetAxis(leftHorizontal);
            movement.z = Input.GetAxis(leftVertical);
            aiming.z = Input.GetAxis(rightHorizontal);
            aiming.x = -Input.GetAxis(rightVertical);
            RT = Input.GetAxis(rightTrigger);

            if (movement.magnitude > 0)
            {
                moveCommand.execute(movement);
                timeline.record(moveCommand, movement);
            }
            if (RT > 0.8)
            {
                fireCommand.execute();
                timeline.record(fireCommand);
            }
            if (aiming.magnitude > 0)
            {
                aimCommand.execute(aiming);
                timeline.record(aimCommand, aiming);
            }
        }
    }

    public void stopInput()
    {
        Debug.Log("Stopping input on Player " + characterNumber);
        if (freshlySpawned)
        {
            freshlySpawned = false;
            return;
        }
        takeInput = false;
    }
}