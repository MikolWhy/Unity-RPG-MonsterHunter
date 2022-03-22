using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgreMovement : MonoBehaviour
{
    public int timer = 0;
    public int direction = 0;
    public float speed = 0.2f;

    private void Start()
    {
        //setting a random starting direction
        int rand = Random.Range(0, 4);
        if (rand == 0)
        {
            direction = 1;
        }
        if (rand == 1)
        {
            direction = 2;
        }
        if (rand == 2)
        {
            direction = 3;
        }
        if (rand == 3)
        {
            direction = 4;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = transform.position;

        //creating a timer to decide when it is time to switch directions
        timer++;
        int rand = Random.Range(0, 4);
        if (timer > 100)
        {
            //changing directions based on a random value
            if (rand == 0)
            {
                direction = 1;
            }
            if (rand == 1)
            {
                direction = 2;
            }
            if (rand == 2)
            {
                direction = 3;
            }
            if (rand == 3)
            {
                direction = 4;
            }
            timer = 0;
        }
        //moving the enemy based on direction
        if (direction == 1)
        {
            pos.x += speed * Time.deltaTime;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (direction == 2)
        {
            pos.y -= speed * Time.deltaTime;
        }
        if (direction == 3)
        {
            pos.x -= speed * Time.deltaTime;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        if (direction == 4)
        {
            pos.y += speed * Time.deltaTime;
        }

        //transforming the ogre's position to it's new one
        transform.position = pos;
    }
}
