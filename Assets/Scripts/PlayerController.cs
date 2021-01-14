using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    private bool canMove;
    private Rigidbody2D theRB2D;

    //Variables for jumping
    public float jumpForce;
    public bool grounded;
    public LayerMask whatIsGrd;
    public Transform grdChecker;
    public float grdCheckerRad;
    public float airTime;
    public float airTimeCounter;

    //Variables for animations
    private Animator theAnimator;

    //Dash variables
    public float dashForce;

    void Start() {
        theRB2D = GetComponent<Rigidbody2D>();
        theAnimator = GetComponent<Animator>();

        airTimeCounter = airTime;
    }

    
    void Update() {
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f) {
            canMove = true;
        }

    }

    private void FixedUpdate() {
        grounded = Physics2D.OverlapCircle(grdChecker.position, grdCheckerRad, whatIsGrd);
        
            
        MovePlayer();
        Jump();

         
    }

    void MovePlayer() {
        if (canMove) {
            theRB2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, theRB2D.velocity.y);
            
            theAnimator.SetFloat("Speed", Mathf.Abs(theRB2D.velocity.x));

            if (theRB2D.velocity.x > 0) {
                transform.localScale = new Vector2(1f, 1f);
            }
            else if (theRB2D.velocity.x < 0) {
                transform.localScale = new Vector2(-1f, 1f);
            }
        }
    }

    void Jump() {
        if (grounded == true) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                theRB2D.velocity = new Vector2(theRB2D.velocity.x, jumpForce);
            }
        }
        
              
        if (Input.GetKey(KeyCode.Space)) {
            if(airTimeCounter > 0) {
                theRB2D.velocity = new Vector2(theRB2D.velocity.x, jumpForce);
                airTimeCounter -= Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space)) {
            airTimeCounter = 0;
        }

        if (grounded) {
            airTimeCounter = airTime;
        }
        
        theAnimator.SetBool("Grounded", grounded);

    }

    /*
    void Dash() {
        dashForce = 100f;
        if (Input.GetKeyDown(KeyCode.R)) {
            theRB2D.velocity = new Vector2(theRB2D.position.x + dashForce, theRB2D.position.y);
        }
    }



   void Teleport(){
    
        if (Input.GetKeyDown(KeyCode.Tab)) {
            
            Vector2 tp = new Vector2(-1 * theRB2D.position.x, -1 * theRB2D.position.y);
            theRB2D.MovePosition(tp);
        }
            
    }
    */

}
