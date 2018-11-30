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

	public float _speedMultiplier;

	private float _speedStore;

	public float _speedIncrementPoint;
	private float _speedPointStore;


	private float _speedIncrementCount;
	private float _speedCountStore;

	

	public GameManager _gm;

	
	

	// Use this for initialization
	void Start () {
		_rb = GetComponent<Rigidbody>();

		_speedIncrementCount = _speedIncrementPoint;

		_speedStore = _speed;

		_speedPointStore = _speedIncrementPoint;

		_speedCountStore = _speedIncrementCount;
	}
	
	// Update is called once per frame
	void Update () {
		_rb.velocity = new Vector2(_speed, _rb.velocity.y);
		Debug.DrawRay(transform.position, -Vector3.up * _rayLength, Color.green);

		if(transform.position.x > _speedIncrementCount) {

			_speedIncrementCount += _speedIncrementPoint;

			_speedIncrementCount = _speedIncrementPoint * _speedMultiplier;

			_speed = _speed * _speedMultiplier;
		}

		if (isGrounded()) {
			if(Input.GetKeyDown(KeyCode.Space)){
				_rb.velocity = new Vector2(_rb.velocity.x, _jump);
			}
		}
	}

	bool isGrounded() {
		return Physics.Raycast(transform.position, -Vector3.up, _rayLength);
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Killzone") {
			_gm.RestartGame();

			_speed = _speedStore;
			_speedIncrementPoint = _speedPointStore;
			_speedIncrementCount = _speedCountStore;
		}
	}
}
