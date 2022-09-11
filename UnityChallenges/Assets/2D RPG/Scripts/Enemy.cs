using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
	public float health;
	public RPGMovement player;
	public Image healtImg;
	public float minSpeed;
	public float maxSpeed;
	public float minDamage;
	public float maxDamage;
	public RPGMovement objMove;
	
	// Start is called before the first frame update
    void Start()
    {
	    GameObject playerObj = GameObject.Find("Player");
	    player = playerObj.GetComponent<RPGMovement>();
    }

    // Update is called once per frame
    void Update()
    {
	    Images();
	    
    }
    
	void FixedUpdate(){
		Move();
	}
    
	public void Damage(float damage){
		health -= damage;
		deathCheck();
	}
	
	private void deathCheck(){
		if(health <= 0){
			player.overallAmmo += 5;
			player.hP += 5;
			Destroy(gameObject);
		}
	}
	
	void OnMouseDown(){
		player.targetEnemy = this;
		player.Shoot();
		Debug.Log("Pressed");
	}
	
	void OnMouseUp(){
		player.targetEnemy = null;
	}
	
	void Images(){
		healtImg.fillAmount = 1 / (100 / health);
	}
	
	void Move(){
		Vector2 posToGo = player.gameObject.transform.position;
		
		float speed = Random.Range(minSpeed, maxSpeed);
		
		float step = speed * Time.deltaTime;
		
		gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, posToGo, step); //= new Vector2(Mathf.Lerp(0, posToGo.x, speed), Mathf.Lerp(0, posToGo.y, speed));
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		GameObject obj = collider.gameObject;
		objMove = obj.GetComponent<RPGMovement>();
		
		if(objMove != null){
			
			float damage = Random.Range(minDamage, maxDamage);
			objMove.Damage(damage);
			
		}
	}
}
