using System;
using UnityEngine;

public enum StatsChangeType
{
	Add,
	Multiple,
	Override,
}

[Serializable]
public class UnitStat
{
	[SerializeField] private StatsChangeType _type;
	public StatsChangeType Type => _type;

	[SerializeField] private int _health;
	[SerializeField] private int _hunger;
	[SerializeField] private int _stamina;

	[SerializeField] private int _passiveHealthRecovery;
	[SerializeField] private int _passiveHealthDecline;
	[SerializeField] private int _passiveHungerDecline;
	[SerializeField] private int _passiveStaminaRecovery;

	[SerializeField] private int _walkSpeed;
	[SerializeField] private int _runSpeed;
	[SerializeField] private int _jumpForce;


	public int Health => _health;
	public int Hunger => _hunger;
	public int Stamina => _stamina;

	public int PassiveHealthRecovery => _passiveHealthRecovery;
	public int PassiveHealthDecline => _passiveHealthDecline;
	public int PassiveHungerDecline => _passiveHungerDecline;
	public int passiveStaminaRecovery => _passiveStaminaRecovery;

	public int WalkSpeed => _walkSpeed;
	public int RunSpeed => _runSpeed;
	public int JumpForce => _jumpForce;
	
	public UnitStat() { }

	public UnitStat(StatsChangeType type, int health, int hunger, int stamina, int passiveHealthRecovery, int passiveHealthDecline, int passiveHungerDecline, int passiveStaminaRecovery, int walkSpeed, int runSpeed, int jumpForce)
	{
		_type = type;
		_health = health;
		_hunger = hunger;
		_stamina = stamina;
		_passiveHealthRecovery = passiveHealthRecovery;
		_passiveHealthDecline = passiveHealthDecline;
		_passiveHungerDecline = passiveHungerDecline;
		_passiveStaminaRecovery = passiveStaminaRecovery;
		_walkSpeed = walkSpeed;
		_runSpeed = runSpeed;
		_jumpForce = jumpForce;
	}
	
	public void MultipleStat(UnitStat sourceStat)
	{
		_health *= sourceStat.Health;
		_hunger *= sourceStat.Hunger;
		_stamina *= sourceStat.Stamina;

		_passiveHealthRecovery *= sourceStat.PassiveHealthRecovery;
		_passiveHealthDecline *= sourceStat.PassiveHealthDecline;
		_passiveHungerDecline *= sourceStat.PassiveHungerDecline;
		_passiveStaminaRecovery *= sourceStat.passiveStaminaRecovery;

		_walkSpeed *= sourceStat.WalkSpeed;
		_runSpeed *= sourceStat.RunSpeed;
		_jumpForce *= sourceStat.JumpForce;
	}

	public void AddStat(UnitStat sourceStat)
	{
		_health += sourceStat.Health;
		_hunger += sourceStat.Hunger;
		_stamina += sourceStat.Stamina;

		_passiveHealthRecovery += sourceStat.PassiveHealthRecovery;
		_passiveHealthDecline += sourceStat.PassiveHealthDecline;
		_passiveHungerDecline += sourceStat.PassiveHungerDecline;
		_passiveStaminaRecovery += sourceStat.passiveStaminaRecovery;

		_walkSpeed += sourceStat.WalkSpeed;
		_runSpeed += sourceStat.RunSpeed;
		_jumpForce += sourceStat.JumpForce;
	}

	public void OverrideStat(UnitStat sourceStat)
	{
		if (sourceStat.Health > 0)
		{
			_health = sourceStat.Health;
		}
		if (sourceStat.Hunger > 0)
		{
			_hunger = sourceStat.Hunger;
		}
		if (sourceStat.Stamina > 0)
		{
			_stamina = sourceStat.Stamina;
		}

		if (sourceStat.PassiveHealthRecovery > 0)
		{
			_passiveHealthRecovery = sourceStat.PassiveHealthRecovery;
		}
		if (sourceStat.PassiveHealthDecline > 0)
		{
			_passiveHealthDecline = sourceStat.PassiveHealthDecline;
		}
		if (sourceStat.PassiveHungerDecline > 0)
		{
			_passiveHungerDecline = sourceStat.PassiveHungerDecline;
		}
		if (sourceStat.passiveStaminaRecovery > 0)
		{
			_passiveStaminaRecovery = sourceStat.passiveStaminaRecovery;
		}

		if (sourceStat.WalkSpeed > 0)
		{
			_walkSpeed = sourceStat.WalkSpeed;
		}
		if (sourceStat.RunSpeed > 0)
		{
			_runSpeed = sourceStat.RunSpeed;
		}
		if (sourceStat.JumpForce > 0)
		{
			_jumpForce = sourceStat.JumpForce;
		}
	}

}

public class UnitStatBuilder
{
	private StatsChangeType _type;

	private int _health;
	private int _hunger;
	private int _stamina;

	private int _passiveHealthRecovery;
	private int _passiveHealthDecline;
	private int _passiveHungerDecline;
	private int _passiveStaminaRecovery;

	private int _walkSpeed;
	private int _runSpeed;
	private int _jumpForce;

	public UnitStatBuilder Type(StatsChangeType value)
	{
		this._type = value;
		return this;
	}

	public UnitStatBuilder Health(int value)
	{
		this._health = value;
		return this;
	}
	public UnitStatBuilder Hunger(int value)
	{
		this._hunger = value;
		return this;
	}
	public UnitStatBuilder Stamina(int value)
	{
		this._stamina = value;
		return this;
	}

	public UnitStatBuilder PassiveHealthRecovery(int value)
	{
		this._passiveHealthRecovery = value;
		return this;
	}
	public UnitStatBuilder PassiveHealthDecline(int value)
	{
		this._passiveHealthDecline = value;
		return this;
	}
	public UnitStatBuilder PassiveHungerDecline(int value)
	{
		this._passiveHungerDecline = value;
		return this;
	}
	public UnitStatBuilder PssiveStaminaRecovery(int value)
	{
		this._passiveStaminaRecovery = value;
		return this;
	}

	public UnitStatBuilder WalkSpeed(int value)
	{
		this._walkSpeed = value;
		return this;
	}
	public UnitStatBuilder RunSpeed(int value)
	{
		this._runSpeed = value;
		return this;
	}
	public UnitStatBuilder JumpForce(int value)
	{
		this._jumpForce = value;
		return this;
	}

	public UnitStat Build()
	{
		return new UnitStat(_type, _health, _hunger, _stamina, _passiveHealthRecovery, _passiveHealthDecline, _passiveHungerDecline, _passiveStaminaRecovery, _walkSpeed, _runSpeed, _jumpForce);
	}

}
