using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacao : MonoBehaviour {
	[SerializeField] private float velocidade = 180f;
    [SerializeField] private RectTransform areaBotoes;

    void Update() {
        //transform.localRotation = Quaternion.AngleAxis((velocidade * Time.time) % 360, Vector3.forward);
        //GameObject mira = GetComponent<GameObject>().gameObject;
        if (Input.GetMouseButtonDown(0) && !clicandoBotoes())//Input.GetTouch(0).phase == TouchPhase.Began
        {
            
            float mouse_x = Input.mousePosition.x;
            float mouse_y = Input.mousePosition.y;
            //Debug.Log("posicao mouse x:" + mouse_x +", posicao mouse y:"+mouse_y);
            float angulo = 0;
            if (mouse_x > 380 && mouse_y >= 150 && mouse_y < 250)
            {
                angulo = -90;
            }else if(mouse_x <=370 && mouse_y >= 150 && mouse_y < 250)
            {
                angulo = 90;
            }else if(mouse_y <= 150 && mouse_x >= 290 && mouse_x < 390)
            {
                angulo = 180;
            }
            else
            {
                angulo = 360;
            }
            transform.localRotation = Quaternion.AngleAxis(angulo, Vector3.forward);
        }
	}

    bool clicandoBotoes()
    {
        Vector3[] corners = new Vector3[4];
        areaBotoes.GetWorldCorners(corners);

        return entre(corners[0].x, Input.mousePosition.x, corners[2].x)
            && entre(corners[0].y, Input.mousePosition.y, corners[1].y);
    }

    bool entre(float min, float val, float max)
    {
        return (min <= val) && (val <= max);
    }
}
