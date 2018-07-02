using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorInimigos : MonoBehaviour {
	[SerializeField] private GameObject alvoPrefab;
    private GameObject[] instancias;
	[SerializeField] private float raioAlcance = 4f;
	[SerializeField] private int InimigosInitial;
	
    void Start (){
		//começar com dois inimigos
		instancias = new GameObject[InimigosInitial];
		for(int i=0;i<InimigosInitial;i++){
			if (instancias[i] == null) {
				instancias[i] = Instantiate(alvoPrefab);
				instancias[i].transform.SetParent(transform);
				instancias[i].transform.position = Random.insideUnitCircle.normalized * raioAlcance; 
			}
		}

	}

	// Sempre que um alvo for destruído, outro alvo aparece
	void Update () {
		/* 
		if (instancia == null) {
			instancia = Instantiate(alvoPrefab);
			instancia.transform.SetParent(transform);
			instancia.transform.position = Random.insideUnitCircle.normalized * raioAlcance; 
		}
		*/
	}
}
