using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleQuad : MonoBehaviour
{
    public GameObject player;
    public float fallSpeed = 8.0f;
    public bool isfalling = false;
    public RestartLevel restart;
    Vector3 initialPos;

    void Update()
    {
        if (isfalling == true)
        {
            StartCoroutine(ReturnTile());
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        isfalling = true;
    }

    public void PlayerFall()
    {
        //StartCoroutine(RestartLevel());

    }

    IEnumerator ReturnTile()
    {
        initialPos = transform.position;
        yield return new WaitForSeconds(1f);
        Debug.Log("hole");
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
        transform.position = initialPos;
    }
    //    StartCoroutine(RestartLevel());
    //    //yield return new WaitForSeconds(0.1f);
    //    //transform.position = initialPos;

//}
//IEnumerator RestartLevel()

//{
//    if (behaviorplayer.holePlayer == true)
//    {
//        yield return new WaitForSeconds(0.5f);
//        Debug.Log("holeplayer");
//        player.transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
//        yield return new WaitForSeconds(0.2f);
//        restart.TryAgain();

//    }

}


