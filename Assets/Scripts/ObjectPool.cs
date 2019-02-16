using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

	public GameObject _pooledObject;
	public int _amountPooled;
	List <GameObject> _pooledObjects;
	
	

	// Use this for initialization
	void Start () {
		
	
		_pooledObjects = new List<GameObject>();

		for(int i = 0; i < _amountPooled; i++) {
			GameObject _object = (GameObject)Instantiate(_pooledObject);
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

		GameObject _object = (GameObject)Instantiate(_pooledObject);
		_object.SetActive(false);
		_pooledObjects.Add(_object);

		return _object;

	}
}
