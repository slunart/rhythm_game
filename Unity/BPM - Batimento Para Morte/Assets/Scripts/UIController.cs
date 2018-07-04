using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

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
        liveText.text = "vidas: " + (currentLive < 0 ? "0" : currentLive.ToString());
    }

    void UpdateStrikeTime(int cont)
    {
        strikesText.text = "Acertos: " + cont.ToString();
    }

}
