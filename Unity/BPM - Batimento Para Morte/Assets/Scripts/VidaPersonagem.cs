using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class VidaPersonagem : MonoBehaviour {
	private int vida;
	[SerializeField] private int vidaMax = 1000000000;
    Animator anim;

	void Awake () {
		vida = vidaMax;
        anim = GetComponent<Animator>();
	}

	public void SofrerDano(int dano) {
		vida -= dano;
        if (vida <= 0)
        {
            anim.SetTrigger("foiAbatido");
            Destroy(gameObject);
        }
	}
}
