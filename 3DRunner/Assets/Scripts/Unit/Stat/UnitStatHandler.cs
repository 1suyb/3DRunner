using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitStatHandler : MonoBehaviour
{
	[SerializeField] private UnitStat baseStats;
	public UnitStat CurrentStat {  get; private set; }
	public List<UnitStat> statsModifiers = new List<UnitStat>();

	public event Action<UnitStat> OnchangeStat;

	private void Awake()
	{
		ResetStat();
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
		foreach (UnitStat stat in statsModifiers)
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
