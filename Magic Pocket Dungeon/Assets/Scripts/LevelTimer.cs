using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelTimer : MonoBehaviour
{
    GUIText textfield;

    int allowedTime = 90;
    int currentTime = 0;
    //A timer that tracks how long you've been playing the level
    //Reset it upon death
    //Maybe just reuse the checkpoint and death system from my previous project
    // Start is called before the first frame update
    void Awake()
    {
        updateTimerText();
        timerTick();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void updateTimerText()
    {
        textfield.text = currentTime.ToString();
    }
    void timerTick()
    {
        while (currentTime < 9999)
        {
            currentTime++;
            updateTimerText();
        }
    }
}
