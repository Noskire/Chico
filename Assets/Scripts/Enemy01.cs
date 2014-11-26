using UnityEngine;
using System.Collections;

public class Enemy01 : MonoBehaviour{
	//Enemy Attributes
	public int experience, hp, speed, meleeDamage, rangedDamage;
	public Vector2 meleeRange; //Range of melee attack
	public Transform shotPrefab; //Prefab of projectile
	public int frames = 0;

	void Start(){
		experience = 10;
		hp = 25;
		speed = 4;
		meleeDamage = 5;
		rangedDamage = 5;
		meleeRange.x = 1;
		meleeRange.y = 1;
	}
	
	void Update(){
		if(hp > 0){
			frames++;
			if(frames % 60 == 0){
				var shotTransform = Instantiate(shotPrefab) as Transform;
				shotTransform.position = transform.position;
				Shot shot = shotTransform.gameObject.GetComponent<Shot>();
				if(shot != null){
					shot.damage = rangedDamage;
					shot.isEnemyShot = true;
					shot.toTheRight = false;
				}
			}
		}
	}

	public void getHit(int damage){
		if(hp > 0){// && !animator.GetCurrentAnimatorStateInfo(0).IsName("Defend")){
			//animator.SetBool("Hit", true);
			hp -= damage;
			if(hp <= 0){ //Dead!
				//animator.SetBool("Dead", true);
				hp = 0;
				//GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
				GameObject player = GameObject.FindGameObjectWithTag("Player");
				player.GetComponent<Player>().addExp(experience);
				Destroy(gameObject, 3);
			}
		}
	}
}
