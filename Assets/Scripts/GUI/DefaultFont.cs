using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]

public class DefaultFont : MonoBehaviour {

	public Font defaultFont;

	void OnGUI() {
		if (!defaultFont) {
			Debug.LogError ("No default font found - Assign a default font in the inspector.");
			return;
		} else {
			GUI.skin.font = defaultFont;
			GUI.skin.box.fontSize = 12;
		}
	}
}