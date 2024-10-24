using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIConditionPanel : MonoBehaviour
{
	private UICondition[] _conditionUIs;

	private void Awake()
	{
		_conditionUIs = this.transform.GetComponentsInChildren<UICondition>();
	}
	private void OnEnable()
	{
		GameManager.Instance.Player.ConditionHandler.GetHealth.OnChangeConditionEvent += _conditionUIs[0].UpdateFillBar;
		GameManager.Instance.Player.ConditionHandler.GetHunger.OnChangeConditionEvent += _conditionUIs[1].UpdateFillBar;
		GameManager.Instance.Player.ConditionHandler.GetStamina.OnChangeConditionEvent += _conditionUIs[2].UpdateFillBar;
	}
	private void OnDisable()
	{
		GameManager.Instance.Player.ConditionHandler.GetHealth.OnChangeConditionEvent -= _conditionUIs[0].UpdateFillBar;
		GameManager.Instance.Player.ConditionHandler.GetHunger.OnChangeConditionEvent -= _conditionUIs[1].UpdateFillBar;
		GameManager.Instance.Player.ConditionHandler.GetStamina.OnChangeConditionEvent -= _conditionUIs[2].UpdateFillBar;
	}
}
