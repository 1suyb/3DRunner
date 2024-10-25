using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
	private Player _player;
	public Player Player
	{
		get => _player;
		set => _player = value;
	}

}
