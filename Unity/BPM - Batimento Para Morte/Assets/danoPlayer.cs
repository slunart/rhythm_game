using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danoPlayer : MonoBehaviour {
    [SerializeField] private int dano = 5000;
    //[SerializeField]  GameObject vper;
     VidaPersonagem vpo;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player")) { 

            vpo = collision.collider.GetComponent<VidaPersonagem>();
            vpo.SofrerDano(dano);
            Debug.Log("oi");
        }
    }
    

    
}
