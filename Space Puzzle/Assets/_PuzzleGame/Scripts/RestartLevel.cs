using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    GameManager instance;


    public void TryAgain()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    public void QuitGame()
    {
        Application.Quit();

    }
    public void ChangeLevel()
    {
        GameManager.instance.IncreaseLevel();
    }
}
