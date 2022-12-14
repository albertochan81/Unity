using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSFX2 : MonoBehaviour
{
    public AudioSource playSound;
    public float timerForNewPath;
    bool InCoRoutine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!InCoRoutine)
        StartCoroutine(DoSomething());
    }
    

     IEnumerator DoSomething ()
    {
        InCoRoutine = true;
        yield return new WaitForSeconds(timerForNewPath);
        playSound.Play();
        InCoRoutine = false;

    }
}

