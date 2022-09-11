using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
	public void CCC(){
		Application.OpenURL("https://www.youtube.com/channel/UCQN9ETYg7YzDqu-6-UTCszg");
	}
	
	public void CCW(){
		Application.OpenURL("http://creativecoders.co.zw");
	}
	
	public void Quit(){
		Application.Quit();
	}
}
