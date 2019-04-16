using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownTile : MonoBehaviour
{
    public Animator _anim;
    public Tile tile;
    public RestartLevel restart;
    Collider Collider;
    public GameObject boxNew;

    private void Start()
    {
        Collider = GetComponent<Collider>();
    }
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
            DesactivateCol();
            StartCoroutine(delayfall());
        }
        tile.selectable = false;
    }

    public void DesactivateAnim()
    {
        _anim.enabled = false;
        Collider.enabled = true;
        tile.selectable = true;
        boxNew.SetActive(false);
    }
    IEnumerator delayfall()
    {
        yield return new WaitForSeconds(0.2f);
        restart.TryAgain();
    }
    void DesactivateCol()
    {
        Collider.enabled = false;
        boxNew.SetActive(true);
    }

    




}
