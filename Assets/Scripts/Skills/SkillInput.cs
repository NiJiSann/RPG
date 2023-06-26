using UnityEngine;

public class SkillInput : MonoBehaviour
{
    [SerializeField] private PointerDownUpHandler _baseSkillBtn;
    [SerializeField] private PointerDownUpHandler _firstSkillBtn;
    [SerializeField] private PointerDownUpHandler _secondSkillBtn;
    [SerializeField] private PointerDownUpHandler _thirdSkillBtn;
    
    [SerializeField] private SkillProvider _skillProvider;

    void Start()
    {
        _baseSkillBtn.OnDown.AddListener(()=> _skillProvider.UseSkill(SkillInputType.Base));
        _firstSkillBtn.OnDown.AddListener(() => _skillProvider.UseSkill(SkillInputType.First));
        _secondSkillBtn.OnDown.AddListener(() => _skillProvider.UseSkill(SkillInputType.Second));
        _thirdSkillBtn.OnDown.AddListener(() => _skillProvider.UseSkill(SkillInputType.Third));
    }
}
