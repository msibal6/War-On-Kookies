using UnityEngine;
using System.Collections;

public class CookieSpawn : MonoBehaviour {
	
	public GameObject[] Cookies;


	void Start() {
//		Cookies = GameObject.FindGameObjectsWithTag("Cookie");
		// Set all cookies to be invisible
		SetAllCookiesInvisible ();

		// Now set one random cookie to be visible
		SetOneCookieVisible ();

	}

	void OnTriggerEnter2D(Collider2D other) {
		
		if(other.gameObject.CompareTag("target") && PlayerController.kookieCount>0){
			// Set all cookies to be invisible
			SetAllCookiesInvisible ();

			// Now set one random cookie to be visible
			SetOneCookieVisible ();

		}

	}

	void SetAllCookiesInvisible() {
		foreach (GameObject cookie in Cookies) {
			cookie.SetActive(false);
		}
	}

	void SetOneCookieVisible() {

		// Generate random number in [0, 3]s
		int index = Random.Range(0, Cookies.Length);

		// Set the cookie at that index to be visible
		GameObject cookie = Cookies[index];
		cookie.SetActive(true);
	}

}