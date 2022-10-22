using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;
    float currentTime;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
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
