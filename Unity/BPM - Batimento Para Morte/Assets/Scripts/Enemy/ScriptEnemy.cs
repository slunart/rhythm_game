using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptEnemy : MonoBehaviour {

private Transform Player; //cant't be bothered to do any commments
[SerializeField] private float speed = 1f; 
[SerializeField] private float minDist= 0f; 
//private Animator animator;

 void Awake()
 {
                 
 }
  
 void Start()
 {
    //animator = this.GetComponent<Animator> ();
	Player = GameObject.Find("Player").transform;
 }
  
 void Update () {

		Vector3 displacement = Player.position -transform.position;
     	displacement = displacement.normalized;

	   if(Vector2.Distance(transform.position,Player.position) >= minDist){
		// animator.SetTrigger("walk");
	   	 transform.position += (displacement * speed * Time.deltaTime);
	   }else{
		//	animator.SetTrigger("attack");
	   }

  }

}
