using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {

	public bool _doublePoints;
	public float _duration;
	private PowerUpManager _pum;

	// Use this for initialization
	void Start () {
		_pum = FindObjectOfType<PowerUpManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.name == "Player") {
			_pum.ActivatePowerUp(_doublePoints, _duration);
		}
		gameObject.SetActive(false);
	}
}
