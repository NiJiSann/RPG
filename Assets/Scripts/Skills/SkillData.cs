using UnityEngine;

public class SkillData 
{
    public static void SetSkillLvl(SkillType skillType, int lvl) => PlayerPrefs.SetInt(skillType.ToString(), lvl);
    public static int GetSkillLvl(SkillType skillType) => PlayerPrefs.GetInt(skillType.ToString(), 0);
}
