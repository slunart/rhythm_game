using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MovimentoPersonagem))]
/// <summary>
/// Código do controle do jogador.
/// </summary>
public class ControlePersonagem : MonoBehaviour {
    const int MOUSE_LEFT = 0;
    private MovimentoPersonagem movimento;
  

    private Camera camera;
    private bool seguindoMouse = false;
    private Vector3 direction;


    [Header("Teclas")]
    [Tooltip("Tecla do ataque")][SerializeField] private KeyCode ataque = KeyCode.Z;
    [Header("Botões")]
    [Tooltip("Área da GUI reservada para os botões")][SerializeField] private RectTransform areaBotoes;
    [Tooltip("Botão do ataque")][SerializeField] private Button botaoAtaque;
  
    private GameObject mira;
	private GameObject fire;
	private VidaPersonagem vidaPersonagem;
	private bool alive;
    Animator animator;


    void Awake() {
        movimento = GetComponent<MovimentoPersonagem>();
        camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        mira = GameObject.FindGameObjectWithTag("mira");
        mira.SetActive(false);  
    }

    void Start()
    {
		vidaPersonagem = this.GetComponent<VidaPersonagem>();
		alive = true;
		animator = GetComponent<Animator>();
       
    }

    public IEnumerator Atacar(){;
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
                animator.SetTrigger("idle");
			}

		if(vidaPersonagem.isDead()){
			if(alive){
				StartCoroutine(death());
			}

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

	 public IEnumerator death(){
	    alive = false;
		//Tempo para a duração da animação
        yield return new WaitForSeconds(3f);
		Destroy(gameObject);
 	}

 
}
