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
	private Vector3 _playerStartPoint;
	private PlatformRemove[] _platformList;

	public static GameManager Instance { get { return m_instance; } }
	private static GameManager m_instance = null;

	public StateManager _stateManager;
	private GameState _currentState;
	
	public StateGameIntro _stateGameIntro { get;set; }
	public StateGameMenu _stateGameMenu { get;set; }
	public StateGamePlay _stateGamePlay { get;set; }


	void Awake() {
		if (m_instance != null && m_instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			m_instance = this;
		}
		DontDestroyOnLoad(this.gameObject);

		_stateGameIntro = new StateGameIntro(this);
		_stateGameMenu = new StateGameMenu(this);
		_stateGamePlay = new StateGamePlay(this);
	}


	// Use this for initialization
	void Start () {

		_score = 0f;
		_hiscore = 0f;

		_hiscore = PlayerPrefs.GetFloat("highscore");

		_platformStartPoint = _platformAdder.position;
		_playerStartPoint = _pc.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(_currentState != null) {
			_currentState.Execute();
		}

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

	public void StartGame () {
		NewGameState(_stateGameIntro);
	}

	public void NewGameState(GameState newState) {
		if(_currentState != null) {
			_currentState.Exit();
		}

		_currentState = newState;
		_currentState.Enter();
	}

	public void UpdateFSM(GameStates newState) {
		_stateManager.ChangeState(newState);
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

		_score = 0;
		_scoreIncreasing = true;
	}
}
