using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCommand : CommandAbstract
{
    CartersController controller;
    private void Awake()
    {
        controller = GameObject.Find("Player 1").GetComponent<CartersController>();
    }

    public override void execute(Vector3 movement)
    {
        controller.Aiming(movement);
    }
}
