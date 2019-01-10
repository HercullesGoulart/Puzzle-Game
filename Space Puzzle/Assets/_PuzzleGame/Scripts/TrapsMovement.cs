using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsMovement : MonoBehaviour
{
    //speed of the enemy
    public float speed = 3;

    public float rangeY = 2;
    //initial position
    Vector3 initialPos;

    //range of movement y

    int direction = 1;
    // Use this for initialization
    void Start()
    {
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        float factor = 1;

        if (direction == -1)
        {
            factor = 2f;
        }
        //how much are we moving
        float movementY = factor * speed * Time.deltaTime * direction;

        //new position y
        float newY = transform.position.y + movementY;
        //checking whether we've left our range
        if (Mathf.Abs(newY - initialPos.y) > rangeY)
        {
            direction *= -1;
        }
        else
        {
            transform.position += new Vector3(0, movementY, 0);
        }
    }

}

