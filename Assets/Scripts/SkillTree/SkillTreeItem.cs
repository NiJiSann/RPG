using System;
using UnityEngine;
using UnityEngine.UI;

public class SkillTreeItem : MonoBehaviour
{
    [SerializeField] private SkillType _skillType;
    [SerializeField] private int _skillLvl;
    [SerializeField] private int _price;
    [SerializeField] private SkillTreeItem[] _leadingSkills;
    [SerializeField] private SkillTreeItem[] _followingSkills;
   
    [SerializeField] private Button _skillBtn;

    private SkillState _state = SkillState.locked;
    private SkillWindow _window;

    public Action<SkillState> OnStateChange;

    public SkillType SkillType => _skillType;
    public int SkillLvl => _skillLvl;
    public int Price => _price;
    public SkillTreeItem[] FollowingSkills => _followingSkills;
    public SkillTreeItem[] LeadingSkills => _leadingSkills;

    public bool IsBase { get; set; }
    public SkillWindow SkillWindow 
    {
        get => _window;

        set 
        {
            _window = value;
            _skillBtn.onClick.AddListener(() => _window.OnCurrSkillChange?.Invoke(this));
        }
    }

    public SkillState State { 
        get => _state;
        
        set 
        {
            _state = value;
            OnStateChange?.Invoke(value);

            if (value != SkillState.locked)
                _skillBtn.interactable = true;
        }
    }

    private void Start()
    {
        RestoreSkillProgress();
    }

    public void Forget() 
    {
        State = SkillState.opened; 
    }

    public void Learn()
    {
        State = SkillState.obtained;

        foreach (SkillTreeItem skill in _followingSkills) 
            if (skill.State == SkillState.locked)
               skill.State = SkillState.opened;
    }

    private void RestoreSkillProgress()
    {
        if (SkillData.GetSkillLvl(SkillType) >= SkillLvl)
            Learn();
    }

} 