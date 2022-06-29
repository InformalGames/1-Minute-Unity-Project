using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerControl : MonoBehaviour
{

    //this script controls the timer, and should be put on the camera object using Unity. (Controls the UI)

    public bool TimerActivated; //if this is set to true, the timer will start counting, if not, the timer wont do anything

    public int CurrentTime; //the current timer and how much the timer is, counts down.

    public int DeathTimer; //when Currenttime equals or becomes bigger then this number, the player will die

    public float RateOfTime; //how fast the timer goes. 

    public float CurrentRateOfTime; //this variable is a timer. Once "CurrentRateOfTime" is larger then the number of RateOfTime, CurrentTime int will add a number

    //UI components
    public GameObject TimerDisplayOBJ;

    string TimerUI;

    //setting

    bool IsPaused;

    // Start is called before the first frame update
    void Awake()
    {
        DeathTimer = 60;
        CurrentTime = 0;
        CurrentRateOfTime = 0;
        RateOfTime = 1.2f;
        TimerDisplayOBJ = transform.Find("Canvas").transform.Find("TimerTxt").gameObject;
    }
    private void Update()
    {
        IsPaused = GameObject.Find("GameController").GetComponent<GameSetting>().PauseGame;
        //Display UI
        if (CurrentTime < 60)
        {
            if (CurrentTime < 10)
            {
                TimerUI = "0:0" + CurrentTime;
            }
            else
            {
                TimerUI = "0:" + CurrentTime;
            }
            
        }
        else
        {
            TimerUI = "1:00!!!";
        }
        TimerDisplayOBJ.GetComponent<TMPro.TextMeshProUGUI>().text = "Timer: " + TimerUI;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (IsPaused == false)
        {
            //check if the timer is working right now
            if (TimerActivated == true)
            {
                TimerFunction();
            }
        }
        
    }
    //controls the timer itself, makes the timer tick.
    public void TimerFunction()
    {
        if (CurrentRateOfTime < RateOfTime) 
        {
            CurrentRateOfTime += 1 * Time.deltaTime; //increase the current rate of time
        }
        else
        {
            if (CurrentRateOfTime > RateOfTime)
            {
                CurrentTime += 1;
                CurrentRateOfTime = 0;
            }
        }
    }
}
