using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {
	
	public float nextSpawn;
	public Transform cow;
	public Transform chicken;
	public Transform currentEnemy;
	public int enemyType;

	private int minSpawnTime;
	private int maxSpawnTime;

	void Start() {

		minSpawnTime = 2;
		maxSpawnTime = 10;
		nextSpawn = Random.Range(minSpawnTime, maxSpawnTime);

	}
	
	void Update () {
		 
		if (nextSpawn < 15) {
			nextSpawn += Time.deltaTime;
		} else {

			float currentEnemyHealth = 0f;
			int currentEnemyXp = 0;
			int currentEnemyMoney = 0;
			int min = 1;
		    int max = 3;
			enemyType = Random.Range(min, max);

			if (enemyType == 1){
				currentEnemy = cow;
				currentEnemyHealth = 40f;
				currentEnemyXp = 6;
				currentEnemyMoney = 10;

			}
			if (enemyType == 2){
				currentEnemy = chicken;
				currentEnemyHealth = 20f;
				currentEnemyXp = 3; 
				currentEnemyMoney = 5;
			}

			Transform newEnemy = Instantiate(currentEnemy, transform.position, transform.rotation) as Transform;
			EnemyHealth enemyHp = newEnemy.gameObject.GetComponent<EnemyHealth>();
			enemyHp.enemyHealth = currentEnemyHealth;
			enemyHp.enemyMoney = currentEnemyMoney;
			enemyHp.enemyXp = currentEnemyXp;
		
			MoveScript move = newEnemy.gameObject.GetComponent<MoveScript>();

			nextSpawn = Random.Range(minSpawnTime, maxSpawnTime);

				if (move != null){
					move.speed = new Vector2(1, 1);
					move.direction = new Vector2(-1, 0);
			
			} 
				
		}
	}
}
