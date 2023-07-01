using System;
using UnityEngine;
using UnityEngine.UI;

public enum SkillState {opened, locked, obtained}

public class SkillTreeItem : MonoBehaviour
{
    [SerializeField] private bool _isBase; 
    [SerializeField] private int _price;

    [SerializeField] private SkillTreeItem[] _leadingSkills;
    [SerializeField] private SkillTreeItem[] _followingSkills;

    [SerializeField] private SkillState _state = SkillState.locked;

    [SerializeField][TextArea] private string _description;
    [SerializeField] private SkillWindow _window;

    private Button _skillBtn;

    public bool IsBase { get { return _isBase; } }
    public string Description { get { return _description; }  }
    public int Price { get { return _price; } }
    public SkillTreeItem[] FollowingSkills { get { return _followingSkills; }  }
    public SkillTreeItem[] LeadingSkills { get { return _leadingSkills; } }
    public SkillState State { 
        get
        {
            return _state; 
        }
        set 
        {
            _state = value;
            OnStateChange?.Invoke(value);

            if (value != SkillState.locked)
                _skillBtn.interactable = true;

        }
    }

    public Action<SkillState> OnStateChange;

    private void Start()
    {
        _skillBtn = GetComponent<Button>();
        _skillBtn.interactable = false;
        _skillBtn.onClick.AddListener( ()=> _window.SetCurrSkill(this));
        State = _state;
    }

    public void Forget() 
    {
        State = SkillState.opened;
    }

    public void Learn()
    {
        State = SkillState.obtained;

        foreach (SkillTreeItem skill in _followingSkills) 
            skill.State = SkillState.opened;

    }

}
