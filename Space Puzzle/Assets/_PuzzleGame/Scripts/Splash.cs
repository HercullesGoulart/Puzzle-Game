using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour
{

    public GameObject player;


    public int numeroSplash = 20;
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
        transform.position = player.transform.position + new Vector3(0, -0.21f, 0);

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tile"))
        {
            InstantiateSplash();
        }
    }

    public void InstantiateSplash()
    {
        for (int i = 0; i < SplashList.Count; i++)
        {
            if (!SplashList[i].gameObject.activeInHierarchy)
            {
                ResetObj(SplashList[i]);
                SplashList[i].gameObject.SetActive(true);
                StartCoroutine(waitSeconds(SplashList[i]));
                break;
            }
        }
    }

    IEnumerator waitSeconds(GameObject targetDisable)
    {
        yield return new WaitForSeconds(8f);
        targetDisable.SetActive(false);
    }

    private void ResetObj(GameObject ResetarObj)
    {
        //Reseta posicao e rotacao do objeto
        ResetarObj.transform.position = transform.position;
        ResetarObj.transform.rotation = transform.rotation;
    }



}
