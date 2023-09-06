using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DigitalClockScript : MonoBehaviour
{
    private TextMeshPro timeText;
    private System.DateTime realTime;
    private float hourValue;
    private float minuteValue;
    private string meridiemValue;

    void Start() {
        timeText = GetComponent<TextMeshPro>();
    }

    void Update() {
        realTime = System.DateTime.Now;
        UpdateTimeOnText();
    }

    //This function updates the text based on the time. 
    void UpdateTimeOnText()
    {
        //If the time is greater than 12, after mid-day (PM), then do the following...
        if(realTime.Hour >= 12) {
            meridiemValue = "PM";

            //This is so that it can avoid the 12%12 = 0
            if(realTime.Hour == 12) {
                hourValue = 12;
            }

            else {
                hourValue = realTime.Hour%12;
            }
        }

        //Otherwise if it is not, then it's pre-day (AM)
        else {
            meridiemValue = "AM";

            //If the hour is 0, AKA midnight, just say 12am
            if(realTime.Hour == 0) {
                hourValue = 12;
            }
            
            else {
                hourValue = realTime.Hour;
            }
        }

        minuteValue = realTime.Minute;
        if(minuteValue < 10) {
            timeText.text = hourValue.ToString() + ": 0" + minuteValue.ToString() + " " + meridiemValue;
        }

        else {
            timeText.text = hourValue.ToString() + ":" + minuteValue.ToString() + " " + meridiemValue;
        }
    }
}
