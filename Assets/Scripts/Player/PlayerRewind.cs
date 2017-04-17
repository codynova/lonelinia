using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]

public class PlayerRewind : MonoBehaviour {

	private KeyCode keyboardRewind = KeyCode.R;
	private KeyCode controllerRewind = KeyCode.R;

	private Rigidbody2D playerBody;
	//TODO: rewrite to use generic array with max length 19-20ish
	private List<Vector2> playerMovements = new List<Vector2>();
	private int movementIndex = 0;
	private bool rewindMovement;
	private PlayerMove playerMovement;
	private Vector2 previousPlayerPosition;
	private Vector2 currentPlayerPosition;
	private float distancePlayerTraveled;

	void Awake() {
		playerBody = GetComponent<Rigidbody2D> ();
		playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove> ();
	}

	void Start () {
		previousPlayerPosition = playerBody.position;
		playerMovements.Add (previousPlayerPosition);
		movementIndex++;
	}

	void Update () {
		currentPlayerPosition = playerBody.position;
		distancePlayerTraveled = Vector2.Distance(currentPlayerPosition, previousPlayerPosition);
		if (!rewindMovement && distancePlayerTraveled > 1) {
			previousPlayerPosition = currentPlayerPosition;
			if (playerMovements.Count > 19) playerMovements.RemoveAt(0);
			playerMovements.Add(playerBody.position);
			movementIndex++;
		}
		if (movementIndex > playerMovements.Count - 1) movementIndex = playerMovements.Count;
		rewindMovement = (Input.GetKey (keyboardRewind) || Input.GetKey (controllerRewind)) ? true : false;
	}

	void FixedUpdate() {
		if (rewindMovement) rewindPlayerMovements();
	}



	private void rewindPlayerMovements() {
		playerMovement.disablePlayerMovement();
		movementIndex--;
		if (movementIndex > 0) {
			Vector2 playerPastMovement = (Vector2)playerMovements [movementIndex];
			Vector2 movementVector = playerPastMovement - playerBody.position;
			playerBody.MovePosition (playerBody.position + movementVector * Time.deltaTime * 8f);
			playerMovements.RemoveAt (movementIndex);
		} else {
			movementIndex = 0;
		}
		playerMovement.enablePlayerMovement();
	}
}