using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesignerScript : MonoBehaviour
{
    public Transform farEnd;
    public Vector2 startEnd;
    public Slider stressSlider;
    public float progress = 1f;
    public GameObject progressSlider;
    public float stress;
    public float secondsForOneLength = 10f;

    public Sprite sprite1;
    public Sprite sprite2;

    public GameObject menu;
    public GameObject controllerKey;

    private SpriteRenderer sprRend;

    private Animator anim;

    public float count;


    void Start()
    {
        startEnd = new Vector2(-6.7f,-2.33f);
        stress += .05f;


        sprRend = GetComponent<SpriteRenderer>();


        anim = GetComponent<Animator>();


    }

    void Update()
    {
        var cs = progressSlider.GetComponent<ProgressBar>();
        var pause = menu.GetComponent<PauseMenu>();


        if (cs.Victory == 0f && pause.GameIsPaused != true)
        {
           

            if (stress < 100 && transform.position.x >= startEnd.x)
            {
                sprRend.sprite = sprite1;
                sprRend.flipX = true;
                stress += .04f;
                stressSlider.value = stress;

                controllerKey.gameObject.SetActive(false);

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


            if (transform.position.x > farEnd.position.x && secondsForOneLength == 10 && Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector2.left * 1 * Time.deltaTime);
                sprRend.flipX = false;
                sprRend.sprite = sprite2;
            }
            else if (transform.position.x < startEnd.x)
            {
                transform.Translate(Vector2.left * -1 * Time.deltaTime);
                secondsForOneLength += .2f;
                sprRend.sprite = sprite2;
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





            if (transform.position.y >= startEnd.x)
            {
                secondsForOneLength = 10;

            }
        }
       
    }

    void ObjectIsEnabled()
    {
        while (count < 10)
        {
            controllerKey.gameObject.SetActive(true);
            count += Time.deltaTime;
        }
        
    }
}
