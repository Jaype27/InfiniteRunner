using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string _leveltoLoad;
	
	public void PlayGame () {
		SceneManager.LoadScene(_leveltoLoad);
	}

	public void Quit () {
		Application.Quit();
	}
}
