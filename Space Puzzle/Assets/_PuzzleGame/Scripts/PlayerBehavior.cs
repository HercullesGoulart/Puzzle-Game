using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{

    public GameObject congratulations;
    public Animator transitionAnim;
    public ParticleSystem particleAnim;
    public AudioSource coinSound;
    public GameObject finalCoin;
    public int progress;

    public ProgressBar Pb;


    public AudioSource groundSound;
    public AudioSource waterSound;


    void Start()
    {
        CameraFollowPlayer();

        Pb.BarValue = 0;

        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        int numberOfCoins = coins.Length;


        int totalCoins = numberOfCoins + 1;

        progress = 100 / totalCoins;

    }
    void Update()
    {

        CameraFollowPlayer();
        if (GameObject.FindWithTag("Coin") == null)
        {
            finalCoin.SetActive(true);

        }

        else
        {
            return;
        }



    }


    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("FinalCoin"))
        {
            GameManager.instance.IncreaseScore(1);


            //Destroy coin
            coinSound.Play();
            Destroy(other.gameObject);
            Debug.Log("Passou de nivel");
            //level complete
            congratulations.SetActive(true);
            StartCoroutine(EndAnimation());
            StartCoroutine(EndScene());
            
        }
        if (other.CompareTag("Coin"))
        {
            GameManager.instance.IncreaseScore(1);


            //Destroy coin
            coinSound.Play();
            Destroy(other.gameObject);
            Pb.BarValue = Pb.BarValue + progress;
        }

        else if (other.CompareTag("NPC"))
        {
            Debug.Log("Found Enemy");
            GameManager.instance.TryAgain();
        }
        else if (other.CompareTag("Spikes"))
        {
            Debug.Log("Found Spikes");
            //Game over ou perder vida
            GameManager.instance.TryAgain();
        }
        else if (other.CompareTag("Tile"))
        {
            groundSound.Play();
            waterSound.Play();
        }


    }

    public void CameraFollowPlayer()
    {
        //grab the camera position
        //Vector3 cameraPos = Camera.main.transform.position;

        ////modify it's position according to cameraDistZ
        //cameraPos.z = transform.position.z - cameraDistZ;
        ////cameraPos.z = transform.position.y + cameraDistY;

        ////set the camera position
        //Camera.main.transform.position = cameraPos;
    }
    IEnumerator EndScene()
    {

        yield return new WaitForSeconds(2f);

        Debug.Log("chamou o EndScene");
        ChangeLevel();

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