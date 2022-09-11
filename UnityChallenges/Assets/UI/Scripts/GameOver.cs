using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace PleaseDontHate.SemiCheating{

public class GameOver : MonoBehaviour
{
	public GameObject startCanvas;
	public GameObject restartCanvas;
	public bool timer = false;
	public TMP_Text timerText;
	private int timerTime;
	private float timerTimeF;
	
	private void Update(){
		if(Input.GetButtonDown("Cancel")){
			Pause();
		}
		
		if(timer){
			Timer();
		}
	}
	
	public void Quit(){
		Application.Quit();
	}
	
	public void SwitchScene(int sceneToLoad){
		SceneManager.LoadScene(sceneToLoad);
	}
	
	public void Restart(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	
	private void Awake(){
		Time.timeScale = 0f;
		startCanvas.SetActive(true);
	}
	
	public void Play(){
		Time.timeScale = 1f;
		startCanvas.SetActive(false);
	}
	
	public void Pause(){
		startCanvas.SetActive(true);
		Time.timeScale = 0f;
	}
	
	public void GameOverAction(){
		Time.timeScale = 0f;
		restartCanvas.SetActive(true);
	}
	
	public void Timer(){
		timerTimeF += Time.deltaTime;
		timerTime = (int)timerTimeF;
		timerText.text = timerTime.ToString();
	}
}
}