using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillView : MonoBehaviour
{
    [SerializeField] private Sprite _locked;
    [SerializeField] private Color _openedColor;
    [SerializeField] private Color _obtainedColor;
    
    private SkillTreeItem _skill;
    private Image _image;
    private Sprite _opened;

    private void OnEnable()
    {
        _skill.OnStateChange += UpdateView;
    }

    private void OnDisable()
    {
        _skill.OnStateChange -= UpdateView;
    }

    private void Awake()
    {
        _image = GetComponent<Image>();
        _opened = _image.sprite;
        _skill = GetComponentInParent<SkillTreeItem>();
    }

    public void UpdateView(SkillState state) 
    {
        _image.sprite = _opened;

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
