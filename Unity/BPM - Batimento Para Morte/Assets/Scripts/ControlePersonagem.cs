using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using System; //adicionado para musica

[RequireComponent(typeof(MovimentoPersonagem))]
/// <summary>
/// Código do controle do jogador.
/// </summary>
public class ControlePersonagem : MonoBehaviour {

    public delegate void UpdateStrikeTime(int currentStrike);
    public static event UpdateStrikeTime OnUpdateStrikeTime;

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
	private StatusPersonagem vidaPersonagem;
	private bool alive;
    Animator animator;    

    public float tempo = 0.23f;
	public float tempoBatida = 0f;
    public int cont = 0;
    public bool isPlaying = false;    


    void Awake() {
        movimento = GetComponent<MovimentoPersonagem>();       
        camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
		AudioProcessor processor = GameObject.FindWithTag("MainCamera").GetComponent<AudioProcessor> ();
		processor.onBeat.AddListener (onOnbeatDetected);
		
		
		
        mira = GameObject.FindGameObjectWithTag("mira");
        mira.SetActive(false);  
    }

    void Start()
    {
		vidaPersonagem = this.GetComponent<StatusPersonagem>();
		alive = true;
		animator = GetComponent<Animator>();       
    }

    IEnumerator Atacar(){
        mira.SetActive(!mira.activeSelf);
        yield return new WaitForSeconds(0.5f);
        mira.SetActive(!mira.activeSelf);
    }

    void Update () {
        if (vidaPersonagem.IsDead())
        {
            if (alive) StartCoroutine(death());            
        }else{
            Movimentacao();
            Attack();
        } 
	}

    private float delay = 0.65f; //65 milissegundos para reagir
	void onOnbeatDetected ()
	{
		//detecta batida , pelo algoritmo do cara
		Debug.Log("Tempo "+ tempo);
		tempoBatida = tempo+delay;
		//tempo da batida
		Debug.Log ("Beat!!! "+tempoBatida);
	}
	
	
    void Attack()
    {
        tempo += Time.deltaTime;
        //Se musica esta Tocando e Aperta Z, entre os momentos certo
        if (!isPlaying && Input.GetKeyDown(ataque))
        {
            if (tempo<tempoBatida) //se o tempo da batida for menor que o tempo atual é um movimento válido
            {
			   cont++;
			   isPlaying = true;
			   if (OnUpdateStrikeTime != null) OnUpdateStrikeTime(cont);
			   StartCoroutine(Atacar());	
            }
            else
            {
                Debug.Log("Errou a Batida");                
                vidaPersonagem.SofrerDano(1000);
            }
        }

        if (Input.GetKeyUp(ataque))
        {
            isPlaying = false;
        }
    }

    void Movimentacao()
    {
        Vector2 setas = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (setas.magnitude > 0.5f)
        {
            movimento.Andar(setas.normalized);
            seguindoMouse = false;
        }
        else
        {
            movimento.Andar(Vector2.zero);
            animator.SetBool("walk", false);            
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
        animator.SetTrigger("dead");        
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("TilemapScene");		
 	}
 
}
