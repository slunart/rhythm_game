using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Código do ataque por contato.
/// </summary>
public class HabilidadeDanoContato : MonoBehaviour {
	[Tooltip("O dano causado pelo contato")][SerializeField] private int dano = 5000;

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.collider.CompareTag("Player")) { 
			VidaPersonagem vpo = collision.collider.GetComponent<VidaPersonagem>();
			vpo.SofrerDano(dano);
			Debug.Log("oi");
		}
	}   
}
