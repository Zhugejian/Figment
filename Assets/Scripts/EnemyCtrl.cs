using UnityEngine;
using System.Collections;

public class EnemyCtrl : MonoBehaviour {

	protected Animator animator;
//	Damageable damage;
//	int health;
	
	public float DirectionDampTime = .25f;

	// Use this for initialization
	void Start () {
//		damage = this.gameObject.GetComponent(typeof(Damageable)) as Damageable;
//		health = 3;//damage.Health;
		animator = GetComponent<Animator>();

	}

	public void EnableEnemyHitAnimatorFlag(string flag)
	{
		Debug.Log ("enemy hit?");
		animator.SetTrigger (flag);
	}

	void EnableEnemyAttackAnimatorFlag(string flag)
	{
		animator.SetTrigger (flag);
	}

	// Update is called once per frame
	void Update () {
		if (animator)
		{

			//get the current state
			AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo (0);

//			if(damage.Health != health)
//			{
//				animator.SetBool("Damaged", true );
//				health = damage.Health;
//			}
//			else
//			{
//				animator.SetBool("Damaged", false);
//			}
		}
	}
}
