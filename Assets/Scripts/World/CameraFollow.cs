using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	private float cameraFollowDampening = 0.15f;
	public Transform PlayerTarget;
	Vector3 cameraDistance = new Vector3 (0f, 0f, -10f);
	private Vector3 velocity = Vector3.one;
	Camera playerCamera;
	private Transform cachedTransform;

	void Start () {
		playerCamera = GetComponent<Camera> ();
		//cache the transform
		cachedTransform = transform;
	}

	void LateUpdate() {
		//maintains the aspect ratio of the game on different screen resolutions
		playerCamera.orthographicSize = (Screen.height / 100f) / 0.5f;		
		if (PlayerTarget) {
			Vector3 movetoPosition = PlayerTarget.position + (PlayerTarget.rotation * cameraDistance);
			Vector3 currentPosition = Vector3.SmoothDamp (cachedTransform.position, movetoPosition, ref velocity, cameraFollowDampening);
			cachedTransform.position = currentPosition;
		}
	}

}