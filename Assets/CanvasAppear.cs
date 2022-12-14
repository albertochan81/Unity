using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CanvasAppear : MonoBehaviour
{
    public AudioSource sound;
    public GameObject addTimeCanvas;
     public GameObject timerCanvas;

    bool InCoRoutine;
    
    // Start is called before the first frame update
    void Start()
    {
        addTimeCanvas.SetActive(false);
    }
   
    // Update is called once per frame
    public void addTime()
    {  
       
        addTimeCanvas.SetActive(true);
        sound.Play();
        timerCanvas.GetComponent<Timer>().addTime();

        if(!InCoRoutine)
        StartCoroutine(DoSomething());
 
    }

    IEnumerator DoSomething ()
    {
        InCoRoutine = true;
        yield return new WaitForSeconds(1.5f);
        
        addTimeCanvas.SetActive(false);
        InCoRoutine = false;
    }
}
