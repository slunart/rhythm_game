using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMovement))]
public class CharacterClickControl : MonoBehaviour {
	private const int MOUSE_LEFT = 0;
	private bool followingClick;
	private Vector2 clickPosition;
	private Camera camera;
	private CharacterMovement movement;

	void Awake () {
		movement = GetComponent<CharacterMovement>();
		camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
	}
	
	void Update () {
		if (Input.GetMouseButtonDown (MOUSE_LEFT) && !clickingButtons()) {
			followingClick = true;

			clickPosition = ((Vector2)Input.mousePosition * 2 - new Vector2(Screen.width, Screen.height))
				* camera.orthographicSize / Screen.height + (Vector2)transform.position;
			movement.Move((clickPosition - (Vector2)transform.position));
		}
		if (followingClick) {
			followingClick = ((clickPosition - (Vector2)transform.position).magnitude > 0.2f);
		} else movement.Move(Vector2.zero);
	}

	bool clickingButtons() {
		return false;
	}
}
