using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cronometro : MonoBehaviour {

    public Text UIText;
    public float tempo = 0.23f;
    public int cont = 0;
    public bool isPlaying = false;
    public ControlePersonagem personagem;
    public VidaPersonagem v;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        tempo += Time.deltaTime;
            //Se musica esta Tocando e Aperta Z, entre os momentos certo
            if (!isPlaying && Input.GetKeyDown(KeyCode.Z))
            {
                if (((tempo % 1) <= 0.40) && (tempo % 1) >= 0){
                    cont++;
                    isPlaying = true;
                    UIText.text = "Acertos: " + cont.ToString();                                        
                    StartCoroutine(personagem.Atacar());                    
                }else {
                    //Debug.Log("Errou a Batida");
                    //v = personagem.GetComponent<VidaPersonagem>();
                    //v.SofrerDano(1000);
                }
            }

            if (Input.GetKeyUp(KeyCode.Z))
            {
                isPlaying = false;
            }

            // Debug.Log("time:"+tempo);

	}
}
