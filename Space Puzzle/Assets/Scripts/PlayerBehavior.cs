using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{

    //coin playing sound
    public AudioSource coinSound;
    public float speed = 100;
    public Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //onde clicar muda a posicao do player para a nova posicao
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 tempVect = new Vector3(h, v, 0);
        tempVect = tempVect.normalized * speed * Time.deltaTime;
        rb.MovePosition(rb.transform.position + tempVect);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            //GameManager.instance.IncreaseScore(1);
            //Play sound
            coinSound.Play();
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
        /*else if (other.CompareTag("Goal"))
        {
            //send the player to the next level
            GameManager.instance.IncreaseLevel();
        }
        */
    }
}