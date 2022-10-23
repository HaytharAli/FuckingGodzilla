using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventChad : MonoBehaviour
{
    public static EventChad instance;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }


    [SerializeField] public UnityEvent onRoundStart;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            onRoundStart.Invoke();
        }
    }
}
