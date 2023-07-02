using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillWindow : MonoBehaviour
{
    [SerializeField] private TMP_Text _info;
    [SerializeField] private Button _learnSkill;
    [SerializeField] private Button _forgetSkill;
    [SerializeField] private SkillPointManager _skillPointManager;

    private SkillTreeItem _currSkill;

    public Action<SkillTreeItem> OnCurrSkillChange;

    private void OnEnable()
    {
        _skillPointManager.OnValueChange += UpdateInfo;
        OnCurrSkillChange += SetCurrSkill;
    }

    private void OnDisable()
    {
        _skillPointManager.OnValueChange -= UpdateInfo;
        OnCurrSkillChange -= SetCurrSkill;
    }

    private void SetCurrSkill(SkillTreeItem skill) 
    {
        gameObject.SetActive(true);
        _forgetSkill.onClick.RemoveAllListeners();
        _learnSkill.onClick.RemoveAllListeners();

        _info.text = Resources.Load<SkillDescription>($"Descriptions/{skill.SkillType}_{skill.SkillLvl}").description;
        _currSkill = skill; 
        UpdateInfo();
        _forgetSkill.onClick.AddListener(ForgetCurrSkill);
        _learnSkill.onClick.AddListener(LearnCurrSkill);
    }

    private void UpdateInfo() 
    {
        CanForgetSkill();
        CanLearnSkill();

        _learnSkill.gameObject.SetActive(!_currSkill.IsBase);
        _forgetSkill.gameObject.SetActive(!_currSkill.IsBase);
    }

    private void ForgetCurrSkill()
    {
        _currSkill.Forget();
        _skillPointManager.AddPoints(_currSkill.Price);
        UpdateInfo();
    }

    private void LearnCurrSkill()
    {
        _currSkill.Learn();
        _skillPointManager.AddPoints(-_currSkill.Price);
        UpdateInfo();
    }

    private void CanForgetSkill() 
    {
        if (_currSkill.State != SkillState.obtained)
        {
            _forgetSkill.interactable = false;
            return;
        }

        foreach (var skill in _currSkill.FollowingSkills)
        {
            if (skill.State == SkillState.obtained)
            {
                _forgetSkill.interactable = false;
                return;
            }
        }

        _forgetSkill.interactable = true;
    }

    private void CanLearnSkill()
    {
        _learnSkill.interactable = false;

        bool canLearn = false;

        foreach (var skill in _currSkill.LeadingSkills)
            if (skill.State == SkillState.obtained)
                canLearn = true;

        if (!canLearn) { return; }

        if ( _currSkill.Price <= _skillPointManager.GetPonts() && _currSkill.State == SkillState.opened) 
            _learnSkill.interactable = true;
    }
}