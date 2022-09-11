using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
	public KeyCode pause = KeyCode.Escape;
	public GameObject pauseObj;
	
	public void PauseGame(){
		Time.timeScale = 0;
	}
	
	public void Resume(){
		Time.timeScale = 1;
	}
	
	void Update(){
		if(Input.GetKeyUp(pause)){
			PauseGame();
			pauseObj.SetActive(true);
		}
	}
}
