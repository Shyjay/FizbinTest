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

	float horizontalMove = 0f;
	[SerializeField] float speedModifier;
	[SerializeField] float jumpForce;
	[SerializeField] float runningModifier;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigbod2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
    	//Debug.Log("Velocity: " + rigbod2d.velocity);
    	CheckForInput();
    }

    //Check for Input regarding walk, run and jump (using Horizontal axis which can be setup in project setting Input manager)
    //Standard Input A and D or Left and Right Arrow for walking, space for jumping and left shift key for running
    //Controller Input default setup: left stick = walk movement, B Key (circle for PS) = running, Y Key (triangle for PS) = jumping
    
    private void CheckForJumpAnimation() {
    	if(rigbod2d.velocity.y > 0) {
    		animator.SetInteger("animationState",3);
    	}
    	else if(rigbod2d.velocity.y < 0) {
    		animator.SetInteger("animationState",3);
    	}
    }

    private void CheckForInput() {

    	horizontalMove = Input.GetAxis("Horizontal");

    	if(horizontalMove < 0) {
    		spriteRenderer.flipX = true;
    	}
    	else if(horizontalMove == 0) {
    		animator.SetInteger("animationState",0);
    	}
    	else
    		spriteRenderer.flipX = false;

    	if(isRunning && isGrounded) {
    		rigbod2d.velocity = new Vector2(horizontalMove * speedModifier * runningModifier, rigbod2d.velocity.y);
    		Debug.Log("Use Run Speed");
    		animator.SetInteger("animationState",2);
    	}
    	else {
    		if(isGrounded) {
    			rigbod2d.velocity = new Vector2(horizontalMove * speedModifier, rigbod2d.velocity.y);
    			Debug.Log("Use Walk Speed");
    			animator.SetInteger("animationState",1);
    		}
    	}

        if(Input.GetButtonDown("Jump") && isGrounded) {
        	Debug.Log("Jump around");
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
