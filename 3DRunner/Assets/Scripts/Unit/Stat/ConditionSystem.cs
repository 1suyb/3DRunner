using System;
using TMPro.EditorUtilities;
using UnityEngine;

public class ConditionSystem
{
	private int _maxCondition;
	private int _condition;
	private int _threshold;

	public int MaxCondition {
		get => _maxCondition;
		set
		{
			_maxCondition = value;
			_threshold = _maxCondition / 3;
		}
	}

	private bool _isBelowThreshold;

	public event Action<int> OnChangeConditionEvent;
	public event Action OnBelowThresholdEvent;
	public event Action OnAvobeThresholdEvent;
	public event Action OnExhaustEvent;
	public int Condition
	{
		get { return _condition; }
		private set
		{
			_condition = Mathf.Clamp(value, 0, MaxCondition);
			OnChangeConditionEvent?.Invoke(_condition);
			if (_condition < _threshold)
			{
				if (!_isBelowThreshold)
				{
					_isBelowThreshold = true;
					OnBelowThresholdEvent?.Invoke();
				}
					
			}
			else
			{
				if (_isBelowThreshold)
				{
					_isBelowThreshold = false;
					OnAvobeThresholdEvent?.Invoke();
				}
			}
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

	public void AddHealth(int value)
	{
		Condition += value;
	}
	public void SubtractHealth(int value)
	{
		Condition -= value;
	}

}
