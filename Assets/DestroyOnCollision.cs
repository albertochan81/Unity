using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyOnCollision : MonoBehaviour
{
    public AudioSource playSound;
    public AudioSource playSound2;
    public GameObject Chicken; 
    public GameObject addTimeCanvas; 
    bool InCoRoutine;

    void Start()
    {
        playSound.Play();

    }

    void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.tag == "rock")
        {   playSound2.Play();
            Chicken.GetComponent<ChickenAnim>().Run();
            
            if(!InCoRoutine)
            StartCoroutine(DoSomething());

        }
    }
        

    IEnumerator DoSomething ()
    {
        InCoRoutine = true;
        yield return new WaitForSeconds(.8f);
        addTimeCanvas.GetComponent<CanvasAppear>().addTime();

        
        Destroy(Chicken);
        InCoRoutine = false;
        
    }
   


}
