using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float _speed;
	[SerializeField]
	private float _jump;
	[SerializeField]
	private float _rayLength;
	private Rigidbody _rb;
	

	// Use this for initialization
	void Start () {
		_rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		_rb.velocity = new Vector2(_speed, _rb.velocity.y);
		Debug.DrawRay(transform.position, -Vector3.up * _rayLength, Color.green);

		if (isGrounded()) {
			if(Input.GetKeyDown(KeyCode.Space)){
				_rb.velocity = new Vector2(_rb.velocity.x, _jump);
			}
		}
	}

	bool isGrounded() {
		return Physics.Raycast(transform.position, -Vector3.up, _rayLength);
	}
}
