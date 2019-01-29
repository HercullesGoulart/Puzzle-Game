using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour {

    public AudioSource groundSound;
    public AudioSource waterSound;
    public GameObject splash_prefab;
    public GameObject player;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Grounded()
    {
        groundSound.Play();
        waterSound.Play();
        //Instantiate(splash_prefab, player.transform.position, player.transform.rotation);
        
    }
}
