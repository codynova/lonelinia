using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]

public class PlayerMove : MonoBehaviour {

	private KeyCode keyboardRun = KeyCode.LeftShift;
	private float controllerRunInput;

	private Rigidbody2D playerBody;
	private Animator playerMoveAnim;

	private bool playerRootedStatus = false;
	private Vector2 movementVector;
	private bool movingInput;
	private bool runningInput;

	private float moveSpeed = 8000f;
	private float walkSpeed = 8000f;
	private float runSpeed = 14000f;
	private float diagonalSpeedHack = 0.85f;




	void Awake () {
		playerBody = GetComponent<Rigidbody2D> ();
		playerMoveAnim = GetComponent<Animator> ();
	}

	void Start () {
	}

	void Update () {
		if (!playerRootedStatus) {
			getPlayerMovementInput ();
			if (movingInput) {
				startPlayerMovementAnimation ();
				setPlayerMovementSpeed ();
			} else {
				stopPlayerMovementAnimation ();
			}
		} else {
			stopPlayerMovementAnimation ();
		}
	}

	void FixedUpdate() {
		if (!playerRootedStatus && movingInput) setPlayerMovementValue ();
	}





	public void disablePlayerMovement () {
		playerRootedStatus = true;
	}

	public void enablePlayerMovement () {
		playerRootedStatus = false;
	}

	private void getPlayerMovementInput () {
		movementVector = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		movingInput = (movementVector != Vector2.zero) ? true : false;
		controllerRunInput = Input.GetAxisRaw ("RightTrigger");
		runningInput = (Input.GetKey (keyboardRun) || controllerRunInput > 0) ? true : false;
	}

	private void startPlayerMovementAnimation () {
		playerMoveAnim.SetBool ("moving", movingInput);
		playerMoveAnim.SetBool ("running", runningInput);
		// Sets which animation plays from the blend tree
		// (i.e. which direction the player is facing: N,S,E,W,NE,NW,SE,SW)
		playerMoveAnim.SetFloat ("inputX", movementVector.x);
		playerMoveAnim.SetFloat ("inputY", movementVector.y);
	}

	private void stopPlayerMovementAnimation () {
		playerMoveAnim.SetBool ("moving", false);
		playerMoveAnim.SetBool ("running", false);
	}

	private void setPlayerMovementSpeed () {
		moveSpeed = runningInput ? runSpeed : walkSpeed;
		// TODO: hack to fix diagonal movespeed, normalize vector movement to solve
		if (movementVector.x != 0 && movementVector.y != 0) {
			moveSpeed = moveSpeed * diagonalSpeedHack;
		}
	}

	private void setPlayerMovementValue () {
		playerBody.AddForce (movementVector * moveSpeed * Time.deltaTime);
	}

}