using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float _speed;
	[SerializeField]
	private float _jump;
	[SerializeField]
	public bool _isGrounded;
	public LayerMask _groundLayer;

	private Rigidbody2D _rb;
	private CapsuleCollider2D _cc;

	public float _speedMultiplier;
	public float _speedMilestone;
	private float _speedMilestoneCount;

	private float _speedStore;
	private float _speedMilestoneCountStore;
	private float _speedMilestoneStore;

	public float _jumpTime;
	private float _jumpTimeCounter;

	public GameManager _gm;

	
	

	// Use this for initialization
	void Start () {
		_rb = GetComponent<Rigidbody2D>();
		_cc = GetComponent<CapsuleCollider2D>();

		_speedMilestoneCount = _speedMilestone;

		_speedStore = _speed;
		_speedMilestoneCountStore = _speedMilestoneCount;
		_speedMilestoneStore = _speedMilestone;

		_jumpTimeCounter = _jumpTime;

		
	}
	
	// Update is called once per frame
	void Update () {
		_isGrounded = Physics2D.IsTouchingLayers(_cc, _groundLayer);
		_rb.velocity = new Vector2(_speed, _rb.velocity.y);

		if(Input.GetKeyDown(KeyCode.Space)) {
			if(_isGrounded) {
				_rb.velocity = new Vector2(_rb.velocity.x, _jump);
			}
		}

		if(Input.GetKey(KeyCode.Space)) {
			if(_jumpTimeCounter > 0) {
				_rb.velocity = new Vector2(_rb.velocity.x, _jump);
				_jumpTimeCounter -= Time.deltaTime;
			}
		}

		if(Input.GetKeyUp(KeyCode.Space)) {
			_jumpTimeCounter = 0;
		}

		if(_isGrounded) {
			_jumpTimeCounter = _jumpTime;
		}

		if(transform.position.x > _speedMilestoneCount) {
			_speedMilestoneCount += _speedMilestone;

			_speedMilestone = _speedMilestone * _speedMultiplier;
			
			_speed = _speed * _speedMultiplier;
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Killzone") {


			_gm.RestartGame();

			_speed = _speedStore;
			_speedMilestoneCount = _speedMilestoneCountStore;
			_speedMilestone = _speedMilestoneStore;


		}
	}
}
