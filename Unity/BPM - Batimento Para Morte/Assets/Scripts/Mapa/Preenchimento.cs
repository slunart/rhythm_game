using UnityEngine;

/// <summary>
/// Código que faz um ou mais tilesets seguirem a câmera, fazendo o mapa parecer infinito.
/// </summary>
public class Preenchimento : MonoBehaviour {
	public Transform camera;
	void Start () {
		Update();
	}
	void Update () {
		transform.position = new Vector3((int)camera.position.x, (int)camera.position.y, transform.position.z);
	}
}
