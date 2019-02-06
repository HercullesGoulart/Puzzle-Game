using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    //HUD manager
    HudManager hudManager;

    Pause pause;
    public int currentLevel=0;

    //static instance of the GM can be acessed from anywhere
    public static GameManager instance;

    public static Tile instanceTile;
    private void Start()
    {
        currentLevel = PlayerPrefs.GetInt("CurrentLevel");
    }
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
    //send the player to the next level
    public void StartLevel()
    {

        PlayerPrefs.SetInt("CurrentLevel", currentLevel);

        SceneManager.LoadScene(PlayerPrefs.GetInt("CurrentLevel"));
        //SceneManager.LoadScene("1");
       // Debug.Log("Tentando carregar a cena");


    }
    public void IncreaseLevel()
    {

        
        currentLevel++;

        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        SceneManager.LoadScene(currentLevel);

        //trying to activate player turn
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
