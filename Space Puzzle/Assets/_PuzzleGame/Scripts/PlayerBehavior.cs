using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{

    public Animator transitionAnim;
    public ParticleSystem particleAnim;
    public AudioSource groundSound;


    public float cameraDistZ = 4;
    //public float cameraDistX = 0;
    void Start()
    {
        CameraFollowPlayer();
    }
    void Update()
    {

        CameraFollowPlayer();
        if (GameObject.FindWithTag("Coin") == null)
        {
            Debug.Log("Passou de nivel");
            //level complete
            EndScene();
            ChangeLevel();
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
        if (other.CompareTag("Tile"))
        {
            particleAnim.Play();
            groundSound.Play();

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


    }
    public void CameraFollowPlayer()
    {
        //grab the camera position
        Vector3 cameraPos = Camera.main.transform.position;

        //modify it's position according to cameraDistZ
        cameraPos.z = transform.position.z - cameraDistZ;
        //cameraPos.x = transform.position.x - cameraDistX;

        //set the camera position
        Camera.main.transform.position = cameraPos;
    }
    IEnumerator EndScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(2f);
        
    }
    void ChangeLevel()
    {
        GameManager.instance.IncreaseLevel();
    }
}