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
		OverrideStat(baseStats);
	}
	private void UpdateCharacterStat()
	{

		foreach (UnitStat stat in statsModifiers)
		{
			switch (stat.Type)
			{
				case (StatsChangeType.Add):
					AddStat(stat);
					break;
				case (StatsChangeType.Multiple):
					MultipleStat(stat);
					break;
				case (StatsChangeType.Override):
					OverrideStat(stat);
					break;
			}
		}
		OnchangeStat?.Invoke(CurrentStat);
	}
	private void MultipleStat(UnitStat stat)
	{
		CurrentStat.Health *= stat.Health;
		CurrentStat.Hunger *= stat.Hunger;
		CurrentStat.Stamina *= stat.Stamina;

		CurrentStat.PassiveHealthRecovery *= stat.PassiveHealthRecovery;
		CurrentStat.PassiveHealthDecline *= stat.PassiveHealthDecline;
		CurrentStat.PassiveHungerDecline *= stat.PassiveHungerDecline;
		CurrentStat.passiveStaminaRecovery *= stat.passiveStaminaRecovery;

		CurrentStat.WalkSpeed *= stat.WalkSpeed;
		CurrentStat.RunSpeed *= stat.RunSpeed;
		CurrentStat.JumpForce *= stat.JumpForce;
	}

	private void AddStat(UnitStat stat)
	{
		CurrentStat.Health += stat.Health;
		CurrentStat.Hunger += stat.Hunger;
		CurrentStat.Stamina += stat.Stamina;

		CurrentStat.PassiveHealthRecovery += stat.PassiveHealthRecovery;
		CurrentStat.PassiveHealthDecline += stat.PassiveHealthDecline;
		CurrentStat.PassiveHungerDecline += stat.PassiveHungerDecline;
		CurrentStat.passiveStaminaRecovery += stat.passiveStaminaRecovery;

		CurrentStat.WalkSpeed += stat.WalkSpeed;
		CurrentStat.RunSpeed += stat.RunSpeed;
		CurrentStat.JumpForce += stat.JumpForce;
	}

	private void OverrideStat(UnitStat stat)
	{
		if (stat.Health > 0)
		{
			CurrentStat.Health = stat.Health;
		}
		if (stat.Hunger > 0)
		{
			CurrentStat.Hunger = stat.Hunger;
		}
		if (stat.Stamina > 0)
		{
			CurrentStat.WalkSpeed = stat.WalkSpeed;
		}

		if (stat.PassiveHealthRecovery > 0)
		{
			CurrentStat.PassiveHealthRecovery = stat.PassiveHealthRecovery;
		}
		if (stat.PassiveHealthDecline > 0)
		{
			CurrentStat.PassiveHealthDecline = stat.PassiveHealthDecline;
		}
		if (stat.PassiveHungerDecline > 0)
		{
			CurrentStat.PassiveHungerDecline = stat.PassiveHungerDecline;
		}
		if(stat.passiveStaminaRecovery > 0)
		{
			CurrentStat.passiveStaminaRecovery = stat.passiveStaminaRecovery;
		}

		if(stat.WalkSpeed > 0)
		{
			CurrentStat.WalkSpeed = stat.WalkSpeed;
		}
		if (stat.RunSpeed > 0)
		{
			CurrentStat.RunSpeed = stat.RunSpeed;
		}
		if(stat.JumpForce > 0)
		{
			CurrentStat.JumpForce = stat.JumpForce;
		}
	}

}
