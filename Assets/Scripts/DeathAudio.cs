using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAudio : MonoBehaviour
{

    public AudioSource audioSourceIntro;
    public AudioSource audioSourceLoop;
    private bool startedLoop;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!audioSourceIntro.isPlaying && !startedLoop)
        {
            audioSourceLoop.Play();
            startedLoop = true;
        }
    }
}
