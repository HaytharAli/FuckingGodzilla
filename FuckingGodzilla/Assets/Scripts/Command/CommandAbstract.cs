using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandAbstract : ScriptableObject
{
    //Reference to the player script

    public virtual void execute()
    {

    }

    public virtual void execute(Vector3 direction)
    {

    }
}