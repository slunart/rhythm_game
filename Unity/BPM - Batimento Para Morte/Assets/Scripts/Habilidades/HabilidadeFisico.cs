using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Código do ataque físico/com armas brancas.
/// </summary>
public class HabilidadeFisico : MonoBehaviour {
	[Tooltip("A área de alcance do ataque")][SerializeField] private Collider2D areaAtaque;
	[Tooltip("O dano causado pelo ataque")][SerializeField] private int dano = 10;

	void Awake() {
		areaAtaque.isTrigger = true;
	}

	/// <summary>
	/// Usa o ataque físico.
	/// </summary>
	public void Atacar() {
		Collider2D[] colliders = new Collider2D[10];
		int contatos = areaAtaque.GetContacts(colliders);
		//Pega todos os personagens que estão em contato com o checaAtaque, uma única vez
		HashSet<VidaPersonagem> set = new HashSet<VidaPersonagem>();
		for (int i = 0; i < contatos; i++) {
			VidaPersonagem vida = colliders[i].GetComponent<VidaPersonagem>();
			if (colliders[i].gameObject != gameObject && vida != null) set.Add(vida);
		}
		//Da dano em todos os personagens
		foreach (VidaPersonagem vida in set)
			vida.SofrerDano(dano);
	}
}
