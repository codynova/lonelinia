using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]

public class PlayerWarp : MonoBehaviour {

	public Transform WarpTarget;

	private PlayerMove playerMovement;
	private PlayerBlink playerBlink;
	private FadeScreen screenFader;


	IEnumerator OnTriggerEnter2D(Collider2D other){
		//make a reference to the PlayerMovement and PlayerBlink functions so we can freeze and unfreeze player movement
		playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove> ();
		playerBlink = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBlink> ();
		//make a reference to the ScreenFader so that we can yield to its fade functions in ScreenFader.cs
		screenFader = GameObject.FindGameObjectWithTag ("Fader").GetComponent<FadeScreen> ();

		//prevent player from moving until warp and fade is complete
		disablePlayerMovement ();
		//yield until FadeToBlack has completed before moving the game object
		yield return StartCoroutine (screenFader.fadeToBlack ());
		//move the gameObject which has collided, to the warp target
		other.gameObject.transform.position = WarpTarget.position;
		Camera.main.transform.position = WarpTarget.position;
		//yield until FadeToClear has completed before allowing player to move again
		yield return StartCoroutine (screenFader.fadeToClear ());
		enablePlayerMovement ();
	}

	private void disablePlayerMovement () {
		playerBlink.disablePlayerBlink ();
		playerMovement.disablePlayerMovement ();
	}

	private void enablePlayerMovement () {
		playerMovement.enablePlayerMovement ();
		playerBlink.enablePlayerBlink ();
	}
}