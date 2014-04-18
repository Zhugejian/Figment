using UnityEngine;
using System.Collections;


public class MemoryCtrl : MonoBehaviour 
{
	//public static bool IsOpened = false;
	protected Animator animator;
	
	public float DirectionDampTime = .25f;
	
	void Start () 
	{
		animator = GetComponent<Animator>();
		
		//animator.SetBool("IsOpened", false);
		
	}

	public void EnableOpenChestAnimatorFlag(string flag)
	{
		animator.SetTrigger (flag);
	}
	
	void Update () 
	{
		
		if(animator)
		{
			
			//get the current state
			AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
			
			//attack animation trigger
//			if(Input.GetKeyDown(KeyCode.F))
//			{
//				animator.SetBool("IsOpened", true );
//			}
			
			//float h = Input.GetAxis("Horizontal");
			//float v = Input.GetAxis("Vertical");
			
			//set event parameters based on user input
			//animator.SetFloat("Speed", h*h+v*v);
			//animator.SetFloat("Direction", h, DirectionDampTime, Time.deltaTime);
		}		
	}   		  
}
