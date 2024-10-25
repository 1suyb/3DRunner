using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICondition : MonoBehaviour
{
	[SerializeField] private Image _fillBar;

	public void UpdateFillBar(int condition, int maxCondition)
	{
		_fillBar.fillAmount = (float)condition / (float)maxCondition;
	}
}
