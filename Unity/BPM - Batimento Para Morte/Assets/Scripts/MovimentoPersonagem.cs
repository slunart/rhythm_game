using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
/// <summary>
/// Código do movimento de um personagem.
/// </summary>
public class MovimentoPersonagem : MonoBehaviour {
	[SerializeField] private float velocidade = 1f;
	private Rigidbody2D rb;
    Animator anim;
    Vector3 localScale;
    float direcaoX;
    bool olhandoDireita = true;

	void Awake() {
		rb = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
	}

	/// <summary>
	/// Anda em uma direção específica.
	/// <param name="direcao">A direção do movimento.</param>
	/// </summary>
	public void Andar(Vector2 direcao) {
		rb.velocity = direcao * velocidade;
        direcaoX = velocidade * Input.GetAxisRaw("Horizontal");
        anim.SetBool("estaAndando", true);
        viraParaEsquerda();
	}

    void viraParaEsquerda()
    {
        if(direcaoX > 0)
        {
            olhandoDireita = true;
        }else if(direcaoX < 0)
        {
            olhandoDireita = false;
        }

        if((olhandoDireita && localScale.x <0) || (!olhandoDireita && localScale.x > 0))
        {
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
    
}
