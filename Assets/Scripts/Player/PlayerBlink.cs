using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]

public class PlayerBlink : MonoBehaviour {

	private KeyCode keyboardDashBlink = KeyCode.Space;
	private KeyCode controllerDashBlink = KeyCode.JoystickButton0;
	private KeyCode keyboardTargetBlink = KeyCode.R;
	private KeyCode controllerTargetBlink = KeyCode.JoystickButton3;
	private KeyCode keyboardCancelBlink = KeyCode.F;
	private KeyCode controllerCancelBlink = KeyCode.JoystickButton1;

	private Rigidbody2D playerBody;
	private GameObject blinkIndicator;

	private Vector2 dashLength = new Vector2(8, 8);
	private bool preventPlayerBlink = false;
	private bool dashBlinkInput = false;
	private bool targetBlinkInput = false;
	private bool cancelBlinkInput = false;
	private bool blinkTargetExists = false;
	private Vector2 blinkTargetVector;
	private Vector2 movementVector;




	void Awake () {
		playerBody = GetComponent<Rigidbody2D> ();
		blinkIndicator = GameObject.FindGameObjectWithTag("BlinkIndicator");
	}

	void Start () {
	}

	void Update () {
		movementVector = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		if (!preventPlayerBlink) {
			getPlayerBlinkInput();
			if (dashBlinkInput) dashBlink();
			if (targetBlinkInput) {
				if (!blinkTargetExists) {
					setBlinkTarget();
				} else {
					blinkToTarget();
				}
			} else if (cancelBlinkInput) if (blinkTargetExists) eraseBlinkTarget();
		}
	}

	void FixedUpdate () {
	}





	public void disablePlayerBlink () {
		preventPlayerBlink = true;
	}

	public void enablePlayerBlink () {
		preventPlayerBlink = false;
	}

	private void getPlayerBlinkInput (){
		dashBlinkInput = (Input.GetKeyUp (keyboardDashBlink) || Input.GetKeyUp (controllerDashBlink)) ? true : false;
		targetBlinkInput = (Input.GetKeyUp (keyboardTargetBlink) || Input.GetKeyUp (controllerTargetBlink)) ? true : false;
		cancelBlinkInput = (Input.GetKeyUp (keyboardCancelBlink) || Input.GetKeyUp (controllerCancelBlink)) ? true : false;
	}

	private void blinkToTarget () {
		playerBody.position = blinkTargetVector;
		eraseBlinkTarget();
	}

	private void setBlinkTarget () {
		blinkTargetVector = playerBody.position;
		blinkTargetExists = true;
		drawBlinkTarget();
	}

	private void drawBlinkTarget () {
		blinkIndicator.transform.position = blinkTargetVector;
		blinkIndicator.GetComponent<Renderer>().enabled = true;
	}

	private void eraseBlinkTarget () {
		blinkTargetExists = false;
		blinkIndicator.GetComponent<Renderer>().enabled = false;
	}

	private void dashBlink () {
		movementVector.x = movementVector.x * dashLength.x;
		movementVector.y = movementVector.y * dashLength.y;
		playerBody.position = playerBody.position + movementVector;
		//playerBody.AddForce (movementVector * 30000f * Time.deltaTime);
	}

}