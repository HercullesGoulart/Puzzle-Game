using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // score of the player
    public int score = 0;
    //high score of the game
    public int Highscore = 0;
    //current level
    public int currentLevel = 1;
    //how levels there are
    public int highestLevel = 2;
    //HUD manager
    HudManager hudManager;

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

    //increase the player score
    public void IncreaseScore(int amount)
    {
        score += amount;
        //update the HUD
        if (hudManager != null)
        {
            hudManager.ResetHud();
        }

        //show the new score
        print("new score:" + score);
        if (score > Highscore)
        {
            //save the new Highscore
            Highscore = score;

            print("New record!" + Highscore);
        }

    }
    public void ResetGame()
    {
        //reset our score
        score = 0;
        //set the current level to 1
        currentLevel = 1;
        //load the level 1
        SceneManager.LoadScene("Level1");
    }
    public void TryAgain()
    {
        score = 0;
        SceneManager.LoadScene(currentLevel);
    }
    //send the player to the next level
    public void IncreaseLevel()
    {

        currentLevel++;
        //check if there are more levels
        /*if (currentLevel < highestLevel)
        {
            //increase currentLevel by 1
            currentLevel++;
            
        }
        else
        {
            //we are gonna go back to level 1
            currentLevel = 1;
        }*/
        SceneManager.LoadScene("Level" + currentLevel);
        //trying to activate player turn
    }
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
