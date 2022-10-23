using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;
    float currentTime;

    UnityAction onRoundStart;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    private void Start()
    {
        onRoundStart += startRound;
        EventChad.instance.onRoundStart.AddListener(onRoundStart);
    }

    public void startRound()
    {
        currentTime = 0;
    }

    public float getCurrentTime()
    {
        return currentTime;
    }

    private void Update()
    {
        currentTime = currentTime + Time.deltaTime;
    }
}
