using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "ItemDataLoader",menuName = "DataScriptableObject/ItemDataLoader")]
public class ItemDataCSVDataLoader: ScriptableObject
{
     [SerializeField] private TextAsset _textAsset;

     [ContextMenu("Generate")]
     public void Generate()
     {
	    ItemDataDB assets = ScriptableObject.CreateInstance<ItemDataDB>();
	    assets.Data = CSVDataLoader<ItemData>.LoadData(_textAsset.text);
		string path = "Assets/Utility/ItemDataDB.asset";
		    path = AssetDatabase.GenerateUniqueAssetPath(path);
		    AssetDatabase.CreateAsset(assets, path);
		    AssetDatabase.SaveAssets();
		    AssetDatabase.Refresh();
     }
}
