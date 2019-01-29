using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{

    //score text label
    public Text levelLabel;
    //public Text nextLevelLabel;

    // Use this for initialization
    void Start()
    {
        //Start with the correct score
        ResetHud();
    }
    private void Update()
    {
        ResetHud();
    }

    // Show up to date stats of the player
    public void ResetHud()
    {
        //scoreLabel.text = "Score: " + GameManager.instance.score;
        levelLabel.text = GameManager.instance.currentLevel.ToString();
        //nextLevelLabel.text = "Level "  + GameManager.instance.currentLevel.ToString();
    }
}
