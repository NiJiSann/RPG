using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SkillWindow : MonoBehaviour
{
    [SerializeField] private TMP_Text _info;
    [SerializeField] private Button _learnSkill;
    [SerializeField] private Button _forgetSkill;

    [SerializeField] private SkillPointManager _skillPointManager;

    private SkillTreeItem _currSkill;

    private void OnEnable()
    {
        _skillPointManager.OnValueChange += UpdateInfo;
    }

    private void OnDisable()
    {
        _skillPointManager.OnValueChange -= UpdateInfo;

    }

    public void SetCurrSkill(SkillTreeItem skill) 
    {
        _info.text = skill.Description;
        _currSkill = skill; 
        UpdateInfo();
        _forgetSkill.onClick.AddListener(_currSkill.Forget);
        _learnSkill.onClick.AddListener(_currSkill.Learn);

    }

    private void UpdateInfo() 
    {
        CanForgetSkill();
        CanLearnSkill();

        _learnSkill.gameObject.SetActive(!_currSkill.IsBase);
        _forgetSkill.gameObject.SetActive(!_currSkill.IsBase);

    }

    private void CanForgetSkill() 
    {
        if (_currSkill.State  != SkillState.obtained)
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
    }

    private void CanLearnSkill()
    {
        if ( _currSkill.Price <= _skillPointManager.GetPonts()) 
        {
            _learnSkill.interactable = true;
        }
        else
        {
            _learnSkill.interactable= false;
        }
    }

}
