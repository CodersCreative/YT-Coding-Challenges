using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RPGMovement : MonoBehaviour
{
	private float curSpeed;
	public float sprintSpeed = 5f;
	public float walkSpeed = 2.5f;
	private float horizontal;
	private float vertical;
	public Rigidbody2D rb;
	public float moveTime = 0.8f;
	public KeyCode sprint = KeyCode.LeftShift;
	public KeyCode teleport = KeyCode.Space;
	public KeyCode shootKey = KeyCode.Mouse0;
	public KeyCode reload = KeyCode.R;
	public float teleCooldown = 0f;
	public float hP;
	public Image hPImage;
	public GameObject teleImageObj;
	public GameObject gunImageObj;
	public int shotsLeft = 15;
	private int shotsReg = 15;
	public float shotCooldown = 0;
	[SerializeField] private Vector2 mousePosition;
	public GameObject gunCenterObj;
	public float damage;
	public int overallAmmo;
	public TMP_Text ammoText;
	public Enemy targetEnemy;
	public GameObject gameOver;

	void Update(){
		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Gun();
		
		if(Input.GetKeyUp(reload)){
			Reload();
		}
	}
	
	public void Damage(float damage){
		hP -= damage;
		deathCheck();
	}
	
	private void deathCheck(){
		if(hP <= 0){
			gameOver.SetActive(true);
			Destroy(gameObject);
		}
	}

	void FixedUpdate()
	{
		if(ammoText != null){
			ammoText.text = "" + shotsLeft + " / " + overallAmmo;
		}
    	
		Images();
	    Controls();
	    Move();
    }
    
	void Controls(){
		horizontal = Input.GetAxis("Horizontal");
		vertical = Input.GetAxis("Vertical");
	    
		if(Input.GetKeyDown(sprint)){
			curSpeed = sprintSpeed;
		}else{
			curSpeed = walkSpeed;
		}
	    
		teleCooldown -= Time.deltaTime;
		shotCooldown -= Time.deltaTime;
	    
		if(Input.GetKeyUp(teleport)){
			Teleport();
		}
		
		if(Input.GetKeyUp(shootKey)){
			Shoot();
		}
	}
	
	void Images(){
		if(teleCooldown <= 0){
			teleImageObj.SetActive(false);
		}else{
			teleImageObj.SetActive(true);
		}
		
		if(shotsLeft == 0){
			gunImageObj.SetActive(false);
		}else{
			gunImageObj.SetActive(true);
		}
		
		hPImage.fillAmount = 1 / (100 / hP);
		
	}
    
	void Move(){
		rb.velocity = new Vector2(Mathf.Lerp(0, horizontal * curSpeed, moveTime), Mathf.Lerp(0, (vertical * curSpeed), moveTime));
	}
	
	void Teleport(){
		if(teleCooldown <= 0){
			gameObject.transform.position = new Vector2(Mathf.Lerp(0, mousePosition.x, 1), Mathf.Lerp(0, mousePosition.y, 1));
			teleCooldown = 10;
		}

	}
	
	void Gun(){
		gunCenterObj.transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePosition - new Vector2(transform.position.x, transform.position.y));
	}
	
	public void Shoot(){
		
		if(shotsLeft > 0 && shotCooldown <= 0){
			
			//Enemy targetEnemy = mouseScript.targetEnemy;
			
			if(targetEnemy != null){
				targetEnemy.Damage(damage);
				Debug.Log("hit");
				targetEnemy.player = this;
			}
			
			shotCooldown = 1;
			shotsLeft--;
		}else if(shotsLeft <= 0){
			Reload();
		}
	}
	
	void Reload(){
		int shotsNeeded = shotsReg - shotsLeft;
			
		overallAmmo -= shotsNeeded;
		shotsLeft = shotsReg;
	}

}
