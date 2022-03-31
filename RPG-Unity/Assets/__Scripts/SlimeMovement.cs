using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    //data fields for the player, rigidbody, and movement speed
    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float moveSpeed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        //getting the rigidbody component of the enemy
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //getting direction from distance of player and enemy
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        //calling method to move enemy towards player
        moveCharacter(movement);
    }

    //method to make the enemy move towards the player
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}