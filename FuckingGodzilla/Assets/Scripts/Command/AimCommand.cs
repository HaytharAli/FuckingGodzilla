using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCommand : CommandAbstract
{
    CartersController controller;
    public void AssignPlayer(int number)
    {
        controller = GameObject.Find("Player " + number).GetComponent<CartersController>();
    }

    public override void execute(Vector3 movement)
    {
        controller.Aiming(movement);
    }
}
