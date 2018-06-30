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
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
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
                if (((tempo % 1) <= 0.40) && (tempo % 1) >= 0)
                {
                    cont++;
                    isPlaying = true;
                    UIText.text = "acertou o tempo " + cont.ToString() + "x";
                    personagem.Atirar();
                    Debug.Log(tempo);
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
