using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{
    public float cameraDistZ = 4;
    void Start()
    {
        CameraFollowPlayer();
    }
    private void FixedUpdate()
    {
        CameraFollowPlayer();
        if (GameObject.FindWithTag("Coin") == null)
        {
            Debug.Log("Passou de nivel");
            //level complete
            GameManager.instance.IncreaseLevel();
        }
        else
        {
            return;
        }
    }

    void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Coin"))
        {
            GameManager.instance.IncreaseScore(1);
            //Destroy coin
            Destroy(other.gameObject);


        }
        else if (other.CompareTag("Enemy"))
        {
            Debug.Log("Found Enemy");
        }
        else if (other.CompareTag("Spikes"))
        {
            Debug.Log("Found Spikes");
            //Game over ou perder vida
            GameManager.instance.GameOver();
        }


    }
    public void CameraFollowPlayer()
    {
        //grab the camera position
        Vector3 cameraPos = Camera.main.transform.position;

        //modify it's position according to cameraDistZ
        cameraPos.z = transform.position.z - cameraDistZ;

        //set the camera position
        Camera.main.transform.position = cameraPos;
    }
}