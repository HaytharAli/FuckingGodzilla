using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnvironmentScript : MonoBehaviour
{
    Vector3 oriP;
    Quaternion oriR;
    Rigidbody rb;
    UnityAction onRoundStart;

    private void Start()
    {
        oriP = transform.position;
        oriR = transform.rotation;
        rb = GetComponent<Rigidbody>();
        
        onRoundStart += returnToHome;
        EventChad.instance.onRoundStart.AddListener(onRoundStart);
    }

    public void returnToHome()
    {
        transform.position = oriP;
        transform.rotation = oriR;

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
