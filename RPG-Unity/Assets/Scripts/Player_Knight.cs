using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//manually puts a box collider on every character object (might fix errors later)
//[RequireComponent(typeof(BoxCollider2D))]
public class Player_Knight : MonoBehaviour
{
    //creating the dashLayerMask
    [SerializeField] private LayerMask dashLayerMask;
    //dash variables (new)
     private const float MOVE_SPEED = 1f;



    //declaring a field for casting player collider box for on-hit collisions (was movedir)
    private Vector3 moveDelta;
    private Vector3 moveDir;
    
    //indication variable keeping track of key input
    private bool isDashButtonDown;



    //private fields
    // the difference between the rendering frame and the next one (player positions)
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;



    //variable for box casting and collisions
    private RaycastHit2D hit;
    // Start is called before the first frame update and only once

    //Dash Movement - move into seperate class for diff characters if can
    private float dashCounter;
    public float dashSpeed;

   public float moveSpeed;

    private float dashCoolCounter;


    //move to Awake() ?
    private void Start()
    {
        //sets boxCollider variable through BoxCollider2D component 
        //unity notes: Just added 2D-Box Collider and cropped the character's assigned collider range (what part of the character body will interact with objects) to just the centre square (ignoring the helment fluff and feet)
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    //after the first frame update (every frame)
    private void Update(){
        //keep rotation at 0 (fixes player eratic error)
         rb.SetRotation(0);
        //vector that keeps track of the delta movement



        //looks for the inputs on the keyboard and loads them into the x and y vectors - can check values for each key press in (edit > project settings > input manager)
        // x and y variables are declared
        //float moveX = 0f;
        //float moveY = 0f;
        float x = Input.GetAxisRaw("Horizontal")/2;
        float y = Input.GetAxisRaw("Vertical")/2;

         //reset MoveDelta at the begining
        //moveDelta = Vector3.zero; (old)
        //now when creating a vector, it will be reset
        moveDelta = new Vector3(x, y, 0);
        moveDir = new Vector3(x, y).normalized;

/**
        if (Input.GetKey(KeyCode.W)) {
            moveDelta.y = +1f;
        }
        if (Input.GetKey(KeyCode.S)) {
            moveDelta.y = -1f;
        }
        if (Input.GetKey(KeyCode.A)) {
            moveDelta.x = -1f;
        }
        if (Input.GetKey(KeyCode.D)) {
            moveDelta.x = +1f;
        }
**/
        if (Input.GetKeyDown(KeyCode.Space)) {
            isDashButtonDown = true;
        }
    }
     

    //fixed update for manual collision + etc (if looking for inputs, fixed update may skip some in rare cases, check back to this function in case of error) (took out private async void)
    private void FixedUpdate()
    {

        //testing x and y inputs through console log and running
        //Debug.Log(x);
        //Debug.Log(y);

         //rb.velocity = moveDelta * moveSpeed;

        //swap sprite direction based on right or left movement
        if (moveDelta.x > 0)
            transform.localScale = Vector3.one;

        else if (moveDelta.x < 0)
            //y and z transform remain same but x value is -1
            transform.localScale = new Vector3(-1, 1, 1);


        rb.velocity = moveDir * MOVE_SPEED;

        if (isDashButtonDown) {
            float dashAmount = 0.5f;
            Vector3 dashPosition = transform.position + moveDir * dashAmount;

            RaycastHit2D raycastHit2d = Physics2D.Raycast(transform.position, moveDir, dashAmount, dashLayerMask);
            if (raycastHit2d.collider != null) {
                dashPosition = raycastHit2d.point;
            }

            // Spawn visual effect
            //DashEffect.CreateDashEffect(transform.position, moveDir, Vector3.Distance(transform.position, dashPosition));

            rb.MovePosition(dashPosition);
            isDashButtonDown = false;
        }
        /**
        //BOX CAST (current transform position, boxCollider Size, Angle, y axis, distance in absolute value as you wouldn't want a negative value in terms with Time, usually result but will be using layer mask to test what layer its on ): 
        //make sure movement is possible in this direction (Y AXIS) by casting a box there first, if box returns null, movement is allowed
        hit = Physics2D.BoxCast(transform.position,boxCollider.size,0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        
        //no-collision; free movement
        if (hit.collider == null){
        //player movement - delta time for consistency of speed on varying devices (accounting for slower and faster devices)
        transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

                
        //BOX CAST (current transform position, boxCollider Size, Angle, y axis, distance in absolute value as you wouldn't want a negative value in terms with Time, usually result but will be using layer mask to test what layer its on ): 
        //make sure movement is possible in this direction (X AXIS0) by casting a box there first, if box returns null, movement is allowed
        hit = Physics2D.BoxCast(transform.position,boxCollider.size,0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        
        //no-collision; free movement
        if (hit.collider == null){
        //player movement - delta time for consistency of speed on varying devices (accounting for slower and faster devices)
        transform.Translate(moveDelta.x * Time.deltaTime,0, 0);
        }
        **/

   /**if (Input.GetKeyDown(KeyCode.Space)) {
            //isDashButtonDown = true;

            isDashing = true;
            currentDashTimer = startDashTimer;
            rb.velocity = Vector2.zero;
            dashDirection = (int)moveDelta.x;
        }
        if (isDashing){
            rb.velocity = transform.right * dashDirection * dashForce;

            currentDashTimer -= Time.deltaTime;
            
            if(currentDashTimer <= 0){
                isDashing = false;
            }
            **/
        }
    }