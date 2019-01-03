using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState {

	protected GameManager _gm;

	public GameState(GameManager gm) {
		_gm = gm;
	}

	public abstract void Enter();
	public abstract void Execute();
	public abstract void Exit();
}
