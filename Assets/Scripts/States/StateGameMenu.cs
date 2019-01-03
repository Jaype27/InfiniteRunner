using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateGameMenu : GameState {

	public Camera _introCamera;
	public StateGameMenu(GameManager gm):base (gm) { }

	public override void Enter() { }

	public override void Execute() { }

	public override void Exit() { } 

	public void PlayGame() {
		_gm.NewGameState(_gm._stateGamePlay);
	}

	public void QuitGame() {
		Application.Quit();
	}
}
