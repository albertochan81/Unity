using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSoundTrigger : MonoBehaviour
{
    public AudioSource hitSound;


	void OnCollisionEnter(Collision collision)
	{
	
			if (collision.gameObject.tag == "plane")
			{
				hitSound.Play();
				
			}

	}
}
