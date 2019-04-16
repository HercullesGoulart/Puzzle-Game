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

        levelLabel.text = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
    }

}
