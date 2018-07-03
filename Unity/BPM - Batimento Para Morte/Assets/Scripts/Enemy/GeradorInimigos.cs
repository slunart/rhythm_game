using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorInimigos : MonoBehaviour {
	[SerializeField] private GameObject alvoPrefab;
    private GameObject[] instancias;
	[SerializeField] private float raioAlcance = 4f;
	[SerializeField] private int InimigosInitial;
	[SerializeField] private int InimigosLevel;
	private int inimigosContador; 

    void Start (){
	 	instancias = new GameObject[InimigosInitial];
		inimigosContador = 0;
	}

	// Sempre que um alvo for destruído, outro alvo aparece
	void Update () {
	 if(inimigosContador<InimigosLevel){  
		for(int i=0;i<InimigosInitial;i++){
				if (instancias[i] == null) {
					instancias[i] = Instantiate(alvoPrefab);
					instancias[i].transform.SetParent(transform);
					instancias[i].transform.position = Random.insideUnitCircle.normalized * raioAlcance; 
					inimigosContador++; //informando contador
				}
			}
	    }
	}
}
