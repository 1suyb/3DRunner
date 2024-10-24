using System;


public enum StatsChangeType
{
	Add,
	Multiple,
	Override,
}

[Serializable]
public class UnitStat
{
	public StatsChangeType Type;


	public int Health;
	public int Hunger;
	public int Stamina;

	public int PassiveHealthRecovery;
	public int PassiveHealthDecline;
	public int PassiveHungerDecline;
	public int passiveStaminaRecovery;

	public int WalkSpeed;
	public int RunSpeed;
	public int JumpForce;
}
