using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPooling : MonoBehaviour {

	public GameObject _pooledPlatforms;
	public int _amountPlatforms;
	List <GameObject> _pooledObjects;
	
	

	// Use this for initialization
	void Start () {
		
	
		_pooledObjects = new List<GameObject>();

		for(int i = 0; i < _amountPlatforms; i++) {
			GameObject _object = (GameObject)Instantiate(_pooledPlatforms);
			_object.SetActive(false);
			_pooledObjects.Add(_object);
		}
	}
	
	public GameObject GetPoolObject() {
		for(int i = 0; i < _pooledObjects.Count; i++) {
			
			if(!_pooledObjects[i].activeInHierarchy) {

				return _pooledObjects[i];
			}
		}

		GameObject _object = (GameObject)Instantiate(_pooledPlatforms);
		_object.SetActive(false);
		_pooledObjects.Add(_object);

		return _object;

	}
}
