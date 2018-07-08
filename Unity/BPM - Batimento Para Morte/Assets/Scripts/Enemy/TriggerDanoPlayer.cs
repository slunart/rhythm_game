using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDanoPlayer : MonoBehaviour {
    [SerializeField] private int dano;
    StatusPersonagem vpo;
    MovimentoPersonagem mv;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player")) {
            //Se não estiver morto cause dano
            vpo = col.collider.GetComponent<StatusPersonagem>();
            //Debug.Log("Inimigo Causa dano"); 
            vpo.SofrerDano(dano);

            if (vpo.IsDead()) return;            

            //knockback efeito
            mv = GetComponent<Collider>().GetComponent<MovimentoPersonagem>();
            Vector2 dir = (transform.position - GetComponent<Collider>().transform.position).normalized;
            int force = 1000;  
            mv.knockBack(dir,force);                      
        }
    }


    
}
