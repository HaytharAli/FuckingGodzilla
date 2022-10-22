using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCommand : CommandAbstract
{
    //player;
    private void Start()
    {
    }
    public override void execute()
    {
        Debug.Log("Jumping");
        //if (player == null) return;
        //player.OnJump();
    }

    void findPlayer()
    {
        //player = FindObjectOfType<TpMovement>();
    }
}