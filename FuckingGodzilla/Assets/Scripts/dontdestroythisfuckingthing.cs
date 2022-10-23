using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontdestroythisfuckingthing : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
