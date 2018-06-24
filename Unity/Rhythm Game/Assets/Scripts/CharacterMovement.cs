using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement : MonoBehaviour {
	[SerializeField] private float speed = 1f;
	private Rigidbody2D rb;

	void Awake() {
		rb = GetComponent<Rigidbody2D> ();
	}

	public void Move(Vector2 direction) {
		rb.velocity = direction * speed;
		if (direction.magnitude > 0.01)
			transform.rotation = Quaternion.LookRotation(Vector3.back, direction);
	}
}
