using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : TacticsMove
{
    TacticsMove tacticsmove;
    Tile tile;
    // Use this for initialization
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward);

        if (!turn)
        {
            //return;
            FindSelectableTiles();
            CheckMouse();
        }

        if (!moving)
        {
            FindSelectableTiles();
            CheckMouse();
        }
        else
        {
            Move();
        }

    }

    void CheckMouse()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Tile")
                {
                    Tile t = hit.collider.GetComponent<Tile>();

                    if (t.selectable)
                    {
                        MoveToTile(tile);
                        Debug.Log("predefinido");
                    }
                }
            }
        }


    }
    public void MoveUp()
    {

        
        //Tile tile = 
        //MoveToTile(tile);

        
        Debug.Log("teste up");
    }
    public void MoveDown()
    {
        //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
        //Debug.Log("teste down");
    }
    public void MoveLeft()
    {
        //transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
        //Debug.Log("teste left");
    }
    public void MoveRight()
    {
        //transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
        //Debug.Log("teste right");
    }
    public void CheckTile(Vector3 direction, float jumpHeight, Tile target)
    {
        Vector3 halfExtents = new Vector3(0.25f, (1 + jumpHeight) / 2.0f, 0.25f);
        Collider[] colliders = Physics.OverlapBox(transform.position + direction, halfExtents);

        foreach (Collider item in colliders)
        {
            Tile tile = item.GetComponent<Tile>();
            if (tile != null && tile.walkable)
            {
                RaycastHit hit;

                if (!Physics.Raycast(tile.transform.position, Vector3.up, out hit, 1) || (tile == target))
                {
                    tile.adjacencyList.Add(tile);
                }
            }
        }
    }
}
