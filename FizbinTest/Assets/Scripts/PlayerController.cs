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

	[SerializeField] float speedModifier;
	[SerializeField] float jumpForce;
	Vector2 jumpVector;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigbod2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        jumpVector = new Vector2 (0, jumpForce);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigbod2d.velocity = new Vector2(Input.GetAxis("Horizontal") * speedModifier, rigbod2d.velocity.y);
        if(Input.GetButton("Jump")) {
        	rigbod2d.AddForce(jumpVector, ForceMode2D.Force);
        }
        if(Input.GetKey("space")) {
        	Debug.Log("Jump around");
        	rigbod2d.AddForce(jumpVector, ForceMode2D.Force);
        }
    }

    private void GroundCheck () {
    	if(Physics2D.Linecast(transform.position, groundChecker.position, 1 << LayerMask.NameToLayer("Ground")))
    		isGrounded = true;
    	else 
    		isGrounded = false;
    }
}
