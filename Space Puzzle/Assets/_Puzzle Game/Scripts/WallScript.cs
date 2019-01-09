using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{

    public GameObject Wall;
    public float RespawnTime = 3;

    void Update()
    {
        StartCoroutine(ActivationRoutine());
    }

    private IEnumerator ActivationRoutine()
    {

        while (Wall == true)
        {
            //Wait for seconds to Activate
            yield return new WaitForSeconds(RespawnTime);

            //Turn My game object that is set to false(off) to True(on).
            Wall.SetActive(false);

            //Turn the Game Oject back off after 1 sec.
            yield return new WaitForSeconds(RespawnTime);

            //Game object will turn off
            Wall.SetActive(true);
        }

    }

}
