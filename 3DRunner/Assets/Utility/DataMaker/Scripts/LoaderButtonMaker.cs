
//using UnityEditor;
//using UnityEngine;

//[CustomEditor(typeof(ItemDataCSVDataLoader))]
//public class DataLoaderEditor : Editor
//{
//	public override void OnInspectorGUI()
//	{
//		// 기본 Inspector 요소를 그리기
//		DrawDefaultInspector();

//		// 커스텀 Inspector 버튼 추가
//		ItemDataCSVDataLoader myComponent = (ItemDataCSVDataLoader)target;

//		if (GUILayout.Button("Execute Generate"))
//		{
//			myComponent.Generate();
//		}
//	}
//}