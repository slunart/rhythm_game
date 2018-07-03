using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    [SerializeField] Text liveText;    

    void Awake()
    {
        StatusPersonagem.OnUpdateLive += UpdateText;        
    }

    void OnDestroy()
    {
        StatusPersonagem.OnUpdateLive -= UpdateText;        
    }

    void UpdateText(int currentLive)
    {
        liveText.text = "vidas: " + currentLive.ToString();
    }

}
