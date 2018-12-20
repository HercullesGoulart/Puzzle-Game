using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {

    //coin playing sound
    public AudioSource coinSound;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        //onde clicar muda a posicao do player para a nova posicao
    }

     void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            //GameManager.instance.IncreaseScore(1);
            //Play sound
            coinSound.Play();

            //Destroy coin
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Enemy"))
        {
            //Game Over!
            //GameManager.instance.GameOver();
        }
        /*else if (other.CompareTag("Goal"))
        {
            //send the player to the next level
            GameManager.instance.IncreaseLevel();
        }
        */

    }

}
