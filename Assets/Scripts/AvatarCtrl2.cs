using UnityEngine;
using System.Collections;


public class AvatarCtrl2 : MonoBehaviour 
{
	public Shoot sh;
	public PartAbsorby pa;
	bool isDefault = true;
	bool FacingBack = true;
	bool FacingLeft = true;
	bool NotStarted = true;

	bool isReadying = false;
	public float ReadiedPower = 0.5f;

	GameObject bullet;

	protected Animator animator;

	void Start () 
	{
		animator = GetComponent<Animator>();
	}
	
	void EnablePlayerHitAnimatorFlag(string flag)
	{
		// flag should be "Hit"
		animator.SetTrigger (flag);
	}
	
	void EnablePlayerDeathAnimatorFlag(string flag)
	{
		// flag should be "Killed"
		animator.SetTrigger (flag);
	}
	
	void Update () 
	{
		GameObject scal = GameObject.Find ("ParticleCube");
		scal.SendMessage ("updateScaler", ReadiedPower, SendMessageOptions.DontRequireReceiver);
		if(isReadying && (ReadiedPower < 8f))
		{
			ReadiedPower = ReadiedPower + 0.05f;
		}
		if(animator)
		{
			//get the current state
			AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

			if((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && (NotStarted))
			{
				animator.SetBool("MovingBack", true);
				NotStarted = false;
			}

			if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
			{
				if(FacingLeft && isDefault)
				{
					transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
					isDefault = false;
				}
				if(!(FacingLeft) && !(isDefault))
				{
					transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
					isDefault = true;
				}
				animator.SetBool("MovingBack", true);
				animator.SetBool("MovingFront", false);
				NotStarted = false;
				FacingBack = true;
			}
//			if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
//			{
//				animator.SetBool("MovingBack", false);
//			}
			if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
			{
				if(FacingLeft && !(isDefault))
				{
					transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
					isDefault = true;
				}
				if(!(FacingLeft) && isDefault)
				{
					transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
					isDefault = false;
				}
				animator.SetBool("MovingFront", true);
				animator.SetBool("MovingBack", false);
				NotStarted = false;
				FacingBack = false;
			}
//			if(Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
//			{
//				animator.SetBool("MovingFront", false);
//			}



			if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
			{
				FacingLeft = true;
				if(FacingBack && isDefault)
				{
					transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
					isDefault = false;
				}
				if(!(FacingBack) && !(isDefault))
				{
					transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
					isDefault = true;
				}
			}

			if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
			{
				FacingLeft = false;
				if(FacingBack && !(isDefault))
				{
					transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
					isDefault = true;
				}
				if(!(FacingBack) && isDefault)
				{
					transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
					isDefault = false;
				}
			}

			//attack animation trigger
			if(Input.GetKeyDown(KeyCode.H))
			{
				if(FacingLeft && !(isDefault))
				{
					transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
					isDefault = true;
				}

				if(!(FacingLeft) && isDefault)
				{
					transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
					isDefault = false;
				}

				animator.SetTrigger("Priming");
				isReadying = true;

				pa.ParticlesAppear();
				//BroadcastMessage("ParticlesAppear", SendMessageOptions.DontRequireReceiver);
			}

			if(isReadying)
			{

				if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && FacingLeft && !(isDefault))
				{
					Debug.Log ("ul got called");
					transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
					isDefault = true;
//					sh.changeDir("ul");
				}

				if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && !(FacingLeft) && isDefault)
				{
					transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
					isDefault = false;
//					sh.changeDir("ur");
				}

				if((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && FacingLeft && !(isDefault))
				{
					transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
					isDefault = true;
					Debug.Log ("got called");
//					sh.direction = "dl";
				}

				if((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && !(FacingLeft) && isDefault)
				{
					transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
					isDefault = false;
//					sh.direction = "dr";
				}

				if((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && !(isDefault))
				{
					transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
					isDefault = true;
//					sh.direction = "left";
				}

				if((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && isDefault)
				{
					transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
					isDefault = false;
//					sh.direction = "right";
				}
				SendMessageUpwards("MoveSpeedUpdate", 8, SendMessageOptions.DontRequireReceiver);
			}

			if(Input.GetKeyUp (KeyCode.H))
			{
				animator.SetTrigger("Releasing");
				SendMessageUpwards("EnablePlayerMeleeFlag", ReadiedPower, SendMessageOptions.DontRequireReceiver);
				SendMessageUpwards("MoveSpeedUpdate", 20, SendMessageOptions.DontRequireReceiver);
				Debug.Log(ReadiedPower);
				isReadying = false;
				ReadiedPower = 0.5f;
				pa.ParticlesDisappear();
				//SendMessage("ParticlesDisappear", SendMessageOptions.DontRequireReceiver);
			}


//			if((Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)) && (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)) && (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)) && (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)))
//			{
//				animator.SetTrigger("Idling");
//				animator.SetBool("MovingBack", false);
//				animator.SetBool("MovingFront", false);
//			}


		}		
	}   		  
}
