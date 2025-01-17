using UnityEngine;

[CreateAssetMenu(menuName = "Unit/BaseUnit")]
public class Unit : ScriptableObject
{
    public float defenseBase;
    public float defenseGainPerLevel;
    public float attackDamageBase;
    public float attackDamageGainPerLevel;
    public float attackSpeedBase;
    public float attackSpeedhGainPerLevel;
    public float healthBase;
    public float healthGainPerLevel;

    public bool IsCharacter = false;

    public Sprite Icon;

    public string DisplayName;

    public bool catchable;
}
