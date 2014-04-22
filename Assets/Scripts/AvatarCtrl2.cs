using UnityEngine;
using System.Collections;


public class AvatarCtrl2 : MonoBehaviour 
{

	bool isDefault = true;
	bool FacingBack = true;
	bool FacingLeft = true;
	bool NotStarted = true;
	
	protected Animator animator;
	
	//public float DirectionDampTime = .25f;

	void Start () 
	{
		animator = GetComponent<Animator>();

	}
	
	void EnableAnimatorFlag(string flag)
	{
		// flag should be "Hit"?
		animator.SetTrigger (flag);
	}
	
	void EnableDeathAnimatorFlag(string flag)
	{
		// flag should be "Killed"
		animator.SetTrigger (flag);
	}
	
	void Update () 
	{
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

//				if(FacingLeft && !(FacingBack) && !(isDefault))
//				{
//					transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
//					isDefault = true;
//				}
//				if(!(FacingLeft) && !(FacingBack) && isDefault)
//				{
//					transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
//					isDefault = false;
//				}
				
				animator.SetTrigger("Attacking");
			}


//			if((Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)) && (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)) && (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)) && (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)))
//			{
//				animator.SetTrigger("Idling");
//				animator.SetBool("MovingBack", false);
//				animator.SetBool("MovingFront", false);
//			}


//
//			
//			//back animation trigger
//			if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
//			{
//				animator.SetBool("RunningBack", true);
//				animator.SetBool("FacingBack", true);
//				animator.SetBool("FacingFront", false);
//				if(Input.GetKeyDown(KeyCode.H))
//				{
//					animator.SetTrigger("AttackMove");
//				}
//			}
//			
//			if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
//			{
//				if(animator.GetBool("FacingFront"))
//				{
//					if((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && !(isDefault))
//					{
//						transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
//						isDefault = true;
//					}
//					else if(Input.GetKeyDown(KeyCode.D) && (isDefault))
//					{
//						transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
//						isDefault = false;
//					}
//					animator.SetBool("RunningFront", true);
//				}
//				else
//				{
//					if((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && (isDefault))
//					{
//						transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
//						isDefault = false;
//					}
//					else if(Input.GetKeyDown(KeyCode.D) && !(isDefault))
//					{
//						transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
//						isDefault = true;
//					}
//					animator.SetBool("RunningBack", true);
//				}
//			}
//			
//			if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
//			{
//				if(animator.GetBool("FacingFront"))
//				{
//					animator.SetBool("RunningFront", false);
//				}
//				else
//				{
//					animator.SetBool("RunningBack", false);
//				}
//			}
//			
//			//done running
//			if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
//			{
//				animator.SetBool ("RunningBack", false);
//			}
//			
//			//front animation trigger
//			if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
//			{
//				if(Input.GetKeyDown(KeyCode.H))
//				{
//					animator.SetTrigger("AttackMove");
//				}
//				else
//				{
//					animator.SetBool("RunningFront", true);
//					animator.SetBool("FacingFront", true);
//					animator.SetBool("FacingBack", false);
//				}
//				
//			}
//			
//			if(!(Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)))
//			{
//				if(Input.GetKeyDown(KeyCode.H))
//				{
//					Debug.Log ("attack move down");
//					animator.SetTrigger("AttackMove");
//				}
//			}
//			
//			if(!(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)))
//			{
//				if(Input.GetKeyDown(KeyCode.H))
//				{
//					Debug.Log ("attack move up");
//					animator.SetTrigger("AttackMove");
//				}
//			}
//			
//			//done running
//			if(Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
//			{
//				animator.SetBool ("RunningFront", false);
//			}
		}		
	}   		  
}
