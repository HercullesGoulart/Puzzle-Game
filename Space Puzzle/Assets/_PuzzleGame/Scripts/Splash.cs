using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour
{

    public GameObject player;


    int secSplash= 6;
    int numeroSplash = 10;
    public GameObject splash_prefab;
    List<GameObject> SplashList;

    void Start()
    {
        SplashList = new List<GameObject>();
        for (int i = 0; i < numeroSplash; i++)
        {
            GameObject objSplash = (GameObject)Instantiate(splash_prefab);
            objSplash.SetActive(false);
            SplashList.Add(objSplash);


        }

    }
    void Update()
    {
        
    }
   

    public void InstantiateSplash()
    {
        for (int i = 0; i < SplashList.Count; i++)
        {
            if (!SplashList[i].gameObject.activeInHierarchy)
            {
                SplashPosition();
                ResetObj(SplashList[i]);
                SplashList[i].gameObject.SetActive(true);
                StartCoroutine(waitSeconds(SplashList[i]));
                break;
            }
        }
    }
    void SplashPosition()
    {
        transform.rotation = player.transform.rotation;
        int rotation = Random.Range(0, 5) * 90;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, rotation, transform.eulerAngles.z);
        transform.position = player.transform.position + new Vector3(0, -0.21f, 0);
    }

    IEnumerator waitSeconds(GameObject targetDisable)
    {
        yield return new WaitForSeconds(secSplash);
        targetDisable.SetActive(false);
    }

    private void ResetObj(GameObject ResetarObj)
    {
        //Reseta posicao e rotacao do objeto
        ResetarObj.transform.position = transform.position;
        ResetarObj.transform.rotation = transform.rotation;
    }



}
