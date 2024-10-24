using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private UnitStatHandler _statHandler;
	private ConditionHandler _conditionHandler;

	public UnitStatHandler StatHandler =>_statHandler;
	public ConditionHandler ConditionHandler =>_conditionHandler;

	private void Awake()
	{
		_statHandler = GetComponent<UnitStatHandler>();
		_conditionHandler = GetComponent<ConditionHandler>();
		GameManager.Instance.Player = this;

	}
}
