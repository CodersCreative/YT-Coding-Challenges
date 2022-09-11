using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speech : MonoBehaviour
{
	public GameObject speechBg;
	
	// Start is called before the first frame update
	void Awake()
    {
	    Time.timeScale = 0f;
    }

    // Update is called once per frame
	public void StartGame()
    {
	    speechBg.SetActive(false);
	    Time.timeScale = 1f;
    }
}
