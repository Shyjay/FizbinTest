using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	Animator animator;
	Rigidbody2D rigbod2d;
	SpriteRenderer spriteRenderer;
	[SerializeField] Transform groundChecker;
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
