using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
/// <summary>
/// Código que gera um efeito de movimento infinito em tiles de água.
/// </summary>
public class Agua : MonoBehaviour {
	[SerializeField] private Vector2 velocidade;
	void Start () {
		GetComponent<Rigidbody2D>().velocity = velocidade;
	}
	
	void Update () {
		transform.position = new Vector3(transform.position.x % 1, 
			transform.position.y % 1, transform.position.z);
	}
}
