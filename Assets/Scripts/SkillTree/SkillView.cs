using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillView : MonoBehaviour
{
    [SerializeField] private Sprite _locked;
    [SerializeField] private Color _openedColor;
    [SerializeField] private Color _obtainedColor;
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _lvl;
    
    private Sprite _opened;
    private SkillTreeItem _skill;

    private void OnEnable() => _skill.OnStateChange += UpdateView;

    private void OnDisable() => _skill.OnStateChange -= UpdateView;

    private void Awake()
    {
        _skill = GetComponentInParent<SkillTreeItem>();
        UpdateView(_skill.State);
    }

    public void UpdateView(SkillState state) 
    {
        _opened = Resources.Load<Sprite>($"SkillSprites/{_skill.SkillType}_{_skill.SkillLvl}");
        _image.sprite = _opened;
        var lvl = _skill.SkillLvl == 0 ? "" : _skill.SkillLvl.ToString();
        _lvl.text = lvl;
        switch (state) 
        {
            case SkillState.opened:
                _image.color = _openedColor;
                break;
            case SkillState.locked:
                _image.sprite = _locked;
                _image.color = Color.white;
                break;
            case SkillState.obtained:
                _image.color = _obtainedColor;
                break;
        }
    }
}