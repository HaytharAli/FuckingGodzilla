using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTimeline : MonoBehaviour
{
    List<ActionInstance> actions = new List<ActionInstance>();
    int currentActionIndex = 0;
    bool flag, playbackMode;

    //Reference to player script


    // Start is called before the first frame update
    void Start()
    {
        playbackMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(actions.Count);

        if (playbackMode)
        {
            if (actions.Count < currentActionIndex + 1)
            {
                playbackMode = false;
                return;
            }

            flag = true;
            float currentMatchTime = TimeManager.instance.getCurrentTime();

            while (flag)
            {
                if (actions[currentActionIndex].getTime() < currentMatchTime)
                {
                    actions[currentActionIndex].execute();
                    currentActionIndex++;
                }
                else
                {
                    flag = false;
                }
            }
        }
    }

    public void record(CommandAbstract command, Vector3 direction)
    {
        ActionInstance instance = ScriptableObject.CreateInstance<ActionInstance>();
        instance.record(command, direction);
        actions.Add(instance);
    }

    public void record(CommandAbstract command)
    {
        ActionInstance instance = ScriptableObject.CreateInstance<ActionInstance>();
        instance.record(command);
        actions.Add(instance);
    }

    public void enablePlayback()
    {
        playbackMode = true;
    }
}
