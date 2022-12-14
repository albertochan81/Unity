using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using Unity.XR.CoreUtils;

[RequireComponent(typeof(Rigidbody))]

public class XRPlayerController : MonoBehaviour
{

    [SerializeField] private InputActionReference jumpActionReference;
    [SerializeField] private float jumpForce = 500.0f;

    public InputAction jump;
    private Vector3 pushDir;
    private float pushForce;
    private bool canMove = true; //If player is not hitted
	private bool isStuned = false;
	private bool wasStuned = false; //If player was stunned before get stunned another time
  private bool slide = false;
  public float gravity = 10.0f;
	

    

    private XROrigin _xrRig;
    private CapsuleCollider _collider;
    private Rigidbody _body;
    private float distToGround;
    


    //private bool IsGrounded => Physics.Raycast(
       // new Vector2(transform.position.x, transform.position.y + 2f),
       // Vector3.down, 2f);
      private bool IsGrounded =>  Physics.Raycast(transform.position, -Vector3.up, distToGround + .001f);
    

        

    // Start is called before the first frame update
    void Start()
    {
        distToGround = GetComponent<Collider>().bounds.extents.y;
         _body = GetComponent <Rigidbody>();
         _xrRig = GetComponent<XROrigin>();
         _collider = GetComponent<CapsuleCollider>();

        jumpActionReference.action.performed += OnJump;
       //jump.Enable();
        //jump.performed += OnJump;
    }
     
    // Update is called once per frame
     void Update()
    {
        //var center = _xrRig.OriginInCameraSpacePos;
        var center = _xrRig.CameraInOriginSpacePos;

       // _collider.center = new Vector3(center.x, _collider.center.y, center.z);
         _collider.center = new Vector3(center.x, _collider.height/2, center.z);
       // _collider.height = _xrRig.CameraInOriginSpaceHeight;
        _collider.height = Mathf.Clamp(_xrRig.CameraInOriginSpaceHeight, .5f, 5f);
    }
    
    private void OnJump(InputAction.CallbackContext obj)
    {
         if(!IsGrounded) return;
         _body.AddForce(Vector3.up * jumpForce);
    }

    public void HitPlayer(Vector3 velocityF, float time)
	{
    //Vector3 velocity = rb.velocity;
		_body.velocity = velocityF;

		pushForce = velocityF.magnitude;
		pushDir = Vector3.Normalize(velocityF);
		StartCoroutine(Decrease(velocityF.magnitude, time));
	}

  private IEnumerator Decrease(float value, float duration)
	{
		if (isStuned)
			wasStuned = true;
		isStuned = true;
		canMove = false;

		float delta = 0;
		delta = value / duration;

		for (float t = 0; t < duration; t += Time.deltaTime)
		{
			yield return null;
			if (!slide) //Reduce the force if the ground isnt slide
			{
				pushForce = pushForce - Time.deltaTime * delta;
				pushForce = pushForce < 0 ? 0 : pushForce;
				//Debug.Log(pushForce);
			}
			_body.AddForce(new Vector3(0, -gravity * GetComponent<Rigidbody>().mass, 0)); //Add gravity
		}

		if (wasStuned)
		{
			wasStuned = false;
		}
		else
		{
			isStuned = false;
			//canMove = true;
		}
	}
}


