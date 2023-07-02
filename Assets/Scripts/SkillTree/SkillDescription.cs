using UnityEngine;

[CreateAssetMenu(fileName = "Name_Lvl", menuName = "ScriptableObjects/SkillDescription", order = 1)]
public class SkillDescription : ScriptableObject
{
    [TextArea]public string description;
}
