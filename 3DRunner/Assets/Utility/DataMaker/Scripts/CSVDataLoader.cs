using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

using UnityEngine.TextCore.Text;
public class DataBase<T> : ScriptableObject where T : new()
{
    public List<T> Data = new List<T>();
}
public class CSVDataLoader<T> where T : new()
{

	public static List<T> LoadData(string text)
	{
		List<T> data = new List<T>();
		string[] lines = text.Split('\n');
		string[] headers = lines[0].Split(",");
		for (int i = 2; i < lines.Length-1; i++)
		{
			string[] values = lines[i].Split(",");
			T obj = new T();
			Type type = typeof(T);
			for (int j = 0; j < headers.Length; j++)
			{
				string header = headers[j].Trim();
				string value = values[j].Trim();
				FieldInfo property = type.GetField(header, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
				Debug.Log(property);
				Debug.Log(header);
				if (property != null)
				{
					Debug.Log(header);
					Debug.Log(value);
					Debug.Log(property.FieldType);
					object convertedValue = Convert.ChangeType(value, property.FieldType);
					property.SetValue(obj, convertedValue);
				}
			}
			data.Add(obj);
		}
		return data;
	}
}
