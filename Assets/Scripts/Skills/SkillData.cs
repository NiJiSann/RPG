using UnityEngine;

public class SkillData 
{
    public static void SetSkill(SkillType skillType, int lvl, int isSkillAchieved = 1) 
    {
        PlayerPrefs.SetInt(skillType.ToString(), lvl);
        PlayerPrefs.SetInt($"{skillType}_{lvl}", isSkillAchieved);
    }
    public static int GetSkill(SkillType skillType) => PlayerPrefs.GetInt(skillType.ToString(), 0);

    public static int GetSkillState(SkillType skillType, int lvl)
    {
        return PlayerPrefs.GetInt($"{skillType}_{lvl}", 0);

    }
}
