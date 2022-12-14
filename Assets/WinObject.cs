using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//GetComponent<Timer>().Finish();

public class WinObject : MonoBehaviour
{

   private void OnTriggerEnter (Collider other)
   {
     GameObject.Find("TimeCanvas").GetComponent<Timer>().Finish();
      
   }
}
