using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CSVToScriptableObjectClass))]
public class MyComponentEditor : Editor
{
	public override void OnInspectorGUI()
	{
		// 기본 Inspector 요소를 그리기
		DrawDefaultInspector();

		// 커스텀 Inspector 버튼 추가
		CSVToScriptableObjectClass myComponent = (CSVToScriptableObjectClass)target;

		if (GUILayout.Button("Execute Generate"))
		{
			myComponent.Generate();
		}
	}
}