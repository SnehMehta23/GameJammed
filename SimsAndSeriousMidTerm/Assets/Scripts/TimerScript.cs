using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class TimerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Text timer;
    public int timeLeft = 240;
    public GameObject progressSlider;
    void Start()
    {
        StartCoroutine("LoseTime");
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        var ps = progressSlider.GetComponent<ProgressBar>();

        if(ps.Victory == 0)
        {
            timer.text = ("" + timeLeft);
        }
       
    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}
