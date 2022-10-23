using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActionTimeline : MonoBehaviour
{
    List<ActionInstance> actions = new List<ActionInstance>();
    int currentActionIndex = 0;
    bool flag, playbackMode;

    bool justSpawned;

    UnityAction onRoundStart;

    // Start is called before the first frame update
    void Start()
    {
        playbackMode = false;
        onRoundStart += enablePlayback;
        EventChad.instance.onRoundStart.AddListener(onRoundStart);
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
        if (justSpawned)
        {
            justSpawned = false;
            return;
        }

        playbackMode = true;
        currentActionIndex = 0;
    }
}
