using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaControl : MonoBehaviour
{
    public float StaminaMax;

    public float CurrentStam;

    public float StamMin;

    public float StamPrecent;

    public Image ThisImg;



    public Image BleedIcon;
    // Start is called before the first frame update
    void Awake()
    {
        ThisImg = this.gameObject.transform.Find("PlayerBody").transform.Find("Camera").transform.Find("Canvas").transform.Find("Stamina").transform.Find("StaminaBar").GetComponent<Image>();
        StaminaMax = 80;
        StamMin = 5;
        CurrentStam = 80;
    }

    // Update is called once per frame
    void Update()
    {



        StaminaUI(CurrentStam);



        if (CurrentStam < StamMin)
        {
            CurrentStam = StamMin;
        }

        if (CurrentStam > StaminaMax)
        {
            CurrentStam = StaminaMax;
        }
    }

    public void StaminaUI(float stamina)
    {
        if (stamina != StaminaMax)
        {
            StamPrecent = 2.2f * (CurrentStam/StaminaMax);
            ThisImg.rectTransform.localScale = new Vector2(StamPrecent,0.2f);
        }
        else
        {
            ThisImg.rectTransform.localScale = new Vector2(2.2f, 0.2f);
        }
        

    }

    
}
