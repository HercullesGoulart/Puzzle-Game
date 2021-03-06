﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{

    //score text label
    public Text scoreLabel;
    public Text levelLabel;

    // Use this for initialization
    void Start()
    {
        //Start with the correct score
        ResetHud();
    }

    // Show up to date stats of the player
    public void ResetHud()
    {
        scoreLabel.text = "Score: " + GameManager.instance.score;
        levelLabel.text = "Level " + GameManager.instance.currentLevel.ToString();
    }
}
