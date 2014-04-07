using UnityEngine;
using System.Collections;


public class AvatarCtrl : MonoBehaviour 
{
	
	protected Animator animator;
	
	public float DirectionDampTime = .25f;
	
	void Start () 
	{
		animator = GetComponent<Animator>();
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
				animator.SetBool("FacingBack", true);
			}
			else
			{
				animator.SetBool("FacingBack", false);
			}

			//front animation trigger
			if(Input.GetKeyDown(KeyCode.S))
			{
				animator.SetBool("FacingFront", true);
			}
			else
			{
				animator.SetBool("FacingFront", false);
			}
			
			//float h = Input.GetAxis("Horizontal");
			//float v = Input.GetAxis("Vertical");
			
			//set event parameters based on user input
			//animator.SetFloat("Speed", h*h+v*v);
			//animator.SetFloat("Direction", h, DirectionDampTime, Time.deltaTime);
		}		
	}   		  
}
