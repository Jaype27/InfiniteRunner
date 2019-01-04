using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public GameObject _pauseMenu;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Pause() {

		Time.timeScale = 0f;
		_pauseMenu.SetActive(true);
	}

	public void Resume () {
		Time.timeScale = 1f;
		_pauseMenu.SetActive(false);
	}
}
