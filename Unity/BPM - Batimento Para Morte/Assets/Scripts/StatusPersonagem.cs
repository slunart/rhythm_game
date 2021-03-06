﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class StatusPersonagem : MonoBehaviour {

    [SerializeField] private int vida;
	public int Vida {
		get {
			return vida > 0 ? vida : 0;
		}
	}
    [SerializeField] private int vidaMax = 20000;
	public int VidaMax {
		get {
			return vidaMax;
		}
	}

    bool imortality = false;
    SpriteRenderer render;

    public delegate void UpdateLive(int currentLife);
    public static event UpdateLive OnUpdateLive;

    void Awake()
    {
        vida = vidaMax;        
    }

    private void Start()
    {
        if (OnUpdateLive != null) OnUpdateLive(vida);
        render = GetComponent<SpriteRenderer>();
    }

    public void SofrerDano(int dano)
    {
        if (imortality) return;

        vida -= dano;

        if (OnUpdateLive != null) OnUpdateLive(vida);

        if (IsDead()) return;
        StartCoroutine(ImortalityCoroutine());        
    }

    IEnumerator ImortalityCoroutine()
    {
        imortality = true;
        render.color  = Color.red;       
        yield return new WaitForSeconds(0.25f);
        render.color = Color.white;        
        yield return new WaitForSeconds(0.25f);
        render.color = Color.red;
        yield return new WaitForSeconds(0.25f);
        render.color = Color.white;

        imortality = false;
    }

    //para saber se está morto ou vivo
    public bool IsDead()
    {
        if (vida <= 0) return true;

        return false;
    }
}
