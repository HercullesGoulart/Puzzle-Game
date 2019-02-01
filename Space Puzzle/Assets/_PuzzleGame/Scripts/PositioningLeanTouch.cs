using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositioningLeanTouch : MonoBehaviour
{
    Collider pos;
    TacticsMove move;

    // Use this for initialization
    void Start()
    {
        pos = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        FindTile();
    }
    public void FindTile()
    {
        if (pos.tag == "Tile")
        {
            Tile t = pos.GetComponent<Tile>();

            if (t.selectable)
            {
                move.MoveToTile(t);


            }
        }
    }
    public void MoveUp()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
        Debug.Log("teste up");
        FindTile();
        

    }
    public void MoveDown()
    {

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
        Debug.Log("teste down");
        FindTile();
    }
    public void MoveLeft()
    {
        transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
        Debug.Log("teste left");
        FindTile();
    }
    public void MoveRight()
    {
        transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
        Debug.Log("teste right");
        FindTile();
    }
}
