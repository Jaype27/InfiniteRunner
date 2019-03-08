using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblePoints : MonoBehaviour {

	public int _pointAmount;
	private GameManager _gm;

	// Use this for initialization
	void Start () {
		_gm = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.name == "Player") {
			_gm.AddScore(_pointAmount);
			gameObject.SetActive(false);
			
		}
	}
}
