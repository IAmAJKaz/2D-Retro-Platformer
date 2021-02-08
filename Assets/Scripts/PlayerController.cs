using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //Movement Variables
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

    //Spring Variables
    public bool spring;
    public LayerMask whatIsSpr;

    //teleport variables
    public bool teleport;
    public LayerMask whatIsTele;

    /*//Ceiling Variables
    public bool ceiling;
    public LayerMask whatIsCei;
    public Transform ceiChecker;
    public float ceiCheckerRad;*/

    public GameManager theGM;
    private LivesManager theLM;

    void Start() {
        theRB2D = GetComponent<Rigidbody2D>();
        theAnimator = GetComponent<Animator>();
        theLM = FindObjectOfType<LivesManager>();

        airTimeCounter = airTime;

    }

    
    void Update() {
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f) {
            canMove = true;
        }

        if (spring) {
            theRB2D.velocity = new Vector2(theRB2D.velocity.x, 50);
        }
        
        if (teleport) {
            Vector2 teleportPosition = new Vector2(10f, 3f);
            theRB2D.MovePosition(teleportPosition);
        }

    }

    private void FixedUpdate() {
        grounded = Physics2D.OverlapCircle(grdChecker.position, grdCheckerRad, whatIsGrd);
        spring = Physics2D.OverlapCircle(grdChecker.position, grdCheckerRad, whatIsSpr);
        teleport = Physics2D.OverlapCircle(grdChecker.position, grdCheckerRad, whatIsTele);
        //ceiling = Physics2D.OverlapCircle(ceiChecker.position, ceiCheckerRad, whatIsCei);

        MovePlayer();
        Jump();
   
    }

    void MovePlayer() {
        if (canMove) {  // && !ceiling
            theRB2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, theRB2D.velocity.y);
            
            theAnimator.SetFloat("Speed", Mathf.Abs(theRB2D.velocity.x));

            if (theRB2D.velocity.x > 0) {
                transform.localScale = new Vector2(1f, 1f);
            }
            else if (theRB2D.velocity.x < 0) {
                transform.localScale = new Vector2(-1f, 1f);
            }
        }

        /*//ceiling walking flip statement
        else if (ceiling) {
            theRB2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, theRB2D.velocity.y);
            theAnimator.SetFloat("Speed", Mathf.Abs(theRB2D.velocity.x));
            Physics2D.gravity = new Vector2(0, 0);
            if (theRB2D.velocity.x > 0) {
                transform.localScale = new Vector2(1f, -1f);
            }
            else if (theRB2D.velocity.x < 0) {
                transform.localScale = new Vector2(-1f, -1f);
            } 
        }*/
    }

    void Jump() {

       /* if (ceiling) {
            if (Input.GetKeyDown(KeyCode.Space)){
                theRB2D.velocity = new Vector2(theRB2D.velocity.x, -jumpForce);
                Physics2D.gravity = new Vector2(0, -9.8f);
            } 
        }*/

        if (grounded) {
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

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Spike") {
            Debug.Log("Ouch!");
            //theGM.GameOver();
            theGM.Reset();
            theLM.TakeLife();
        }
    }


}
