using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Timeline;
using UnityEngine;

public class ItemEffectSlot : MonoBehaviour
{
	[SerializeField] private TMP_Text _effectName;
	[SerializeField] private TMP_Text _text;

	public void Init(string name, string value)
	{
		_effectName.text = value;
		Init(value);
	}
	public void Init(string value) 
	{
		if(value != "0")
		{
			this.gameObject.SetActive(true);
			_text.text = value;
		}
		else
		{
			this.gameObject.SetActive(false);
		}
	}

}
