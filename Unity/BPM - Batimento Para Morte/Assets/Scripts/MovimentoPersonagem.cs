using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovimentoPersonagem : MonoBehaviour {
	[SerializeField] private float velocidade = 1f;
	private Rigidbody2D rb;
    Animator anim;

	void Awake() {
		rb = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator>();
	}

	public void Andar(Vector2 direcao) {
		rb.velocity = direcao * velocidade;
        anim.SetBool("estaAndando", true);
	}

      /*if ((!olhandoDireita(olhandoX) && (localScale.x< 0)) || (olhandoDireita(olhandoX) && (localScale.x > 0)))
        {
            localScale.x *= -1;
            transform.localScale = localScale;
        }*/
}
