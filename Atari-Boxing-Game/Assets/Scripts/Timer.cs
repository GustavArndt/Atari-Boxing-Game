using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timerCountdown ;
    public float seconds, minutes ;
    public float timerSpeed ;
    public bool startCountdown ;
    // Start is called before the first frame update
    void Start()
    {
        seconds = 00 ;
        timerSpeed= 3;
        minutes = 2 ;
        timerCountdown.text = "2:00";

        startCountdown = false ;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if(startCountdown == true){
            seconds -= Time.deltaTime ;
            timerCountdown.text = minutes.ToString() + ":" + Mathf.Round(seconds).ToString();
            if(seconds <= 9){
                timerCountdown.text = minutes.ToString() + ":0" + Mathf.Round(seconds).ToString();
            }
        }
        
        if(Input.anyKeyDown && minutes == 2){
            startCountdown = true ;
            minutes -= 1 ;
            seconds = 59 ;
        }

        if(seconds <= 0 && startCountdown == true){
            seconds = 60 ;
            minutes -= 1 ;
        }

        if(timerCountdown.text == "0:00"){
            seconds = 0 ;
            minutes = 0 ;
            startCountdown = false ;
            MovementPlayerTwo.speed = 0;
            MovementPlayerOne.speed = 0;
            
            if(Input.anyKeyDown){
                SceneManager.LoadScene("SampleScene") ;
            }
        }
    }
}
