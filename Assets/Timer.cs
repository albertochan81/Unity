using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI uiText; 
 

    private float mainTimer;

    public float TimeLeft;
    public float TimeInYellow;
    
    public bool TimerOn= false;
    public bool finished = false;
    

    // Start is called before the first frame update
    void Start()
    {
        TimerOn = true;
    }
    

    // Update is called once per frame
    void Update()
    {

        if (TimerOn)
        {

            if((TimeLeft >0) && (TimeLeft > TimeInYellow))
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }

            else if ((TimeLeft >0) && (TimeLeft <= TimeInYellow))
            {
                 //Debug.Log("Time is UP!")
                  
                  uiText.color = Color.yellow;
                  TimeLeft -= Time.deltaTime;
                  
                  updateTimer(TimeLeft);
            }

            else 
             {
               //Debug.Log("Time is UP!")
               TimeLeft=0;
               TimerOn = false;
               TimeEnd();
             }
        }
        
    }


    void updateTimer (float currentTime)
    {
        if (finished)
             return;

        currentTime +=1;
        float minutes = Mathf.FloorToInt ( currentTime/ 60);
        float seconds = Mathf.FloorToInt ( currentTime % 60);

        uiText.text = "Time: " + string.Format ("{0:00} : {1:00}", minutes, seconds);
    }
    
    public void addTime()
    {
         TimeLeft = TimeLeft +Time.deltaTime +20f;
         
    }
    
    public void TimeEnd()
    {
        uiText.color = Color.red;
    
        SceneManager.LoadScene("EndMenu");
    }
    public void Finish()
    {
            finished = true;
            uiText.color = Color.green;
      
            SceneManager.LoadScene("Congratulations");
    }

}