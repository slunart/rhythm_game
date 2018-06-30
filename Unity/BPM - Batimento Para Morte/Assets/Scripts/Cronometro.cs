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
        //UIText.text = tempo.ToString();

        //if (Input.GetKeyDown(KeyCode.Z)) {
        //    if(((tempo % 1 ) <= 0.30) && (tempo % 1) >= 0){
        //        Debug.Log("acertou batida");
        //        cont++;
        //        UIText.text = "acertou o tempo " + cont.ToString() + "x";

        //    }
            if (!isPlaying && Input.GetKeyDown(KeyCode.Z))
            {
                if (((tempo % 1) <= 0.40) && (tempo % 1) >= 0){
                    cont++;
                    isPlaying = true;
                    if (cont == 1) UIText.text = "Acertou a batida: " + cont.ToString() + " vez";
                    else
                        UIText.text = "Acertou a batida: " + cont.ToString() + " vezes";
                    personagem.Atirar();
                    Debug.Log(tempo);
                }
                else {
                    v = personagem.GetComponent<VidaPersonagem>();
                    v.SofrerDano(3000);
                }
            }

            if (Input.GetKeyUp(KeyCode.Z))
            {
                isPlaying = false;
            }

            // Debug.Log("time:"+tempo);
       // }
	}
}
