using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{

    //coin playing sound
    //public AudioSource coinSound;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
   
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            GameManager.instance.IncreaseScore(1);
            //Play sound
            //coinSound.Play();
            Debug.Log("Coin");
            //Destroy coin
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Enemy"))
        {
            Debug.Log("Found Enemy");
            //Game Over!
            //GameManager.instance.GameOver();
        }
        else if (other.CompareTag("Spikes"))
        {
            Debug.Log("Found Spikes");
        }
        /*else if (other.CompareTag("Goal"))
        {
            //send the player to the next level
            GameManager.instance.IncreaseLevel();
        }
        */
    }
}