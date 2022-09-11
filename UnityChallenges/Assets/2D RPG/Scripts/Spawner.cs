using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public Vector2 minPos;
	public Vector2 maxPos;
	public Vector2 spawnPos;
	public GameObject zombie;
	public float cooldown;
	public float cooldownDefault;
	public float cooldownDecrease;
	
	void Update(){
		cooldown -= Time.deltaTime;
		
		if(cooldown <= 0){
			Spawn();
			cooldownDefault -= cooldownDecrease;
			cooldown = cooldownDefault;
		}
	}
	
	public void Spawn(){
		spawnPos.x = Random.Range(minPos.x, maxPos.x);
		spawnPos.y = Random.Range(minPos.y, maxPos.y);
		
		GameObject enemy = Instantiate(zombie, spawnPos, Quaternion.identity);
		enemy.transform.parent = gameObject.transform;
	}
}
