using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCircleColider : MonoBehaviour {
    
    void OnGUI()
    {
        Event e = Event.current;
        if (e.type == EventType.KeyDown)
        {
            int temp = 0;
            if (Input.GetKeyDown(KeyCode.Z))
            {
               // Debug.Log("oi");
                temp++;
            }
        }
    }

    private void OnTriggerEnter2D() {
        //Collider2D mu = muletinha.GetComponent<Collider2D>();
        //Collider2D mir = mira.GetComponent<Collider2D>();
        if (Input.GetKeyDown(KeyCode.Z))
        {
           // Debug.Log("tô na batida 2");
        }
    }
	
}
