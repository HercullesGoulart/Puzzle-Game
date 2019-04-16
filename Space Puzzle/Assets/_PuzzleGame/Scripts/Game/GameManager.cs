using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameAnalyticsSDK;


public class GameManager : MonoBehaviour
{

    //HUD manager
    HudManager hudManager;

    Pause pause;

    //static instance of the GM can be acessed from anywhere
    public static GameManager instance;

    public static Tile instanceTile;

    void Awake()
    {
        //check that it exists
        if (instance == null)
        {
            //assign it to the current object
            instance = this;
        }
        //make sure that it is equal to the current object
        else if (instance != this)
        {
            instance.hudManager = FindObjectOfType<HudManager>();
            //destroy the current game object - we only need 1 and we already have it
            Destroy(gameObject);
        }
        //dont destroy this object when changing scenes!
        DontDestroyOnLoad(gameObject);

        //find an object of type HudManager
        hudManager = FindObjectOfType<HudManager>();
    }

    public void TryAgain()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    public void BonusLevel()
    {
        if (PlayerPrefs.GetInt("Bonus".ToString()) == 0)
        {
            int bonusLevel = PlayerPrefs.GetInt("Bonus");
            bonusLevel++;

            PlayerPrefs.SetInt("Bonus", bonusLevel);
            SceneManager.LoadScene(bonusLevel);
        }
        else
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("Bonus"));
        }

    }
    public void StartLevel()
    {
        if (PlayerPrefs.GetInt("CurrentLevel".ToString()) == 0)
        {
            int currentLevel = PlayerPrefs.GetInt("CurrentLevel");
            currentLevel++;

            PlayerPrefs.SetInt("CurrentLevel", currentLevel);
            SceneManager.LoadScene(currentLevel);
        }
        else
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("CurrentLevel"));
        }
        
    }
    public void IncreaseLevel()
    {
        int currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        currentLevel++;

        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        SceneManager.LoadScene(currentLevel);


        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "World_01", "Stage_01", "Level_Progress");


    }
    public void QuitGame()
    {
        Application.Quit();

    }
    public void ReturnLevel()
    {
        int currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        currentLevel--;

        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        SceneManager.LoadScene(currentLevel);
    }
}
