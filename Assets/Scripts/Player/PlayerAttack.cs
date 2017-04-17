using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]

public class PlayerAttack : MonoBehaviour {

	private KeyCode keyboardAttack = KeyCode.Mouse0;
	private KeyCode controllerAttack = KeyCode.JoystickButton2;

	private float attackRange = 2;

	private Rigidbody2D playerBody;
	private Transform cachedTransform;
	private Vector2 playerMovementVector = new Vector2(1, 1); //default of facing down
	private Vector2 playerFacingDirection;

	private GameObject enemyGameObject;
	private Transform attackTarget;
	private EnemyHealth enemyHealth;


	void Start () {
		playerBody = GetComponent<Rigidbody2D> ();
		cachedTransform = transform;

		enemyGameObject = GameObject.FindGameObjectWithTag ("Enemy");
		attackTarget = enemyGameObject.transform;
		enemyHealth = (EnemyHealth)attackTarget.GetComponent ("EnemyHealth");
	}



	void Update () {
		playerMovementVector = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		if (playerMovementVector != Vector2.zero) {
			playerFacingDirection = playerMovementVector;
		}

		if (Input.GetKeyUp (keyboardAttack) || Input.GetKeyUp (controllerAttack)) {
			Attack ();
		}
	}


	private void Attack() {

		//		// Old raycasting solution, using trigger/collider now?
		//		float distanceFromTarget = Vector2.Distance (attackTarget.position, cachedTransform.position);
		//		Vector2 targetDirectionVector = (attackTarget.position - cachedTransform.position).normalized;
		//		float facingTarget = Vector2.Dot (targetDirectionVector, playerFacingDirection);
		//		if (distanceFromTarget < attackRange) {
		//			enemyHealth.changeEnemyCurrentHealth (-10);
		//		}

	}
}