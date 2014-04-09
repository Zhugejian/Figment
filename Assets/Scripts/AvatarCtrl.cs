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
				animator.SetBool("RunningBack", true);
			}
			else
			{
				animator.SetBool("RunningBack", false);
			}

			//front animation trigger
			while(Input.GetKeyDown(KeyCode.S))
			{
				animator.SetBool("RunningFront", true);
			}
			/*else
			{
				animator.SetBool("RunningFront", false);
			}*/

			
			//float h = Input.GetAxis("Horizontal");
			//float v = Input.GetAxis("Vertical");
			
			//set event parameters based on user input
			//animator.SetFloat("Speed", h*h+v*v);
			//animator.SetFloat("Direction", h, DirectionDampTime, Time.deltaTime);
		}		
	}   		  
}
