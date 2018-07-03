using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDanoPlayer : MonoBehaviour {
    [SerializeField] private int dano;
    VidaPersonagem vpo;
    MovimentoPersonagem mv;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player")) {
            //Se não estiver morto cause dano
            vpo = collider.GetComponent<VidaPersonagem>();
            Debug.Log("Inimigo Causa dano"); 
            vpo.SofrerDano(dano);

            //knockback efeito
            mv = collider.GetComponent<MovimentoPersonagem>();
            Vector2 dir = (transform.position - collider.transform.position).normalized;
            int force = 1000;  
            mv.knockBack(dir,force);
              
        
        }
    }


    
}
