using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

[CreateAssetMenu(fileName = "CSVtoClassMaker", menuName = "csv")]
public class CSVToScriptableObjectClass : ScriptableObject
{
    [SerializeField] private TextAsset _csvFile;

    public void Generate()
    {
        string[] lines = _csvFile.text.Split('\n');
        string title = _csvFile.name;
        string field = MakeField(FieldFormat, lines[1], lines[0]);
        string paremeter = MakeField(ParameterFormat, lines[1], lines[0].ToLower());
        paremeter = paremeter.Substring(0, paremeter.Length - 3);
		string initailier = MakeField(InitializerFormat, lines[0], lines[0].ToLower());
        Debug.Log(field);
		Debug.Log(paremeter);
		Debug.Log(initailier);
        string classText = ClassFormat(title, field, paremeter, initailier);
        File.WriteAllText($"Assets/Utility/{title}DB.cs", classText);
        string loaderText = DataLoaderFormat(title);
        File.WriteAllText($"Assets/Utility/Loader{title}.cs", loaderText);

	}

    private string MakeField(Func<string,string,string> format, string firstElement, string scondElement)
    {
        StringBuilder stringBuilder = new StringBuilder();

        List<string> firstElements = LineSplit(firstElement);
        List<string> scondElements = LineSplit(scondElement);
        for(int i = 0; i < firstElements.Count; i++)
        {
            stringBuilder.AppendLine(format(firstElements[i], scondElements[i]));
        }
        return stringBuilder.ToString();
	}
    private List<string> LineSplit(string line)
    {
		List<string> values = new List<string>();
		string[] valueLine = line.Split(",");
		foreach (string type in valueLine)
		{
			values.Add(type);
		}
        return values;
	}

    private string ClassFormat(string title, string field, string parmeters, string initializer)
    {
        StringBuilder classFormat = new StringBuilder();
        classFormat.AppendLine("using System;");
		classFormat.AppendLine("using System.Collections.Generic;");
		classFormat.AppendLine("using UnityEngine; ");
        classFormat.AppendLine("[Serializable] ");
        classFormat.AppendLine($"public class {title}");
        classFormat.AppendLine("{");
        classFormat.AppendLine($"{field}");
		classFormat.AppendLine("");
		classFormat.AppendLine($"   public {title}(");
		classFormat.AppendLine($"{parmeters}");
		classFormat.AppendLine($"   )");
		classFormat.AppendLine("    {");
		classFormat.AppendLine($"{initializer}");
		classFormat.AppendLine("    }");
		classFormat.AppendLine($"   public {title}(){{}}");
		classFormat.AppendLine("}");
        classFormat.AppendLine("");

		classFormat.AppendLine("");
		classFormat.AppendLine($"[CreateAssetMenu(fileName = \"{title}\", menuName =\"DataScriptableObject/{title}DB\")]");
        classFormat.AppendLine($"public class {title}DB : DataBase<{title}>");
        classFormat.AppendLine("{");
        classFormat.AppendLine("}");
        return classFormat.ToString();
    }
    private string FieldFormat(string type, string name)
    {
        return $"   public {type} {name};";
    }

    private string ParameterFormat(string type, string name)
    {
        return $"       {type} {name},";
    }
    private string InitializerFormat(string fieldName, string parameterName)
    {
        return $"       {fieldName} = {parameterName};";
    }

    private string DataLoaderFormat(string title)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("using UnityEngine;");
        sb.AppendLine("using UnityEditor;");
        sb.AppendLine();
		sb.AppendLine($"[CreateAssetMenu(fileName = \"{title}Loader\",menuName = \"DataScriptableObject/{title}Loader\")]");
		sb.AppendLine($"public class {title}CSVDataLoader: ScriptableObject");
        sb.AppendLine("{");
		sb.AppendLine("     [SerializeField] private TextAsset _textAsset;");
        sb.AppendLine("");
        sb.AppendLine("     [ContextMenu(\"Generate\")]");
        sb.AppendLine("     public void Generate()");
        sb.AppendLine("     {");
        sb.AppendLine($"	    {title}DB assets = ScriptableObject.CreateInstance<{title}DB>();");
        sb.AppendLine($"	    assets.Data = CSVDataLoader<{title}>.LoadData(_textAsset.text);");
        sb.AppendLine($"		string path = \"Assets/Utility/{title}DB.asset\";");
        sb.AppendLine("		    path = AssetDatabase.GenerateUniqueAssetPath(path);");
        sb.AppendLine("		    AssetDatabase.CreateAsset(assets, path);");
        sb.AppendLine("		    AssetDatabase.SaveAssets();");
        sb.AppendLine("		    AssetDatabase.Refresh();");
        sb.AppendLine("     }");
        sb.AppendLine("}");
        return sb.ToString();
	}

}
