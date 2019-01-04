using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateGameIntro : GameState {

	private float _countDown = 5f;
	public StateGameIntro(GameManager gm): base (gm) { }


	public override void Enter() {

	}

	public override void Execute() {
		if(_countDown <= 0) {
			// _gm.NewGameState(_gm._stateGameMenu);
			// _gm.UpdateFSM(GameStates.MENU);
		} else {
			_countDown -= Time.deltaTime;
		}
	}

	public override void Exit() {

	}
}
