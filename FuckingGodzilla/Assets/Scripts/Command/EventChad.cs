using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventChad : MonoBehaviour
{
    [SerializeField] UnityEvent onRoundStart;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            onRoundStart.Invoke();
        }
    }
}
