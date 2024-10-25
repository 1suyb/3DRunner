using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIConditionPanel : MonoBehaviour
{
	private UICondition[] _conditionUIs;
	private ConditionHandler _playerConditionHandler;

	private void Awake()
	{
		_conditionUIs = this.transform.GetComponentsInChildren<UICondition>();
	}
	private void OnEnable()
	{
		if (_playerConditionHandler!=null)
		{
			Subscribe();
		}
	}
	public void Init()
	{
		_playerConditionHandler = GameManager.Instance.Player.ConditionHandler;
		Subscribe();
	}

	public void Subscribe()
	{
		_playerConditionHandler.GetHealth.OnChangeConditionEvent += _conditionUIs[0].UpdateFillBar;
		_playerConditionHandler.GetHunger.OnChangeConditionEvent += _conditionUIs[1].UpdateFillBar;
		_playerConditionHandler.GetStamina.OnChangeConditionEvent += _conditionUIs[2].UpdateFillBar;
	}
	public void UnSubscribe()
	{
		_playerConditionHandler.GetHealth.OnChangeConditionEvent -= _conditionUIs[0].UpdateFillBar;
		_playerConditionHandler.GetHunger.OnChangeConditionEvent -= _conditionUIs[1].UpdateFillBar;
		_playerConditionHandler.GetStamina.OnChangeConditionEvent -= _conditionUIs[2].UpdateFillBar;
	}

	private void OnDisable()
	{
		if (_playerConditionHandler!=null)
		{
			UnSubscribe();
		}
	}
			

}
