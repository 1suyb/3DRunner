using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CSVToScriptableObjectClass))]
public class MyComponentEditor : Editor
{
	public override void OnInspectorGUI()
	{
		// �⺻ Inspector ��Ҹ� �׸���
		DrawDefaultInspector();

		// Ŀ���� Inspector ��ư �߰�
		CSVToScriptableObjectClass myComponent = (CSVToScriptableObjectClass)target;

		if (GUILayout.Button("Execute Generate"))
		{
			myComponent.Generate();
		}
	}
}