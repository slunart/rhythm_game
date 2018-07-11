using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCircle : MonoBehaviour {
   
	MoveCircle mc;
	private void OnTriggerEnter2D(Collider2D collider) {
		if(collider.CompareTag("Hit")){
        	mc = collider.GetComponent<MoveCircle>();
			mc.sicronizo = true;
		}
	
    }

	private void OnTriggerExit2D(Collider2D collider) {
		if(collider.CompareTag("Hit")){
        	mc = collider.GetComponent<MoveCircle>();
			mc.sicronizo = false;
		}
	
    }
	

}
