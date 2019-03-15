using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DownTile : MonoBehaviour
{
    public Animator _anim;
    public Tile tile;
    public RestartLevel restart;



    private void OnCollisionEnter(Collision col)
    {
        if (col.transform.CompareTag("Player"))
        {
            _anim.enabled = true;


        }

    }
    public void CurrentTile()
    {
        if (this.tile.current == true)
        {
            Debug.Log("currentTileTest");
            StartCoroutine(delayfall());
        }
    }

    public void DesactivateAnim()
    {
        _anim.enabled = false;
    }
    IEnumerator delayfall()
    {
        yield return new WaitForSeconds(0.2f);
        restart.TryAgain();
    }




}
