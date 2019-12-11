using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockUI : MonoBehaviour {
    //240 seconds is our game time -- 240 seconds = a 4 minute gametime 
    private const float REAL_SECONDS_PER_INGAME_DAY = 240f;

    public Slider progressBar;

    private Transform clockHourHandTransform;
    private Transform clockMinuteHandTransform;
    public Text timeText;
    private float day;

    private void Awake() {
        clockHourHandTransform = transform.Find("hourHand");
        clockMinuteHandTransform = transform.Find("minuteHand");

        

    }

    private void Update() {

        var cs = progressBar.GetComponent<ProgressBar>();

        day += Time.deltaTime / REAL_SECONDS_PER_INGAME_DAY;

        float dayNormalized = day % 1f;

        if(progressBar.value < 10000 && day != 240 && cs.Victory == 0f)
        {
            float rotationDegreesPerDay = 360f;
            clockHourHandTransform.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegreesPerDay);

            float hoursPerDay = 24f;
            clockMinuteHandTransform.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegreesPerDay * hoursPerDay);

            string hoursString = Mathf.Floor(dayNormalized * hoursPerDay).ToString("00");

            float minutesPerHour = 60f;
            string minutesString = Mathf.Floor(((dayNormalized * hoursPerDay) % 1f) * minutesPerHour).ToString("00");

            timeText.text = hoursString + ":" + minutesString;
        }
       
    }

}
