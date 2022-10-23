using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHost : MonoBehaviour
{
    public static GameHost instance;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }
}