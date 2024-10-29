using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStatHandler : MonoBehaviour
{
	[SerializeField] private UnitStat baseStats;
	public UnitStat CurrentStat {  get; private set; }

	private List<UnitStat> _statsModifiers = new List<UnitStat>();
	public List<UnitStat> StatsModifiers => _statsModifiers;

	public event Action<UnitStat> OnchangeStat;


	private void Awake()
	{
		ResetStat();
	}

	public void AddStatModifier(UnitStat modifier, float duration = 0)
	{
		
		_statsModifiers.Add(modifier);
		UpdateCharacterStat();
		if(duration> 0)
		{
			StartCoroutine(RemoveModifier(modifier,duration));
		}
	}

	private IEnumerator RemoveModifier(UnitStat modifier, float duration)
	{
		yield return new WaitForSecondsRealtime(duration);
		_statsModifiers.Remove(modifier);
		UpdateCharacterStat();


	}
	private void ResetStat()
	{
		if (CurrentStat == null)
		{
			CurrentStat = new UnitStat();
		}
		CurrentStat.OverrideStat(baseStats);
	}
	private void UpdateCharacterStat()
	{
		ResetStat();
		foreach (UnitStat stat in _statsModifiers)
		{
			switch (stat.Type)
			{
				case (StatsChangeType.Add):
					CurrentStat.AddStat(stat);
					break;
				case (StatsChangeType.Multiple):
					CurrentStat.MultipleStat(stat);
					break;
				case (StatsChangeType.Override):
					CurrentStat.OverrideStat(stat);
					break;
			}
		}
		OnchangeStat?.Invoke(CurrentStat);
	}
	

}
