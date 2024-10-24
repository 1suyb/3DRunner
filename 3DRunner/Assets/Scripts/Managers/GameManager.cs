using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
	private Player _player;
	public Player Player
	{
		get
		{
			if(_player == null)
			{
				_player = GameObject.FindAnyObjectByType<Player>();
			}
			return _player;
		}
		set
		{
			if(_player != value)
			{
				_player = value;
			}
		}
	}

}
