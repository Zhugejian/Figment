using UnityEngine;
using System.Collections;

public class EnemyCtrl : MonoBehaviour {

	protected Animator animator;
	Damageable damage;
	int health;
	
	public float DirectionDampTime = .25f;

	// Use this for initialization
	void Start () {
		damage = this.gameObject.GetComponent(typeof(Damageable)) as Damageable;
		health = 3;//damage.Health;
		animator = GetComponent<Animator>();
		animator.SetBool("Damaged", false );
		if (animator == null) {
						Debug.Log ("null animator");
				}
	}

	void EnableEnemyHitAnimatorFlag(string flag)
	{
		Debug.Log ("enemy hit");
		if (animator != null)
		{
			animator.SetTrigger (flag);
			//animator.SetBool (flag, true);
		}
		if (animator == null) {
			Debug.Log ("null animator");
		}
	}

	void EnableEnemyAttackAnimatorFlag(string flag)
	{
		Debug.Log ("enemy attack");
		if (animator != null)
		{
			Debug.Log ("enemy attack again");
			animator.SetTrigger (flag);
			//animator.SetBool (flag, true);
		}

		if (animator == null) {
			Debug.Log ("null attack animator");
		}
	}

	// Update is called once per frame
	void Update () {
		if (animator)
		{

			//get the current state
			AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo (0);

			if(damage.Health != health)
			{
				animator.SetBool("Damaged", true );
				health = damage.Health;
			}
			else
			{
				animator.SetBool("Damaged", false);
			}
		}
	}
}
