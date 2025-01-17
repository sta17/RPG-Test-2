using UnityEngine;

[CreateAssetMenu(menuName = "Unit/Person")]
public class Person : Unit
{
    public new bool IsCharacter = true;

    public string DisplayTitle;

    public int StrengthStart;

    public int FinesseStart;

    public int KnowledgeStart;
}
