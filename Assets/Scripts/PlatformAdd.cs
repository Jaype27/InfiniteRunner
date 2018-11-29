using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAdd : MonoBehaviour {

	// public GameObject _platforms;
	public Transform _spawnPoint;
	public float _spawnBetween;
	private float _platformWidth;

	[SerializeField]
	private float _GapMin;
	[SerializeField]
	private float _GapMax;

	// public GameObject[] _platformTypes;
	private int _platformSelect;
	private float[] _platformWidths;




	public PlatformPooling[] _platformPooling;
	
	// Use this for initialization
	void Start () {
		// _platformWidth = _platforms.GetComponent<BoxCollider>().size.x;
		
		_platformWidths = new float[_platformPooling.Length];

		for(int i = 0; i < _platformPooling.Length; i++) {
			_platformWidths[i] = _platformPooling[i]._pooledPlatforms.GetComponent<BoxCollider>().size.x;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < _spawnPoint.position.x) {

			_spawnBetween = Random.Range(_GapMin, _GapMax);

			_platformSelect = Random.Range(0, _platformWidths.Length);

			transform.position = new Vector3(transform.position.x + (_platformWidths[_platformSelect] / 2) + _spawnBetween, transform.position.y, transform.position.z);
			
			// Instantiate(_platformTypes[_platformSelect], transform.position, transform.rotation);
			// Instantiate(_platforms, transform.position, transform.rotation);
			
			GameObject spawnPlatform = _platformPooling[_platformSelect].GetPoolObject();

			spawnPlatform.transform.position = transform.position;
			spawnPlatform.transform.rotation = transform.rotation;
			spawnPlatform.SetActive(true);

			transform.position = new Vector3(transform.position.x + (_platformWidths[_platformSelect] / 2), transform.position.y, transform.position.z);

		}
	}
}
