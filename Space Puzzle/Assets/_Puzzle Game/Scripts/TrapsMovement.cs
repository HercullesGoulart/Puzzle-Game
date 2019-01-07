using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsMovement : MonoBehaviour
{
    public GameObject Spikes;
    public GameObject Wall;
    public float RespawnTime = 2;

    private void Update()
    {
        StartCoroutine(ActivationRoutine());
    }

    private IEnumerator ActivationRoutine()
    {

        while (Spikes == true && Wall == true)
        {
            //Wait for seconds to Activate
            yield return new WaitForSeconds(RespawnTime);

            //Turn My game object that is set to false(off) to True(on).
            Spikes.SetActive(true);
            Wall.SetActive(true);

            //Turn the Game Oject back off after 1 sec.
            yield return new WaitForSeconds(RespawnTime);

            //Game object will turn off
            Spikes.SetActive(false);
            Wall.SetActive(false);
        }
        
        
    }

}

