using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptEnemy : MonoBehaviour {

private Transform Player; //cant't be bothered to do any commments
[SerializeField] private float speed = 1f; 
[SerializeField] private float minDist= 0f; 
private Animator animator;
private VidaPersonagem vidaPersonagem;
private bool alive;


 void Awake()
 {	

 }
  
 void Start()
 {
	animator = this.GetComponent<Animator> ();
	animator.SetTrigger("walk");
	Player = GameObject.Find("Player").transform;
	vidaPersonagem = this.GetComponent<VidaPersonagem>();
	alive = true;

 }
  
 void Update () {
	if(!vidaPersonagem.isDead()){
		Vector3 displacement = Player.position -transform.position;
     	displacement = displacement.normalized;
        
		if(Vector2.Distance(transform.position,Player.position) >= minDist){
			if(true){ //fazer movimento perserguir
			animator.SetTrigger("walk");
			transform.position += (displacement * speed * Time.deltaTime);
			}
		}else{
			//ação
			//animator.SetTrigger("attack");
		}
	}else{
	    if(alive){
			StartCoroutine(death());
		}
	}
  }


 public IEnumerator death(){
	    alive = false;
		animator.SetTrigger("dead");
        yield return new WaitForSeconds(2f);
		Destroy(gameObject);
 }

}
