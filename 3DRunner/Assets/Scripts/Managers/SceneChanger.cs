using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneName
{
	IntroScene,
	GameScene,
	SampleScene,
}

public static class SceneChanger
{
	public static void LoadScene(SceneName sceneName)
	{
		SceneManager.LoadScene(sceneName.ToString());
		UIManager.Instance.Clear();
	}
}
