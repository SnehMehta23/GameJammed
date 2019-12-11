using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgrammerScript : MonoBehaviour
{
    public Transform farEnd;
    public Vector2 startEnd;
    public Slider stressSlider;
    public float progress = 1f;
    public float stress;
    public float secondsForOneLength = 10f;

    public GameObject progressSlider;
    public GameObject menu;

    public Sprite sprite1;
    public Sprite sprite2;

    private Animator anim;
  

    private SpriteRenderer sprRend;
    public GameObject controllerKey;


    void Start()
    {
        startEnd = new Vector2(3.35f, -2.93f);
        stress += .30f;

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

            if (stress < 100 && transform.position.x <= startEnd.x)
            {
                stress += .05f;
                stressSlider.value = stress;
                sprRend.sprite = sprite1;


                if (stress < 24)
                {
                    cs.progress += .005f * Time.deltaTime;
                    anim.SetFloat("Stress", 25f);
                    Debug.Log("Reset");
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
                    cs.progress -= .000003125f * Time.deltaTime;
                    controllerKey.gameObject.SetActive(true);

                    Debug.Log("Accessed");
                   
                    
                }


            }


            //if (transform.position.x > farEnd.position.x && secondsForOneLength == 10 && Input.GetKey(KeyCode.D))
            //{
            //    transform.Translate(Vector2.right * -1 * Time.deltaTime);
            //    sprRend.sprite = sprite2;

            //}
            //else if (transform.position.y < startEnd.y)
            //{
            //    transform.Translate(Vector2.up * 1 * Time.deltaTime);
            //    secondsForOneLength += .2f;


            //    if (secondsForOneLength == 10)
            //    {
            //        secondsForOneLength = 10;
            //    }


            //}

            if (transform.position.x < farEnd.position.x && secondsForOneLength >= 10 && Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector2.left * -1 * Time.deltaTime);
                sprRend.sprite = sprite2;
                sprRend.flipX = true;

            }
            else if (transform.position.x > startEnd.x)
            {
                transform.Translate(Vector2.left * 1 * Time.deltaTime);
                secondsForOneLength += .2f;
                sprRend.flipX = false;


                if (secondsForOneLength == 10)
                {
                    secondsForOneLength = 10;
                }

                if (transform.position.x > 6)
                {
                    stress -= .5f;
                    stressSlider.value = stress;
                    cs.progress += 0;

                    if (stress < 0)
                    {
                        anim.SetFloat("Stress", 0f);
                        stress = 0;
                    }
                }





                if (transform.position.x >= startEnd.x)
                {
                    secondsForOneLength = 10;

                }
            }


        }
    }
}
