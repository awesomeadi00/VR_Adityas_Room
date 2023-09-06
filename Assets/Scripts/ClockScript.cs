using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockScript : MonoBehaviour

{
    public GameObject hourHand;
    public GameObject minuteHand;
    public GameObject secondHand;
    private System.DateTime realTime;
    
    [SerializeField] float hourAngle;
    [SerializeField] float minuteAngle;
    [SerializeField] float secondAngle;
    private float hourRotationSpeed;
    private float minuteRotationSpeed;
    private float secondRotationSpeed;

    void Start()
    {
        // Calculate the rotation speed for the hands (in degrees per second)
        hourRotationSpeed = 360f / 12f / 60f / 60f;             // 360 degrees / 12 hours / 60 minutes / 60 seconds
        minuteRotationSpeed = 360f / 60f / 60f;                 // 360 degrees / 60 minutes / 60 seconds
        secondRotationSpeed = 360f / 60f;                       // 360 degrees / 60 seconds
    }

    void Update()
    {
        // Get the current time
        realTime = System.DateTime.Now;
        UpdateHand();
    }

    void UpdateHand()
    {
        // Calculate the angles for the hour, minute, and second hands
        hourAngle = realTime.Hour * 30f;                                    // Because 12 hours * 30 = 360 degrees (if not then add "+ realTime.Minute * 0.5f")
        minuteAngle = realTime.Minute * 6f;                                 // Because 60 minutes * 6 = 360 degrees
        secondAngle = realTime.Second * 6f;                                 // Because 60 seconds * 6 = 360 degrees

        // Rotate the hour hand
        hourHand.transform.localRotation = Quaternion.Euler(hourAngle + Time.deltaTime * hourRotationSpeed, 0, 0);

        // Rotate the minute hand
        minuteHand.transform.localRotation = Quaternion.Euler(minuteAngle + Time.deltaTime * minuteRotationSpeed, 0, 0);

        // Rotate the second hand
        secondHand.transform.localRotation = Quaternion.Euler(secondAngle + Time.deltaTime * secondRotationSpeed, 0, 0);
    }
}