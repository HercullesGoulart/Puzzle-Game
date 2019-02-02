using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour {

    public AudioSource groundSound;
    public AudioSource waterSound;


    public void Grounded()
    {
        groundSound.Play();
        waterSound.Play();
    }
}
