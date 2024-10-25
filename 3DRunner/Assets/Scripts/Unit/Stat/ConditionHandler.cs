using System.Collections;
using UnityEngine;

public class ConditionHandler : MonoBehaviour
{
	enum ConditionType
	{
		Health = 0,
		Hunger = 1,
		Stamina = 2
	}

	private UnitStatHandler _statHandler;
	private ConditionSystem[] conditions = new ConditionSystem[3];

	public bool IsConditionsNull => ((GetHealth==null)|| (GetHunger==null) || (GetStamina==null));

	public ConditionSystem GetHealth => conditions[(int)ConditionType.Health];
	public ConditionSystem GetHunger => conditions[(int)ConditionType.Hunger];
	public ConditionSystem GetStamina => conditions[(int)ConditionType.Stamina];


	private WaitForSeconds _spendTime = new WaitForSeconds(1);
	private IEnumerator Coroutine;

	private void Awake()
	{
		_statHandler = GetComponent<UnitStatHandler>();
	}
	public void Init()
	{
		conditions[(int)ConditionType.Health] = new ConditionSystem();
		conditions[(int)ConditionType.Hunger] = new ConditionSystem();
		conditions[(int)ConditionType.Stamina] = new ConditionSystem();

		conditions[(int)ConditionType.Health].Init(_statHandler.CurrentStat.Health);
		conditions[(int)ConditionType.Hunger].Init(_statHandler.CurrentStat.Hunger);
		conditions[(int)ConditionType.Stamina].Init(_statHandler.CurrentStat.Stamina);

		_statHandler.OnchangeStat += (stat) => { conditions[(int)ConditionType.Health].MaxCondition = stat.Health; };
		_statHandler.OnchangeStat += (stat) => { conditions[(int)ConditionType.Hunger].MaxCondition = stat.Hunger; };
		_statHandler.OnchangeStat += (stat) => { conditions[(int)ConditionType.Stamina].MaxCondition = stat.Stamina; };

		Coroutine = UpdateConditions();
		StartUpdateConditions();
		GetHealth.OnExhaustEvent += StopUpdateConditions;
	}

	private void StopUpdateConditions()
	{
		StopCoroutine(Coroutine);
	}
	private void StartUpdateConditions()
	{
		StartCoroutine(Coroutine);
	}

	private IEnumerator UpdateConditions()
	{
		while(true)
		{
			GetHunger.Subtract(_statHandler.CurrentStat.PassiveHungerDecline);
			if (GetHunger.Condition == 0)
			{
				GetHealth.Subtract(_statHandler.CurrentStat.PassiveHealthDecline);
			}
			else
			{
				GetHealth.Add(_statHandler.CurrentStat.PassiveHealthRecovery);
			}
			GetStamina.Add(_statHandler.CurrentStat.passiveStaminaRecovery);
			yield return _spendTime;
		}
	}
	



}
