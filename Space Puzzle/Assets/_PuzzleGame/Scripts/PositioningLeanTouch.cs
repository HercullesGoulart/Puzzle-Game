using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositioningLeanTouch : MonoBehaviour
{
    public Collider pos;
    public TacticsMove move;
    public GameObject player;
    // Use this for initialization
    void Start()
    {
        pos = GetComponent<Collider>();
    }
    private void Update()
    {
        transform.position = player.transform.position;
    }

    public void GetTile()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit))
        {
            Tile touch = hit.transform.GetComponent<Tile>();

            if (touch.selectable)
            {
                move.MoveToTile(touch);

            }

        }


    }

    public void MoveUp()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
        GetTile();
    }
    public void MoveDown()
    {

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
        GetTile();
    }
    public void MoveLeft()
    {
        transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
        GetTile();
    }
    public void MoveRight()
    {
        transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
        GetTile();
    }
}
