using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainfuckingmenuscript : MonoBehaviour
{
    [SerializeField] AudioRandomizerContainer footsteps;
    [SerializeField] AudioRandomizerContainer shoot;

    bool playOnce = false;

    AudioClipRandomizer foot;
    AudioClipRandomizer shit;

    void Start()
    {
        foot = gameObject.AddComponent<AudioClipRandomizer>();
        foot.ArcObj = footsteps;

        shit = gameObject.AddComponent<AudioClipRandomizer>();
        shit.ArcObj = shoot;
    }
    void Update()
    {
        if (Input.GetButton("P1_A") || Input.GetButton("P2_A"))
        {
            Debug.Log("Switch scenes");
            SceneManager.LoadScene(1); //Switches to the gameplay scene
        }

        if (Input.GetAxis("P1RT") == 1.0f || Input.GetAxis("P2RT") == 1.0f)
        {
            if (playOnce == false)
            {
                shit.PlaySFX();
                playOnce = true;
            }
        }
    }
}
