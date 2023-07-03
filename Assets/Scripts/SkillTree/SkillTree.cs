using UnityEngine;
using UnityEngine.UI;

public class SkillTree : MonoBehaviour
{
    [SerializeField] private SkillTreeItem _baseSkill;
    [SerializeField] private Button _forgetAll;
    [SerializeField] private SkillPointManager _skillPointManager;
    [SerializeField] private SkillWindow _skillWindow;

    private void Awake()
    {
        _baseSkill.IsBase = true;
        _baseSkill.State = SkillState.obtained;
        OpenStartUpSkills();
        SetSkillWindow(_baseSkill);
        _forgetAll.onClick.AddListener(()=>  ForgetFollowingSkills(_baseSkill));
    }

    private void OpenStartUpSkills() 
    {
        foreach (var skill in _baseSkill.FollowingSkills) 
            if (skill.State == SkillState.locked)
                skill.State = SkillState.opened;    
    }

    private void SetSkillWindow(SkillTreeItem skill)
    {
        foreach (var skill_inst in skill.FollowingSkills)
        {
            skill_inst.SkillWindow = _skillWindow;
            SetSkillWindow(skill_inst);
        }
    }

    private void ForgetFollowingSkills(SkillTreeItem skill) 
    {
        foreach (var skill_inst in skill.FollowingSkills)
        {
            if (skill_inst.State == SkillState.obtained)
            {
                SkillData.SetSkill(skill_inst.SkillType, skill_inst.SkillLvl,0);

                skill_inst.Forget();
                _skillPointManager.AddPoints(skill_inst.Price);
                ForgetFollowingSkills(skill_inst);
            }
        }
    }
}
