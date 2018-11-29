using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRemove : MonoBehaviour {

	public GameObject _platformRemove;

	// Use this for initialization
	void Start () {
		_platformRemove = GameObject.Find("DespawnPlatformPoint");
		
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < _platformRemove.transform.position.x) {
			// Destroy(gameObject);

			gameObject.SetActive(false);
		}
	}
}
