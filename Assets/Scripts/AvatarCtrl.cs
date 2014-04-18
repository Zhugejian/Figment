using UnityEngine;
using System.Collections;


public class AvatarCtrl : MonoBehaviour 
{
	
	protected Animator animator;
	
	public float DirectionDampTime = .25f;
	bool isDefault = true;

	public int Delay = 0;
	
	void Start () 
	{
		animator = GetComponent<Animator>();

		animator.SetBool("RunningFront", false);
		animator.SetBool("RunningBack", false);
		animator.SetBool ("FacingFront", false);
		animator.SetBool ("FacingBack", true);

	}

	void EnableAnimatorFlag(string flag)
	{
		animator.SetTrigger (flag);
	}

	void EnableDeathAnimatorFlag(string flag)
	{
		Debug.Log ("getting killed");
		animator.SetTrigger (flag);
		if (animator != null)
		{
			//animator.SetTrigger (flag);
			animator.SetBool (flag, true);
		}
		if (Delay >= 20)
		{
			animator.SetBool (flag, false);
			Delay = 0;
		}
	}
	
	void Update () 
	{
		Delay++;
		if(animator)
		{
			//get the current state
			AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

			//attack animation trigger
			if(Input.GetKeyDown(KeyCode.E))
			{
				animator.SetTrigger("AttackMove");
				//animator.SetBool("Attack", true );
			}
//			else
//			{
//				animator.SetBool("Attack", false);				
//			}
//
//			//attack back animation trigger
//			if(Input.GetKeyDown(KeyCode.E))
//			{
//				animator.SetBool("AttackBack", true );
//			}
//			else
//			{
//				animator.SetBool("AttackBack", false);				
//			}

			//back animation trigger
			if(Input.GetKeyDown(KeyCode.W))
			{
				animator.SetBool("RunningBack", true);
				animator.SetBool("FacingBack", true);
				animator.SetBool("FacingFront", false);
				if(Input.GetKeyDown(KeyCode.E))
				{
					animator.SetTrigger("AttackMove");
				}
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
					if(Input.GetKeyDown(KeyCode.A) && !(isDefault))
					{
						transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
						isDefault = true;
					}
					else if(Input.GetKeyDown(KeyCode.D) && (isDefault))
					{
						transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
						isDefault = false;
					}
					animator.SetBool("RunningFront", true);
				}
				else
				{
					if(Input.GetKeyDown(KeyCode.A) && (isDefault))
					{
						transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
						isDefault = false;
					}
					else if(Input.GetKeyDown(KeyCode.D) && !(isDefault))
					{
						transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
						isDefault = true;
					}
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
				if(Input.GetKeyDown(KeyCode.E))
				{
					Debug.Log ("attack move down");
					animator.SetTrigger("AttackMove");
				}
				else
				{
				    animator.SetBool("RunningFront", true);
				    animator.SetBool("FacingFront", true);
				    animator.SetBool("FacingBack", false);
				}

			}

			if(!(Input.GetKeyUp(KeyCode.S)))
			{
				if(Input.GetKeyDown(KeyCode.E))
				{
					Debug.Log ("attack move down");
					animator.SetTrigger("AttackMove");
				}
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
