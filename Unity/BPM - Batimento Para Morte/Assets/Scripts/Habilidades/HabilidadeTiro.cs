using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Código do ataque de projéteis.
/// </summary>
public class HabilidadeTiro : MonoBehaviour {
	[Tooltip("De onde o tiro é dado")][SerializeField] private Transform origemTiro;
	[Tooltip("Velocidade do disparo")][SerializeField] private float velocidade = 0;
	[Tooltip("Variedades de munição")][SerializeField] private GameObject[] municao;
	
	/// <summary>
	/// Atira o projétil especificado.
	/// <param name="indice">O índice do projétil no array de munições.</param>
	/// </summary>
	public void Atirar(int indice) {
		GameObject disparo = Instantiate (municao[indice]);
		disparo.transform.position = origemTiro.position;
		disparo.GetComponent<Rigidbody2D> ().velocity = origemTiro.up * velocidade;
	}
}
