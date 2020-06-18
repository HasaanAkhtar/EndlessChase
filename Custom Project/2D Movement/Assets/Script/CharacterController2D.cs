using System.Runtime.InteropServices;
using UnityEngine;


public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float jumpForce = 400f;                          // Amount of force added when the player jumps.
	[Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;          // Amount of maxSpeed applied to crouching movement. 1 = 100%
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
	[SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask whatIsGround;                          // A mask determining what is ground to the character
	[SerializeField] private Transform groundPos;                           // A position marking where to check if the player is grounded.
	[SerializeField] private Transform m_CeilingCheck;                          // A position marking where to check for ceilings
	[SerializeField] private Collider2D m_CrouchDisableCollider;                // A collider that will be disabled when crouching
	

	int cherryCount;

	private float jumpTimeCounter;
	private float jumpTime;
	private bool isJumping;
	private bool doubleJump;
	// A collider that will be disabled when crouching

	const float chcekRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool isGrounded;            // Whether or not the player is grounded.
	const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
	private Rigidbody2D myRigidBody;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 velocity = Vector3.zero;
	public float speed;
	private Animator anim;



	private void Awake()
	{
		anim = GetComponent<Animator>();
		myRigidBody = GetComponent<Rigidbody2D>();
	
	}


	private void FixedUpdate()
	{
		isGrounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(groundPos.position, chcekRadius, whatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
				isGrounded = true;
		}
	}

    //private void Update()
    //{
	//	//isGrounded = Physics2D.OverlapCircle(groundPos.position, chcekRadius, whatIsGround);
	//	//if (isGrounded == true && Input.GetKeyDown(KeyCode.UpArrow)) 
	//	//{
	//	//	isJumping = true;
	//	//}
	//	//if (Input.GetKeyUp(KeyCode.UpArrow)) 
	//	//{
	//	//	isJumping = false;
	//	//}
	//	//if (isGrounded == false && doubleJump == false && Input.GetKeyDown(KeyCode.UpArrow)) 
	//	//{
	//	//	isJumping = true;
	//	//	doubleJump = true;
	//	//	jumpTimeCounter = jumpTime;
	//	//	myRigidBody.velocity = Vector2.up * jumpForce;
	//	//}
	//	//float moveInput = Input.GetAxisRaw("Horizontal");
	//	//myRigidBody.velocity = new Vector2(moveInput * speed, myRigidBody.velocity.y);
	//	//if (moveInput == 0)
	//	//{
	//	//	anim.SetBool("isRunning", false);
	//	//}
	//	//else 
	//	//{
	//	//	anim.SetBool("isRunning", true);
	//	//}
	//
	//}



    public void Move(float move, bool crouch, bool jump)
	{
		// If crouching, check to see if the character can stand up
		if (!crouch)
		{
			// If the character has a ceiling preventing them from standing up, keep them crouching
			if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, whatIsGround))
			{
				crouch = true;
			}
		}

		//only control the player if grounded or airControl is turned on
		if (isGrounded || m_AirControl)
		{

			// If crouching
			if (crouch)
			{
				// Reduce the speed by the crouchSpeed multiplier
				move *= m_CrouchSpeed;
				anim.SetBool("isCrouching", true);
				// Disable one of the colliders when crouching
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = false;
			} else
			{
				// Enable the collider when not crouching
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = true;
				anim.SetBool("isCrouching", false);
			}

			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f, myRigidBody.velocity.y);
			// And then smoothing it out and applying it to the character
			myRigidBody.velocity = Vector3.SmoothDamp(myRigidBody.velocity, targetVelocity, ref velocity, m_MovementSmoothing);

			// If the input is moving the player right and the player is facing left...
			if (move == 0)
			{
				anim.SetBool("isRunning", false);
			}
			else
			{
				anim.SetBool("isRunning", true);
			}
				if (move > 0 && !m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
		}
		// If the player should jump...
		if (isGrounded && jump)
		{
			// Add a vertical force to the player.
			isGrounded = false;
			myRigidBody.AddForce(new Vector2(0f, jumpForce));
			anim.SetBool("isJumping", true);
        }
        else
        {
			isGrounded = true;
			anim.SetBool("isJumping", false);
        }
		if (Input.GetKeyDown(KeyCode.Space)) 
		{
			doubleJump = true;
			isGrounded = false;
			myRigidBody.AddForce(new Vector2(2f, jumpForce));
			anim.SetBool("isJumping", true);
		}
	}


	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
	void OnTriggerEnter2D(Collider2D triggerCollider)
	{
		if (triggerCollider.tag == "Cherry")
		{
			Destroy(triggerCollider.gameObject);
			
			cherryCount++;
		}
		
	}
  


}
