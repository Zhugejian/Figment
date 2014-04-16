using UnityEngine;
using System.Collections;


public class ChestCtrl : MonoBehaviour 
{
	public static bool IsOpened = false;
	protected Animator animator;
	
	public float DirectionDampTime = .25f;
	
	void Start () 
	{
		animator = GetComponent<Animator>();
		
		animator.SetBool("IsOpened", false);
		
	}
	
	void Update () 
	{

		if(animator)
		{
			Vector3 ppos = this.transform.position;
			if((Application.loadedLevelName != "Game Over") && (Application.loadedLevelName != "MainMenu") && (Application.loadedLevelName != "Victory"))
			{
				ppos = GameObject.FindWithTag ("Player").transform.position;
			}

			if (Input.GetKeyDown (KeyCode.F))
			{
//				if(ppos != this.transform.position)
//				{
//					Debug.Log (IsOpened);
//					animator.SetBool("IsOpened", false );
//				}
				ppos.y = 5;
				this.transform.position = ppos;
			}

			//get the current state
			AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
			
			//attack animation trigger
			if(Input.GetKeyDown(KeyCode.F))
			{
				animator.SetBool("IsOpened", true );
//				if(animator.GetBool("IsOpened") == false)
//				{
//					animator.SetBool("IsOpened", true );
//				}
//				else
//				{
//					animator.SetBool("IsOpened", false);
//			    }
			}
			
			//float h = Input.GetAxis("Horizontal");
			//float v = Input.GetAxis("Vertical");
			
			//set event parameters based on user input
			//animator.SetFloat("Speed", h*h+v*v);
			//animator.SetFloat("Direction", h, DirectionDampTime, Time.deltaTime);
		}		
	}   		  
}
