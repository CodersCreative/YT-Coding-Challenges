using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
	public void SwitchScene(int sceneToLoad){
		SceneManager.LoadScene(sceneToLoad);
	}
	
	public void Quit(){
		Application.Quit();
	}
	
	public void Restart(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
