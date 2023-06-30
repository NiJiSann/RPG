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
    public SkillState State { get { return _state; } }

    public Action<SkillState> OnStateChange;

    private void Start()
    {
        OnStateChange?.Invoke(_state);
        _skillBtn = GetComponent<Button>();
        _skillBtn.onClick.AddListener( ()=> _window.SetCurrSkill(this)); 
    }

    public void Forget() 
    {
        _state = SkillState.opened;
        OnStateChange?.Invoke(_state);
    }

    public void Learn()
    {
        _state = SkillState.obtained;
        OnStateChange?.Invoke(_state);
    }

}
