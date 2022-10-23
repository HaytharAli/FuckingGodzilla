using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCommand : CommandAbstract
{
    CartersController cartersController;

    private void Awake()
    {
        cartersController = GameObject.Find("Player 1").GetComponent<CartersController>();
    }

    public override void execute(Vector3 movement)
    {
        cartersController.Movement(movement);
    }
}