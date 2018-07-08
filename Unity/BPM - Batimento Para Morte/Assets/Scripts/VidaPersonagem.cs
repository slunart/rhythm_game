using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class VidaPersonagem : MonoBehaviour {
    [SerializeField] private int vida;
	[SerializeField] private int vidaMax = 1000000000;

    void Awake () {
		vida = vidaMax;
	}    

    public void SofrerDano(int dano) {
		vida -= dano;
	}
    
	//para saber se está morto ou vivo
	public bool isDead() {
		if (vida <= 0) return true;
		
		return false;
	}

}
