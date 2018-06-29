using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement : MonoBehaviour {
	[SerializeField] private float speed = 1f;
	private Rigidbody2D rb;
	private Animator animator;

	void Awake() {
		rb = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator>();
	}

	public void Move(Vector2 direction) {
		rb.velocity = direction.normalized * speed;
		if (direction.magnitude > 0.01) {
			rb.MoveRotation(Vector2.SignedAngle(Vector2.right, direction));
			animator.SetBool("walking", true);
		} else animator.SetBool("walking", false);
	}

	void OnCollisionEnter2D(Collision2D col) {
		transform.position = transform.position + (Vector3)col.relativeVelocity * .02f;
        Move(Vector2.zero);
    }
}
