using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDanoEnemy : MonoBehaviour {
    [SerializeField] private int dano;
     VidaPersonagem vpo;

    private void OnTriggerEnter2D(Collider2D collider)
    {
         //se inimigo detectado , gere dano no inimigo
        if (collider.CompareTag("Enemy")){ 
            vpo = collider.GetComponent<VidaPersonagem>();
             //Se não estiver morto cause dano
                Debug.Log("Inimigo Atinjido");
                vpo.SofrerDano(dano);
            
        }


    }
    

    
}
