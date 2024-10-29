using System;
using TMPro.EditorUtilities;
using UnityEngine;

[Serializable]
public class ConditionSystem
{
	private int _maxCondition;
	private int _condition;

	public int MaxCondition {
		get => _maxCondition;
		set
		{
			_maxCondition = value;
		}
	}

	private bool _isBelowThreshold;

	public event Action<int,int> OnChangeConditionEvent;

	public event Action OnExhaustEvent;
	public int Condition
	{
		get { return _condition; }
		private set
		{
			_condition = Mathf.Clamp(value, 0, MaxCondition);
			OnChangeConditionEvent?.Invoke(_condition,_maxCondition);
			if (_condition == 0)
			{
				OnExhaustEvent?.Invoke();
			}
		}
	}

	public void Init(int maxCondition)
	{
		MaxCondition = maxCondition;
		_condition = maxCondition;
	}

	public void Add(int value)
	{
		Condition += value;
	}
	public void Subtract(int value)
	{
		Condition -= value;
	}

}
