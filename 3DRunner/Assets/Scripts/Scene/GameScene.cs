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
		GameObject obj = ResourceManager.Instantiate(Objects.PlayerCharacter.ToString());
		obj.GetComponent<ConditionHandler>().Init();
		GameObject uiRoot = new GameObject("SceneUIRoot");
		UIConditionPanel conditionPanel = UIManager.Instance.OpenUI<UIConditionPanel>();
		conditionPanel.Init();
	}
	private void Start()
	{
	}
}
