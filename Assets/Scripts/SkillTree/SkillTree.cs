using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTree : MonoBehaviour
{
    [SerializeField] private SkillTreeItem _baseSkill;
    [SerializeField] private Button _forgetAll;
    [SerializeField] private SkillPointManager _skillPointManager;

    private void Start()
    {
        _forgetAll.onClick.AddListener(()=>  ForgetFollowingSkills(_baseSkill));
    }

    private void ForgetFollowingSkills(SkillTreeItem skill) 
    {
        foreach (var skill_inst in skill.FollowingSkills)
        {
            if (skill_inst.State == SkillState.obtained)
            {
                skill_inst.Forget();
                ForgetFollowingSkills(skill_inst);
            }
        }
    }
}
