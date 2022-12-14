using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.CoreUtils;

public class IgnoreCollision : MonoBehaviour
{
    
   // private GameObject player;
    //private GameObject object;

      void OnCollisionEnter(Collision collision){
    
        if (collision.gameObject.tag == "Player") {
        Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
      }

    void Start()
    {
       
    }
    
    // Update is called once per frame
    void Update()
    {
           
  
    }
    
}
