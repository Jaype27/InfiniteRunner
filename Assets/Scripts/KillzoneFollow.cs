using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillzoneFollow : MonoBehaviour {

	private float _speed;
	public PlayerController _pc;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 temp = transform.position;
		temp.x += _speed * Time.deltaTime;
		transform.position = temp;

		_speed = _pc._speed - 0.5f;
	}
}
