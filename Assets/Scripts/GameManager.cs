using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

	public Text _scoreUIText;
	public Text _hiscoreUIText; 
	public bool _scoreIncreasing;
	public static float _score;
	private float _hiscore;

	public Transform _platformAdder;
	private Vector3 _platformStartPoint;
	public PlayerController _pc;
	// public Camera _cam;
	// private Vector3 _camStartPoint;

	public KillzoneFollow _killZone;
	private Vector3 _killZoneStartPoint;

	private Vector3 _playerStartPoint;
	private PlatformRemove[] _platformList;

	public static GameManager Instance { get { return m_instance; } }
	private static GameManager m_instance = null;


	void Awake() {
		if (m_instance != null && m_instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			m_instance = this;
		}
		DontDestroyOnLoad(this.gameObject);

	}


	// Use this for initialization
	void Start () {

		_score = 0f;
		_hiscore = 0f;

		_hiscore = PlayerPrefs.GetFloat("highscore");

		_platformStartPoint = _platformAdder.position;
		_playerStartPoint = _pc.transform.position;
		// _camStartPoint = _cam.transform.position;
		_killZoneStartPoint = _killZone.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {

		if(_scoreIncreasing) {
			_score += Time.deltaTime;
		}

		if(_score > _hiscore) {
			_hiscore = _score;
			PlayerPrefs.SetFloat("highscore", _hiscore);
		}

		_scoreUIText.text = "Score: " + (int)Mathf.Floor(_score);
		_hiscoreUIText.text = "Highscore: " + (int)Mathf.Floor(_hiscore);
	}

	public void AddScore(int _pointsToAdd) {
		_score += _pointsToAdd;
	}

	public void RestartGame() {
		StartCoroutine("RestartGameCo");
	}

	public IEnumerator RestartGameCo() {

		_pc.gameObject.SetActive(false);
		yield return new WaitForSeconds(2.0f);
		_platformList = FindObjectsOfType<PlatformRemove>();

		for(int i = 0; i < _platformList.Length; i++) {
			_platformList[i].gameObject.SetActive(false);
		}
		
		_pc.transform.position = _playerStartPoint;
		// _cam.transform.position = _camStartPoint;
		_killZone.transform.position = _killZoneStartPoint;
		_platformAdder.position = _platformStartPoint;
		_pc.gameObject.SetActive(true);

		_score = 0;
		_scoreIncreasing = true;
	}
}
