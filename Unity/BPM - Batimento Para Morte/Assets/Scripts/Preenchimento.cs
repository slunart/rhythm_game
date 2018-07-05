using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preenchimento : MonoBehaviour {
	public Transform camera;
	void Start () {
		Update();
	}
	void Update () {
		transform.position = new Vector3((int)camera.position.x, (int)camera.position.y, transform.position.z);
	}
}
