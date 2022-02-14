using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//manually puts a box collider on every character object (might fix errors later)
//[RequireComponent(typeof(BoxCollider2D))]
public class Player_Knight : MonoBehaviour
{

    //private fields
    // the difference between the rendering frame and the next one (player positions)
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;

    private Vector3 moveDelta;
    // Start is called before the first frame update and only once
    private void Start()
    {
        //sets boxCollider variable through BoxCollider2D component 
        //unity notes: Just added 2D-Box Collider and cropped the character's assigned collider range (what part of the character body will interact with objects) to just the centre square (ignoring the helment fluff and feet)
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    //after the first frame update (every frame)

    //fixed update for manual collision + etc (if looking for inputs, fixed update may skip some in rare cases, check back to this function in case of error)
    private void FixedUpdate()
    {
        rb.SetRotation(0);
        //vector that keeps track of the delta movement

        //looks for the inputs on the keyboard and loads them into the x and y vectors - can check values for each key press in (edit > project settings > input manager)
        // x and y variables are declared
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //reset MoveDelta at the begining
        //moveDelta = Vector3.zero; (old)
        //now when creating a vector, it will be reset
        moveDelta = new Vector3(x, y, 0);

        //testing x and y inputs through console log and running
        //Debug.Log(x);
        //Debug.Log(y);

        //swap sprite direction based on right or left movement
        if (moveDelta.x > 0)
            transform.localScale = Vector3.one;

        else if (moveDelta.x < 0)
            //y and z transform remain same but x value is -1
            transform.localScale = new Vector3(-1, 1, 1);

        //player movement - delta time for consistency of speed on varying devices (accounting for slower and faster devices)
        transform.Translate(moveDelta * Time.deltaTime);

    }
}
