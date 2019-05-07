using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	//default unity variables are private if there are no access modifiers specified
	//so they are not used here
	Animator animator;
	Rigidbody2D rigbod2d;
	SpriteRenderer spriteRenderer;

	bool isGrounded;
	bool isRunning;

	[SerializeField] float speedModifier;
	[SerializeField] float jumpForce;
	[SerializeField] float runningModifier;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigbod2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
    	//Debug.Log("Velocity: " + rigbod2d.velocity);
    	CheckForInput();
    }

    //Check for Input regarding walk, run and jump (using Horizontal axis which can be setup in project setting Input manager)
    //Standard Input A and D or Left and Right Arrow for walking, space for jumping and left shift key for running
    //Controller Input default setup: left stick = walk movement, B Key (circle for PS) = running, Y Key (triangle for PS) = jumping
    private void CheckForInput() {
    	if(isRunning && isGrounded) {
    		rigbod2d.velocity = new Vector2(Input.GetAxis("Horizontal") * speedModifier * runningModifier, rigbod2d.velocity.y);
    		Debug.Log("Use Run Speed");
    	}
    	else {
    		if(isGrounded) {
    			rigbod2d.velocity = new Vector2(Input.GetAxis("Horizontal") * speedModifier, rigbod2d.velocity.y);
    			Debug.Log("Use Walk Speed");
    		}
    	}

        if(Input.GetButtonDown("Jump") && isGrounded) {
        	//Debug.Log("Jump around");
        	rigbod2d.velocity = new Vector2(rigbod2d.velocity.x, jumpForce);
        }

        if(Input.GetButton("RunModifier")) {
        	//Debug.Log("Is Running");
        	isRunning = true;
        }
        else {
        	//Debug.Log("Isnt Running");
        	isRunning = false;
    	}
    }

    //Check if player is grounded by collision Checks
    void OnCollisionEnter2D (Collision2D col)
    {
        if(col.gameObject.CompareTag("Ground"))
        {
        	isGrounded = true;
        }
    }

    void OnCollisionStay2D (Collision2D col)
    {
        if(col.gameObject.CompareTag("Ground"))
        {
        	isGrounded = true;
        }
    }

    void OnCollisionExit2D (Collision2D col)
    {
        if(col.gameObject.CompareTag("Ground"))
        {
        	isGrounded = false;
        }
    }
}
