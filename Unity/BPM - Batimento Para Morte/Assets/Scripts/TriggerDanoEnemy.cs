using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDanoEnemy : MonoBehaviour {
    [SerializeField] private int dano = 5000;
     VidaPersonagem vpo;

    private void OnCollisionEnter2D(Collision2D collision)
    {
         //se inimigo detectado , gere dano no inimigo
           Debug.Log("Inimigo Atinjido");
        if (collision.collider.CompareTag("Enemy")) { 
            Debug.Log("Inimigo Atinjido");
            vpo = collision.collider.GetComponent<VidaPersonagem>();
            vpo.SofrerDano(dano);
        }
    }
    

    
}
