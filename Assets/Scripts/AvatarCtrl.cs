using UnityEngine;
using System.Collections;


public class AvatarCtrl : MonoBehaviour 
{
	
	protected Animator animator;
	
	public float DirectionDampTime = .25f;
	//bool defaultAnim = true;
	
	void Start () 
	{
		animator = GetComponent<Animator>();

		animator.SetBool("RunningFront", false);
		animator.SetBool("RunningBack", false);
		animator.SetBool ("FacingFront", false);
		animator.SetBool ("FacingBack", true);

	}
	
	void Update () 
	{
		if(animator)
		{
			//get the current state
			AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

			//attack animation trigger
			if(Input.GetKeyDown(KeyCode.E))
			{
				animator.SetBool("Attack", true );
			}
			else
			{
				animator.SetBool("Attack", false);				
			}

			//attack back animation trigger
			if(Input.GetKeyDown(KeyCode.E))
			{
				animator.SetBool("AttackBack", true );
			}
			else
			{
				animator.SetBool("AttackBack", false);				
			}

			//back animation trigger
			if(Input.GetKeyDown(KeyCode.W))
			{
				animator.SetBool("RunningBack", true);
				animator.SetBool("FacingBack", true);
				animator.SetBool("FacingFront", false);
			}

			if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
			{
//				if(Input.GetKeyDown(KeyCode.A))
//				{
//					if(!(defaultAnim))
//					{
//						if(animator.GetBool("FacingFront"))
//						{
//						    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
//						}
//					}
//					defaultAnim = true;
//				}
//				else if(Input.GetKeyDown(KeyCode.D))
//				{
//					if(defaultAnim)
//					{
//						if(!(animator.GetBool("FacingFront")))
//						{
//							transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
//						}
//					}
//					defaultAnim = false;
//				}
				if(animator.GetBool("FacingFront"))
				{
					animator.SetBool("RunningFront", true);
				}
				else
				{
					animator.SetBool("RunningBack", true);
				}
			}

			if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
			{
				if(animator.GetBool("FacingFront"))
				{
					animator.SetBool("RunningFront", false);
				}
				else
				{
					animator.SetBool("RunningBack", false);
				}
			}

			//done running
			if(Input.GetKeyUp(KeyCode.W))
			{
				animator.SetBool ("RunningBack", false);
			}

			//front animation trigger
			if(Input.GetKeyDown(KeyCode.S))
			{
				animator.SetBool("RunningFront", true);
				animator.SetBool("FacingFront", true);
				animator.SetBool("FacingBack", false);
			}

			//done running
			if(Input.GetKeyUp(KeyCode.S))
			{
				animator.SetBool ("RunningFront", false);
			}

			
			//float h = Input.GetAxis("Horizontal");
			//float v = Input.GetAxis("Vertical");
			
			//set event parameters based on user input
			//animator.SetFloat("Speed", h*h+v*v);
			//animator.SetFloat("Direction", h, DirectionDampTime, Time.deltaTime);
		}		
	}   		  
}
