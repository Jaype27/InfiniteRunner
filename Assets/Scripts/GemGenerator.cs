using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemGenerator : MonoBehaviour {

	public ObjectPool _gemPool;
	public float _distBetweenGem;

	public void SpawnGems(Vector3 _startPosition) {
		GameObject gem1 = _gemPool.GetPoolObject();
		gem1.transform.position = _startPosition;
		gem1.SetActive(true);

		GameObject gem2 = _gemPool.GetPoolObject();
		gem2.transform.position = new Vector3(_startPosition.x - _distBetweenGem, _startPosition.y, _startPosition.z);
		gem2.SetActive(true);

		GameObject gem3 = _gemPool.GetPoolObject();
		gem3.transform.position = new Vector3(_startPosition.x + _distBetweenGem, _startPosition.y, _startPosition.z);
		gem3.SetActive(true);
	}
}
