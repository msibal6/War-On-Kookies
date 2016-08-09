using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public Text loseText;
	private GameObject[] deliveries;
	private Rigidbody2D rb2d; 
	private Animator animator;
	private int kookieCount;


	// Use this for initialization
	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
		rb2d.freezeRotation = true;
		kookieCount = 0;
		animator = this.GetComponent<Animator>();
		loseText.text = "";
	}

	// Update is called once per frame
	void Update()
	{

		var vertical = Input.GetAxis("Vertical");
		var horizontal = Input.GetAxis("Horizontal");

		if (vertical == 0 && horizontal==0 ) 
		{
			animator.SetInteger("Direction", 4);
		}
		else if (vertical > 0)
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
		rb2d.AddForce (movement*speed*4);
	} 

	void OnTriggerEnter2D(Collider2D other)
	{
		//Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
		if (other.gameObject.CompareTag ("PickUp")){

			//... then set the other object we just collided with to inactive.
			other.gameObject.SetActive (false);
			//Add one to the current value of our count variable.
			kookieCount++;

		}
		if (other.gameObject.CompareTag ("GirlScout")) {
			if (kookieCount > 0) 
			{
				other.gameObject.SetActive (false);
				kookieCount--;

			}
		}
	
	}
	//This controls what happens when you collide with an agent chasing you.
	void OnCollisionEnter2D(Collision2D col)
		{
		if (col.gameObject.tag == "Chaser") {
			loseText.text = "You got caught by your own peers! You lose, you crooked fool!";
			Time.timeScale = 0;
		

		}

		}
	}






