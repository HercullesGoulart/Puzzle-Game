using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{

    public GameObject congratulations;
    public Animator transitionAnim;
    public ParticleSystem particleAnim;
    public AudioSource coinSound;
    public GameObject finalCoin;
    public int progress;

    public ProgressBar Pb;


    void Start()
    {
        Pb.BarValue = 0;

        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        int numberOfCoins = coins.Length;

        int totalCoins = numberOfCoins + 1;

        progress = 100 / totalCoins;



    }
    void Update()
    {
        if (GameObject.FindWithTag("Coin") == null)
        {
            finalCoin.SetActive(true);
        }
        
    }


    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("FinalCoin"))
        {
            PlayerPrefs.SetInt("CurrentLevel",SceneManager.GetActiveScene().buildIndex);
            //Destroy coin
            coinSound.Play();
            Destroy(other.gameObject);
            //level complete
            congratulations.SetActive(true);
            StartCoroutine(EndAnimation());
            StartCoroutine(EndScene());
            
        }
        if (other.CompareTag("Coin"))
        {


            //Destroy coin
            coinSound.Play();
            Destroy(other.gameObject);
            Pb.BarValue = Pb.BarValue + progress;
        }

        else if (other.CompareTag("NPC"))
        {

            GameManager.instance.TryAgain();
        }
        else if (other.CompareTag("Spikes"))
        {

            //Game over ou perder vida
            GameManager.instance.TryAgain();
        }


    }

    IEnumerator EndScene()
    {

        yield return new WaitForSeconds(2f);

        ChangeLevel();
        //LevelCleared();

    }
    IEnumerator EndAnimation()
    {

        yield return new WaitForSeconds(1f);

        transitionAnim.SetTrigger("end");


    }
    void ChangeLevel()
    {
        GameManager.instance.IncreaseLevel();
    }
 
}