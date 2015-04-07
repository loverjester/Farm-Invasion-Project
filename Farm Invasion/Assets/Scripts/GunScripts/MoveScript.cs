using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {
	
	public Rigidbody2D rigid; 
	public Vector2 speed;
	public Vector2 direction;
	
	public int EnemyDamage;
	public float CooldownTimer;
	public float Cooldown;

	private PlayerHealth playerHealthScript;
	private Vector2 mouvement;
	private bool hasReachedPlayer;
	
	void Start () {

		playerHealthScript = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerHealth> ();
		float x = speed.x * direction.x;
		float y = speed.y * direction.y;

		mouvement = new Vector2 (x, y);
	}

	void Update(){
	
		if (hasReachedPlayer == true) 
		{
			Cooldown -= Time.deltaTime;
		}
		if (hasReachedPlayer == true && Cooldown <= 0) 
		{
			AttackPlayer();
		}
	
	}

	void FixedUpdate() {

		if (hasReachedPlayer != true) {
			rigid.velocity = mouvement;
		}
	}

	void OnTriggerEnter2D(Collider2D otherCollider){

		
		if (otherCollider.tag == "AnimalsBarrier") {

			rigid.velocity = new Vector2(0f, 0f);
			hasReachedPlayer = true;
		}
		
	}

	void AttackPlayer(){

		playerHealthScript.playerHealth -= EnemyDamage;
		Cooldown = CooldownTimer;
	
	}

}
