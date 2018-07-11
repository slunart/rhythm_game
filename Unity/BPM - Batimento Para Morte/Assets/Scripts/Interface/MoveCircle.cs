using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCircle : MonoBehaviour {
    float timeCounter;
    [SerializeField] private float speed;
    [SerializeField] private float radius; //trajetory radius
    [SerializeField] public bool sicronizo;
    Transform player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player").GetComponent<Transform> ();
        sicronizo = false;
	}
	
	// Update is called once per frame
	void Update () {
        timeCounter += Time.deltaTime * speed;

        float x = player.position.x + Mathf.Cos(timeCounter)*radius;
        float y = player.position.y + Mathf.Sin(timeCounter)*radius;
        
        transform.position = new Vector2 ( x, y);
	}

}