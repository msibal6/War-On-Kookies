using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed;
	private Rigidbody2D rb2d; 
	private Animator animator;


	// Use this for initialization
	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.freezeRotation = true;
		animator = this.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{

		var vertical = Input.GetAxis("Vertical");
		var horizontal = Input.GetAxis("Horizontal");

		if (vertical > 0)
		{
			animator.SetInteger("Direction", 2);
		}
		else if (vertical < 0)
		{
			animator.SetInteger("Direction", 0);
		}
		else if (horizontal > 0)
		{
			animator.SetInteger("Direction", 3);
		}
		else if (horizontal < 0)
		{
			animator.SetInteger("Direction", 1);
		}
	}
	void FixedUpdate()
	{
		//Store the current horizontal input in the float moveHorizontal.
		float moveHorizontal = Input.GetAxis ("Horizontal");

		//Store the current vertical input in the float moveVertical.
		float moveVertical = Input.GetAxis ("Vertical");

		//Use the two store floats to create a new Vector2 variable movement.
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

		//Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
		rb2d.AddForce (movement * speed);
	}


}
