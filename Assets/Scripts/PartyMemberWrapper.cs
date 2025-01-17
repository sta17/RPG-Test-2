using UnityEngine;

[System.Serializable]
public class PartyMemberWrapper
{
    [Header("Item Data")]
    [SerializeField] private Unit partyMemberStats;
    [SerializeField] private int currentLevel = 1;
    [SerializeField] private int currentHealth;
    [SerializeField] private int currentHealthMax;
    [SerializeField] private int currentAttack;
    [SerializeField] private int currentDefense;
    [SerializeField] private int currentSpeed;
    [SerializeField] private int currentEvasion = 100;
    [SerializeField] private int currentAccuracy = 100;

    public PartyMemberWrapper()
    {

    }
    public PartyMemberWrapper(int currentLevel, ItemTypes newItemType, Unit newCreature)
    {
        this.currentLevel = currentLevel;
        partyMemberStats = newCreature;
        currentHealthMax = (int)(partyMemberStats.healthBase + (partyMemberStats.healthGainPerLevel * currentLevel));
        currentHealth = currentHealthMax;

        currentAttack = (int)(partyMemberStats.attackDamageBase + (partyMemberStats.attackDamageGainPerLevel * currentLevel));
        currentDefense = (int)(partyMemberStats.defenseBase + (partyMemberStats.defenseGainPerLevel * currentLevel));
        currentSpeed = (int)(partyMemberStats.attackSpeedBase + (partyMemberStats.attackSpeedhGainPerLevel * currentLevel));
    }

}
