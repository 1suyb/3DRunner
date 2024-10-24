using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
	enum Objects
	{
		PlayerCharacter,
		Canvas
	}
	private void Awake()
	{
		ResourceManager.Instantiate(Objects.PlayerCharacter.ToString());
		UIManager.Instance.OpenUI(Objects.Canvas.ToString());
	}
}
