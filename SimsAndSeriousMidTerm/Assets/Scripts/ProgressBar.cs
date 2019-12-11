using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProgressBar : MonoBehaviour
{
    // Start is called before the first frame update

    public Slider progressSlider;
    public float progress;
    public GameObject Designer;
    public GameObject SoundDesigner;
    public GameObject Programmer;
    public GameObject Artist;
    public GameObject menu;
    public GameObject gameOver;
    public Text messages;
    public float events;

    public AudioClip gameOverNoise;
    public AudioSource gameSound;

    public Button restart;
    public float soundCount;

    public float Victory;
    void Start()
    {

        gameSound = GetComponent<AudioSource>();
        restart.gameObject.SetActive(false);
        
        Victory = 0f;
        soundCount = 0f;

        if (Time.deltaTime < 3)
        {
            messages.text = "Complete the Game Before Time Runs Out!";
        }

    }

    // Update is called once per frame
    void Update()
    {
       

        var ds = Designer.GetComponent<DesignerScript>();
        var ps = Programmer.GetComponent<ProgrammerScript>();
        var arts = Artist.GetComponent<ArtistScript>();
        var sd = SoundDesigner.GetComponent<SoundScript>();
        var pause = menu.GetComponent<PauseMenu>();

        gameOver.gameObject.SetActive(false);
      
        


        if (ds.stress > 50 && Victory == 0f)
        {
            progressSlider.value -= progress/2;
        }
        else if (ps.stress > 75 && Victory == 0f)
        {
            progressSlider.value -= progress/2;
        }
        else if (arts.stress > 75 && Victory == 0f)
        {
            progressSlider.value -= progress/2;
        }
        else if (sd.stress > 75 && Victory == 0f)
        {
            progressSlider.value -= progress/2;
        }


        if (ds.stress > 75 && Victory == 0f)
        {
            progressSlider.value -= progress;
            messages.text = "Your Designer's Stressed!";
            messages.enabled = true;
        }
        else if (ps.stress > 75 && Victory == 0f)
        {
            progressSlider.value -= progress;
            messages.text = "Your Programmer's \n Stressed!";
            messages.enabled = true;
        }
        else if (arts.stress > 75 && Victory == 0f)
        {
            progressSlider.value -= progress;
            messages.text = "Your Artist is Stressed!";
            messages.enabled = true;
        }
        else if (sd.stress > 75 && Victory == 0f)
        {
            progressSlider.value -= progress;
            messages.text = "You're Sound Designer's Stressed!";
            messages.enabled = true;
        }
        else if(Victory == 0f)
        {
            progressSlider.value += progress;
            messages.enabled = true;
            
        }
        
       
        if(ps.stress >= 100 && sd.stress >= 100 && arts.stress >= 100 && ds.stress >= 100 || progressSlider.value <= 0)
        {
            Victory = 3f;
            messages.text = "Your Team Got Stressed \n And Couldn't Finish!";
            messages.enabled = true;
            GameOverSound();
            gameOver.gameObject.SetActive(true);
            restart.gameObject.SetActive(true);
            
            
        }

        if(progressSlider.value >= 10000)
        {
            Victory = 1f;
            messages.text = "Your Team Completed The Game!";
            messages.enabled = true;
            progressSlider.value += 0;
           
        }

        if(pause.GameIsPaused == true)
        {
            Victory = 2f;
           
           
        }

        if(pause.GameIsPaused == false && progressSlider.value < 10000)
        {
            Victory = 0f;
        }


        events = Random.Range(1, 7500);

        if(events > 600 && events < 610 && progressSlider.value > 1000 && Victory == 0)
        {
            progressSlider.value -= 500;
            messages.text = "Your Programmer Had a Git Hub \n Error!";
            Debug.Log("GitHub Error!");
        }
        if (events == 1 && Victory == 0 || events == 250 && Victory == 0 || events == 500 && Victory == 0)
        {
            arts.stress = 0;
            ps.stress = 0;
            ds.stress = 0;
            sd.stress = 0;

            messages.text = "Someone Gave You A Pizza!";
        }

        if(events == 800 && Victory == 0)
        {
            progressSlider.value += 1000;
            messages.text = "You fixed a game breaking bug!";
            
        }

        if(events < 10 && Victory == 0)
        {
            ps.stress += 10;
            messages.text = "Programmer Made a New Bug";
        }

        if(events == 640)
        {
            sd.stress += 10;
            messages.text = "Audacity Crashed!";
        }

        Debug.Log(events);
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().name));
    }

    public void GameOverSound()
    {
        if(soundCount < 1)
        {
            gameSound.PlayOneShot(gameOverNoise, 1f);
            soundCount++;
        }
       
    }

    public void TimeCheck()
    {
        if (Time.deltaTime < 3)
        {
            messages.text = "Complete the Game Before Time Runs Out!";
        }
    }

    
    
}
