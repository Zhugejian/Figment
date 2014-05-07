using UnityEngine;
using System.Collections;


public class ChestCtrl : MonoBehaviour 
{
	public static bool IsOpened = false;
	protected Animator animator;
	public ItemUpdate IU;
	
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
			if((Application.loadedLevelName != "Game Over") && (Application.loadedLevelName != "MainMenu") && (Application.loadedLevelName != "Victory") && (Application.loadedLevelName != "OpeningCinematic2"))
			{
				ppos = GameObject.FindWithTag ("Player").transform.position;
			}

			if (Input.GetKeyDown (KeyCode.F))
			{
				if(IU.dropItem()) {
					ppos.y = 5;
					this.transform.position = ppos;
					IU.dropItem();
				}
//				if(GameObject.FindGameObjectWithTag("Item Cube") != null) {
//					GameObject dropper = GameObject.FindGameObjectWithTag("Item Cube");
//				SendMessageUpwards("dropItem", SendMessageOptions.DontRequireReceiver);
//				}
//				if(ppos != this.transform.position)
//				{
//					Debug.Log (IsOpened);
//					animator.SetBool("IsOpened", false );
//				}

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
		}		
	}   		  
}
