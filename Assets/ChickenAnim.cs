using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChickenAnim : MonoBehaviour
{

     
	public Animator animator;
    public float timerForAnim;
    public float timerForAnim2;
    bool InCoRoutine;

    // Start is called before the first frame update
    void Start()
    {
        //animator.SetFloat("Speed", 1);
       
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
        yield return new WaitForSeconds(timerForAnim);
        animator.SetTrigger("Turn Head");
        yield return new WaitForSeconds(2f);
        animator.SetBool("Turn Head", false);
        yield return new WaitForSeconds(timerForAnim);
        animator.SetTrigger("Eat");
        yield return new WaitForSeconds(2f);
        animator.SetBool("Eat", false);
        InCoRoutine = false;
        
    }

    public void Run()
    {
        animator.SetTrigger("Run");
    }

}
