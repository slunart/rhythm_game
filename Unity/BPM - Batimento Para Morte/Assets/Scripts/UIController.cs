using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
	[SerializeField] StatusPersonagem player;
	[SerializeField] Image lifeBar;
    [SerializeField] Text liveText;
    [SerializeField] Text strikesText;

    void Awake()
    {
        StatusPersonagem.OnUpdateLive += UpdateText;
        ControlePersonagem.OnUpdateStrikeTime += UpdateStrikeTime;
    }

    void OnDestroy()
    {
        StatusPersonagem.OnUpdateLive -= UpdateText;
        ControlePersonagem.OnUpdateStrikeTime -= UpdateStrikeTime;
    }

    void UpdateText(int currentLive)
    {
        float lifeFraction = (float)player.Vida / player.VidaMax;
		lifeBar.rectTransform.anchorMax = new Vector2(lifeFraction, 1f);
		lifeBar.color = lifeFraction > 0.5 ? new Color(0f, 0.5f, 0f, 1f) :
						lifeFraction > 0.2 ? new Color(1f, 0.5f, 0f, 1f) :
						Color.red;
		liveText.text = player.Vida + "/" + player.VidaMax;
    }

    void UpdateStrikeTime(int cont)
    {
        strikesText.text = "Acertos: " + cont.ToString();
    }

}
