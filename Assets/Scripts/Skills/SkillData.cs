

using UnityEngine;

public enum SkillType {spell, fly, shield, aura}

public class SkilData 
{
    public static void SetSkillLvl(SkillType skillType, int lvl) 
    {
        PlayerPrefs.SetInt(skillType.ToString(), lvl);
    }

    public static int GetSkillLvl(SkillType skillType) 
    { 
        return PlayerPrefs.GetInt(skillType.ToString(), 0);
    }
}
