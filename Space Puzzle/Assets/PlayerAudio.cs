﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour {

    public AudioSource groundSound;


    public void Grounded()
    {
        groundSound.Play();
    }
}
