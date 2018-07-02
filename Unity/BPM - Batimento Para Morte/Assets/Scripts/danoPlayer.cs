using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danoPlayer : MonoBehaviour {
    [SerializeField] private int dano = 5000;
     VidaPersonagem vpo;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player")) { 
            vpo = collision.collider.GetComponent<VidaPersonagem>();
            vpo.SofrerDano(dano);
            Debug.Log("Inimigo Causa dano");
             
             //knockback
             var magnitude = 2000;
             // calculate force vector
             var force = transform.position - collision.transform.position;
             // normalize force vector to get direction only and trim magnitude
             force.Normalize();
             collision.rigidbody.AddForce(- force * magnitude);

        }
    }

    

    
}
