using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMovement))]
public class CharacterControl : MonoBehaviour {
	private const int MOUSE_LEFT = 0;
	private bool followingClick;
	private Vector3 clickDirection;
	private Camera camera;
	private CharacterMovement movement;

	// Use this for initialization
	void Awake () {
		movement = GetComponent<CharacterMovement>();
		camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (MOUSE_LEFT) && !clickingButtons()) {
			followingClick = true;

			clickDirection = new Vector3 (2 * Input.mousePosition.x / Screen.width,
				2 * Input.mousePosition.y / Screen.height, -1f) + Vector3.down + Vector3.left;
			clickDirection.x *= (camera.orthographicSize * (float)Screen.width / Screen.height);
			clickDirection.y *= camera.orthographicSize;
			clickDirection += transform.position;
		}
		if (followingClick) {
			if ((clickDirection - transform.position).magnitude <= 0.2f) followingClick = false;
			movement.Move((clickDirection - transform.position).normalized);
		} else {
			movement.Move(Vector2.zero);
		}
	}

	bool clickingButtons() {
		return false;
	}
}
