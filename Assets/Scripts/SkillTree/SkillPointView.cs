using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillPointView : MonoBehaviour
{
    [SerializeField] private TMP_Text _amount;
    [SerializeField] private SkillPointManager _skillPointManager;

    private void OnEnable()
    {
        _skillPointManager.OnValueChange += UpdateView;    
    }

    private void OnDisable()
    {
        _skillPointManager.OnValueChange -= UpdateView;

    }

    private void UpdateView()
    {
        _amount.text = _skillPointManager.GetPonts().ToString();
    }

}
