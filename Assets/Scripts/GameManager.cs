using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public Transform _platformAdder;
	private Vector3 _platformStartPoint;
	public PlayerController _pc;
	private Vector3 _playerStartPoint;
	private PlatformRemove[] _platformList;

	// Use this for initialization
	void Start () {
		_platformStartPoint = _platformAdder.position;
		_playerStartPoint = _pc.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RestartGame() {
		StartCoroutine("RestartGameCo");
	}

	public IEnumerator RestartGameCo() {

		_pc.gameObject.SetActive(false);
		yield return new WaitForSeconds(1.0f);
		_platformList = FindObjectsOfType<PlatformRemove>();

		for(int i = 0; i < _platformList.Length; i++) {
			_platformList[i].gameObject.SetActive(false);
		}
		
		_pc.transform.position = _playerStartPoint;
		_platformAdder.position = _platformStartPoint;
		_pc.gameObject.SetActive(true);
	}
}
