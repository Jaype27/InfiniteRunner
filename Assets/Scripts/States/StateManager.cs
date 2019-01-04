using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStates { INTRO, MENU, PLAY }

public class StateManager : MonoBehaviour {

	public GameObject[] _gameStates;
	private GameStates _activeState;
	private int _numStates;

	void Awake () {
		_numStates = _gameStates.Length;

		for(int i = 0; i < _numStates; i++) {
			_gameStates[i].SetActive(false);
		}

		_activeState = GameStates.INTRO;
		_gameStates[(int)_activeState].SetActive(true);
		// GameManager.Instance.StartGame();
	}

	public void ChangeState(GameStates newState) {
		_gameStates[(int)_activeState].SetActive(false);
		_activeState = newState;
		_gameStates[(int)_activeState].SetActive(true);
	}

	public void PlayGame() {
		// GameManager.Instance._stateGameMenu.PlayGame();
		_gameStates[(int)_activeState].SetActive(false);
		_activeState = GameStates.PLAY;
		_gameStates[(int)_activeState].SetActive(true);
	}

	public void QuitGame() {
		// GameManager.Instance._stateGameMenu.QuitGame();
	}
}
