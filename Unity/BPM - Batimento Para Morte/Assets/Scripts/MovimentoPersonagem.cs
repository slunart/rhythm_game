using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
/// <summary>
/// Código do movimento de um personagem.
/// </summary>
public class MovimentoPersonagem : MonoBehaviour {
	[SerializeField] private float velocidade = 1f;
	private Rigidbody2D rb;

	void Awake() {
		rb = GetComponent<Rigidbody2D> ();
	}

	/// <summary>
	/// Anda em uma direção específica.
	/// <param name="direcao">A direção do movimento.</param>
	/// </summary>
	public void Andar(Vector2 direcao) {
		rb.velocity = direcao * velocidade;
	}
}
