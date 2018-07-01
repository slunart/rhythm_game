using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MovimentoPersonagem))]

public class ControlePersonagem : MonoBehaviour {
    const int MOUSE_LEFT = 0;
    private MovimentoPersonagem movimento;
  

    private Camera camera;
    private bool seguindoMouse = false;
    private Vector3 direction;

    [Header("Teclas")]
    [SerializeField] private KeyCode ataque = KeyCode.Z;
  
    [Header("Botões")]
    [SerializeField] private RectTransform areaBotoes;
    [SerializeField] private Button botaoTiroGrave; //ataque
    [SerializeField] private Button botaoTiroAgudo;
    private GameObject mira;
 
    void Awake() {
        movimento = GetComponent<MovimentoPersonagem>();
        camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        mira = GameObject.FindGameObjectWithTag("mira");
        mira.SetActive(false);
       
    }

    void Start()
    {
  
       
    }

    public IEnumerator Atacar(){
        mira.SetActive(!mira.activeSelf);
        yield return new WaitForSeconds(1);
        mira.SetActive(!mira.activeSelf);
    }

    void Update () {
	
        
		Vector2 setas = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
		if (setas.magnitude > 0.5f) {
			movimento.Andar (setas.normalized);
			seguindoMouse = false;
		} else {
			if (Input.GetMouseButtonDown (MOUSE_LEFT) && !clicandoBotoes()) {
				seguindoMouse = true;

				direction = new Vector3 ((float)Input.mousePosition.x / ((float)Screen.width / 2),
					(float)Input.mousePosition.y / ((float)Screen.height / 2), -1f);
				direction += Vector3.down + Vector3.left;
				direction.x *= (camera.orthographicSize * (float)Screen.width / Screen.height);
				direction.y *= camera.orthographicSize;
				direction += transform.position;
			}
			if (seguindoMouse) {
				if ((direction - transform.position).magnitude <= 0.2f) seguindoMouse = false;
				movimento.Andar ((direction - transform.position).normalized);
			} else {
				movimento.Andar (Vector2.zero);
			}
		}
	}

	bool clicandoBotoes() {
		Vector3[] corners = new Vector3[4];
		areaBotoes.GetWorldCorners(corners);

		return entre(corners[0].x, Input.mousePosition.x, corners[2].x)
			&& entre(corners[0].y, Input.mousePosition.y, corners[1].y);
	}

	bool entre(float min, float val, float max) {
		return (min <= val) && (val <= max);
	}

 
}
