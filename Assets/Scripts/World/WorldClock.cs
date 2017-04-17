using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class WorldClock : MonoBehaviour {

	private const float SECOND = 1;
	private const float MINUTE = 60 * SECOND;
	private const float HOUR = 60 * MINUTE;
	private const float DAY = 24 * HOUR;

	public float DayCycleInMinutes = 5;
	private const float degreesPerSecond = 360 / DAY;
	private float timeOfDay;
	private float degreeRotation;
	private RectTransform clock;
	public Transform[] Suns;

	// Use this for initialization
	void Start () {
		clock = GetComponent<RectTransform> ();
		timeOfDay = 0;
		degreeRotation = degreesPerSecond * (DAY / (DayCycleInMinutes * MINUTE));
	}

	// Update is called once per frame
	void Update () {
		clock.Rotate (new Vector3(0, 0, degreeRotation) * Time.deltaTime);
		foreach (Transform sun in Suns) {
			sun.Rotate (new Vector3 (degreeRotation, 0, 0) * Time.deltaTime);
		}
		timeOfDay += Time.deltaTime;
	}
}