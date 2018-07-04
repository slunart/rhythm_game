using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDanoPlayer : MonoBehaviour {
    [SerializeField] private int dano;
    StatusPersonagem vpo;
    MovimentoPersonagem mv;
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Player")) {
            //Se não estiver morto cause dano
            vpo = collider.GetComponent<StatusPersonagem>();
            Debug.Log("Inimigo Causa dano"); 
            vpo.SofrerDano(dano);

            if (vpo.IsDead()) return;            

            //knockback efeito
            mv = collider.GetComponent<MovimentoPersonagem>();
            Vector2 dir = (transform.position - collider.transform.position).normalized;
            int force = 1000;  
            mv.knockBack(dir,force);                      
        }
    }


    
}
