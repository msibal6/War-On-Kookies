using UnityEngine;
using System.Collections;

public class CookieScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		// Set this cookie to be invisible
		if (other.gameObject.CompareTag ("target")) {
			PlayerController.kookieCount++;
			SetGameObjectInvisible ();
		}
	}

	void SetGameObjectInvisible() {
		gameObject.SetActive (false);
	}
}