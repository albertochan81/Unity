using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EagleAnim : MonoBehaviour
{

     
	public Animator animator;
   // public GameObject eagle;

    // Start is called before the first frame update
    void Start()
    {
        animator.SetFloat("Speed", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
