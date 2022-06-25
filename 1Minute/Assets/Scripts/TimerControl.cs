using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerControl : MonoBehaviour
{

    //this script controls the timer, and should be put on the camera object using Unity. (Controls the UI)

    public bool TimerActivated; //if this is set to true, the timer will start counting, if not, the timer wont do anything

    public int CurrentTime; //the current timer and how much the timer is, counts down.

    public int DeathTimer; //when Currenttime equals or becomes bigger then this number, the player will die

    public float RateOfTime; //how fast the timer goes. 

    public float CurrentRateOfTime; //

    

    // Start is called before the first frame update
    void Awake()
    {
        DeathTimer = 60;
        CurrentTime = 0;
        TimerActivated = false;

        RateOfTime = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
