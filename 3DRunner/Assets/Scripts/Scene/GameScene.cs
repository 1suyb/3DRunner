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
	UIConditionPanel ui;
	private void Awake()
	{
		GameObject obj = ResourceManager.Instantiate(Objects.PlayerCharacter.ToString());
		obj.GetComponent<ConditionHandler>().Init();
		GameObject uiRoot = new GameObject("SceneUIRoot");
		List<UI> uiObjects = UIManager.Instance.OpenScene<UI>(SceneName.SampleScene, uiRoot.transform);
		foreach(UI uiObject in uiObjects)
		{
			uiObject.Init();
		}
	}
	private void Start()
	{
		ui.gameObject.SetActive(true);
	}
}
