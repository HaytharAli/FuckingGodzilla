using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionInstance : ScriptableObject
{
    CommandAbstract command;
    float timeOfAction;
    public bool directional;
    Vector3 direction;

    public void record(CommandAbstract commandUsed)
    {
        command = commandUsed;
        timeOfAction = TimeManager.instance.getCurrentTime();
    }

    public void record(CommandAbstract commandUsed, Vector3 dir)
    {
        command = commandUsed;
        directional = true;
        direction = dir;
        timeOfAction = TimeManager.instance.getCurrentTime();
    }

    public float getTime()
    {
        return timeOfAction;
    }

    public void execute()
    {
        if (directional)
        {
            command.execute(direction);
        }
        else
        {
            command.execute();
        }
    }
}
