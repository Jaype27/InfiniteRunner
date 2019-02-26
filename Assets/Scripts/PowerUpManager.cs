using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour {

	private bool _doublePoints;
	private bool _isPowerActive;
	private float _durationCounter;
	private GameManager _gm;
	private int _normalMultiplier;
	

	// Use this for initialization
	void Start () {
		_gm = FindObjectOfType<GameManager>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if(_isPowerActive) {
			_durationCounter -= Time.deltaTime;

			if(_gm._powerUpReset) {
				_durationCounter = 0;
				_gm._powerUpReset = false;
			}

			Debug.Log(_durationCounter);
			if(_doublePoints) {
				_gm._multiplier = _normalMultiplier * 2;
				_gm._double = true;
			}
			if(_durationCounter <= 0) {

				_gm._multiplier = _normalMultiplier;
				_gm._double = true;
				_isPowerActive = false;
				Debug.Log("Power Off");
			}
		}
	}

	public void ActivatePowerUp(bool dp, float time) {
		_doublePoints = dp;
		_durationCounter = time;

		_normalMultiplier = _gm._multiplier;

		_isPowerActive = true;
	}
}
