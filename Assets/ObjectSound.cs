using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSound : MonoBehaviour
{
    public AudioSource hitSound;
	public AudioSource fallSound;
	public AudioSource rockSound;

	void OnCollisionEnter(Collision collision)
	{
	
			//Debug.DrawRay(contact.point, contact.normal, Color.white);
			if (collision.gameObject.tag == "player")
			{
				hitSound.Play();
				
			}
			if (collision.gameObject.tag == "plane")
			{
				fallSound.Play();
			}
			if (collision.gameObject.tag == "rock")
			{
				rockSound.Play();
			}
	

	}
}
