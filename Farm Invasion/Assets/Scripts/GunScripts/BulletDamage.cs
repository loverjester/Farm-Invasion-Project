using UnityEngine;
using System.Collections;

public class BulletDamage : MonoBehaviour {

	public float bulletDamage;

	public Rigidbody2D rigid;

	public Vector2 speed;
	public Vector3 direction;
	
	private Vector2 mouvement;
	
	void OnEnable()
	{
		GameObject ammoParent = GameObject.FindGameObjectWithTag("Ammo");

		direction = ammoParent.transform.forward;

	    float x = speed.x * direction.x;
	    float y = speed.y * direction.y;

	    mouvement = new Vector2 (x, y);
		Invoke ("setInactive", 3f);
		rigid.velocity = mouvement;
	}
	
	void setInactive()
	{	
		gameObject.SetActive (false);	
	}
	
	void OnDisable()
	{	
		CancelInvoke ();	
	}

	void OnTriggerEnter2D(Collider2D otherCollider){
	
		EnemyHealth enemy = otherCollider.gameObject.GetComponent<EnemyHealth>();

		if (enemy != null) {
			enemy.enemyHealth -= bulletDamage;
			gameObject.SetActive(false);
		}
		
	}

}
