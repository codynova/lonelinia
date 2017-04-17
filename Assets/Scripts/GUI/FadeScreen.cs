using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]

public class FadeScreen : MonoBehaviour {

	Animator screenFadeAnim;
	bool screenIsFading = false;



	void Awake () {
	}

	void Start () {
		screenFadeAnim = GetComponent<Animator> ();
	}

	public IEnumerator fadeToClear() {
		screenIsFading = true;
		screenFadeAnim.SetTrigger ("fadeIn");
		// Wait to return until fade is complete
		while (screenIsFading) yield return null;
	}

	public IEnumerator fadeToBlack() {
		screenIsFading = true;
		screenFadeAnim.SetTrigger ("fadeOut");
		// Wait to return until fade is complete
		while (screenIsFading) yield return null;
	}

	void AnimationComplete() {
		screenIsFading = false;
	}
}