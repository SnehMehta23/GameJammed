using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundScript : MonoBehaviour
{
    public Transform farEnd;
    public Vector2 startEnd;
    public Slider stressSlider;
    public float progress = 1f;
    public GameObject progressSlider;
    public float stress;
    public float secondsForOneLength = 10f;

    public GameObject menu;

    public Sprite sprite1;
    public Sprite sprite2;

    private Animator anim;

    private SpriteRenderer sprRend;
    public GameObject controllerKey;


    void Start()
    {
        startEnd = new Vector2(-7.5f,1.51f);
        stress += .02f;

        sprRend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        var cs = progressSlider.GetComponent<ProgressBar>();
        var pause = menu.GetComponent<PauseMenu>();

        if (cs.Victory == 0f && pause.GameIsPaused != true)
        {
            controllerKey.gameObject.SetActive(false);

            if (stress < 100 && transform.position.x <= -6.50)
            {

                Debug.Log("Accessed");
                stress += .02f;
                stressSlider.value = stress;

                
                sprRend.flipX = true;

                if (stress < 24)
                {
                    cs.progress += .005f * Time.deltaTime;
                    anim.SetFloat("Stress", 25f);
                }
                else if (stress > 25 && stress < 49)
                {
                    cs.progress += .000125f * Time.deltaTime;
                }
                else if (stress > 49 && stress < 75)
                {
                    cs.progress -= .0000625f * Time.deltaTime;
                    controllerKey.gameObject.SetActive(true);
                    anim.SetFloat("Stress", 100f);
                }
                else if (stress > 75)
                {
                    cs.progress -= .00003125f * Time.deltaTime;
                    controllerKey.gameObject.SetActive(true);
                }

            }


            if (transform.position.x > farEnd.position.x && secondsForOneLength == 10 && Input.GetKey(KeyCode.Q))
            {
                transform.Translate(Vector2.left * 1 * Time.deltaTime);
                sprRend.flipX = false;
               
            }
            else if (transform.position.x < startEnd.x)
            {
                transform.Translate(Vector2.left * -1 * Time.deltaTime);
                secondsForOneLength += .2f;
                sprRend.flipX = true;
               

                if (secondsForOneLength == 10)
                {
                    secondsForOneLength = 10;
                }


            }

            if (transform.position.x < -10)
            {
                stress -= .5f;
                stressSlider.value = stress;

                cs.progress += 0;

                if (stress < 0)
                {
                    anim.SetFloat("Stress", 25f);
                    stress = 0;
                }
            }

            if (transform.position.y >= startEnd.y)
            {
                secondsForOneLength = 10;

            }
        }

        
    }
}
