using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

	private Rigidbody2D enemyBody;
	private GameObject playerGameObject;
	private Transform attackTarget;
	private float moveSpeed = 2800f;
	private int noticeSpeed;
	private Vector2 movementVector;



	void Awake() {
		enemyBody = GetComponent<Rigidbody2D> ();
		playerGameObject = GameObject.FindGameObjectWithTag ("Player");
		attackTarget = playerGameObject.transform;
	}

	void Start () {
	}

	void Update () {
		Debug.DrawLine (attackTarget.position, enemyBody.position, Color.cyan);
		movementVector = (Vector2)attackTarget.position - enemyBody.position;
		movementVector = movementVector.normalized;
	}

	void FixedUpdate () {
		enemyBody.AddForce (movementVector * moveSpeed * Time.deltaTime);
	}
}
