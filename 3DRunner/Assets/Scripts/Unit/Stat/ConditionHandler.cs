using UnityEngine;

public class ConditionHandler : MonoBehaviour
{
	enum ConditionType
	{
		Health,
		Hunger,
		Stamina
	}

	private UnitStatHandler _statHandler;
	private ConditionSystem[] conditions = new ConditionSystem[3];

	private void Awake()
	{
		_statHandler = new UnitStatHandler();
	}
	private void Start()
	{
		conditions[(int)ConditionType.Health].Init(_statHandler.CurrentStat.Health);
		conditions[(int)ConditionType.Hunger].Init(_statHandler.CurrentStat.Hunger);
		conditions[(int)ConditionType.Stamina].Init(_statHandler.CurrentStat.Stamina);

		_statHandler.OnchangeStat += (stat) => { conditions[(int)ConditionType.Health].MaxCondition = stat.Health; };
		_statHandler.OnchangeStat += (stat) => { conditions[(int)ConditionType.Hunger].MaxCondition = stat.Hunger; };
		_statHandler.OnchangeStat += (stat) => { conditions[(int)ConditionType.Stamina].MaxCondition = stat.Stamina; };
	}



	public ConditionSystem GetHealth => conditions[(int)ConditionType.Health];
	public ConditionSystem GetHunger => conditions[(int)ConditionType.Hunger];
	public ConditionSystem GetStamina => conditions[(int)ConditionType.Stamina];
}
