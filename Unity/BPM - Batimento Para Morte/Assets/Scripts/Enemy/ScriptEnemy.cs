using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptEnemy : MonoBehaviour {

private Transform Player; //cant't be bothered to do any commments
[SerializeField] private float minDist; 
[SerializeField] private float speed; 
private Animator animator;
private VidaPersonagem vidaPersonagem;
private bool alive;
private BoxCollider2D bEnemy;

private bool facing = true;  
 void Start()
 {
	animator = this.GetComponent<Animator> ();
	animator.SetTrigger("walk");
	Player = GameObject.Find("Player").transform;
	vidaPersonagem = this.GetComponent<VidaPersonagem>();
	bEnemy = GetComponent<BoxCollider2D>();
	alive = true;

 }
  
 void Update () {
	if(!vidaPersonagem.isDead()){
		move();
	}else{
	    if(alive){
			//se estiver vivo faça a animação da morte 
			StartCoroutine(death());
		}
	}
  }


  public void move(){
		Vector3 displacement = Player.position - transform.position;
     	displacement = displacement.normalized;
		if(Vector2.Distance(transform.position,Player.position) >= minDist){
			//trocar a face do inimigo
			if(transform.position.x>Player.position.x){
				GetComponent<SpriteRenderer>().flipX = true;
			}else{
                GetComponent<SpriteRenderer>().flipX = false;
			}

			
			animator.SetTrigger("walk");
			transform.position += (displacement * speed * Time.deltaTime);
		}

  }


 public IEnumerator death(){
	    alive = false;
	    bEnemy.enabled = false;;
		animator.SetTrigger("dead");
        yield return new WaitForSeconds(2f);
		Destroy(gameObject);
 }

}
