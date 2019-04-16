using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public RestartLevel restart;
    private void OnCollisionEnter(Collision col)
    {
        if (col.transform.CompareTag("Player"))
        {
            Debug.Log("killerboxplayer");
            StartCoroutine(delayfall());
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if(col.transform.CompareTag("Player"))
        {
            Debug.Log("killerboxplayer");
            StartCoroutine(delayfall());
        }
    }
    
    
    IEnumerator delayfall()
    {
        yield return new WaitForSeconds(0.2f);
        restart.TryAgain();
    }
}
