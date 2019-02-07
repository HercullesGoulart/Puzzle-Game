using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    [SerializeField]
    private GameObject pausePanel;


    void Start()
    {
        pausePanel.SetActive(false);
    }
    void Update()
    {

    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        //Disable scripts that still work while timescale is set to 0
        Debug.Log("Game Pausado");
    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        //enable the scripts again
    }
    public void Mute()
    {
        AudioListener.pause = !AudioListener.pause;
    }
    

}
