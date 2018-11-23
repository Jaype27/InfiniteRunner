using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

	public PlayerController _playerControl;
	private Vector3 _lastPos;
	private float _distToMove;

	// Use this for initialization
	void Start () {
		_playerControl = FindObjectOfType<PlayerController>();
		_lastPos = _playerControl.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		_distToMove = _playerControl.transform.position.x - _lastPos.x;

		transform.position = new Vector3(transform.position.x + _distToMove, transform.position.y, transform.position.z);

		_lastPos = _playerControl.transform.position;
	}
}
