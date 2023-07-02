using UnityEngine;

public class SkillProvider : MonoBehaviour
{
    [SerializeField] private Skill _baseSkill;
    [SerializeField] private Skill _firstSkill;
    [SerializeField] private Skill _secondSkill;
    [SerializeField] private Skill _thirdSkill;

    private bool _isInputBlocked = false;

    private void OnEnable()
    {
        _baseSkill.OnStartSkillAnim += BlockInput;
        _firstSkill.OnStartSkillAnim += BlockInput;
        _secondSkill.OnStartSkillAnim += BlockInput;
        _thirdSkill.OnStartSkillAnim += BlockInput;

        _baseSkill.OnEndSkillAnim += UnblockInput;
        _firstSkill.OnEndSkillAnim += UnblockInput;
        _secondSkill.OnEndSkillAnim += UnblockInput;
        _thirdSkill.OnEndSkillAnim += UnblockInput;
    }

    private void OnDisable()
    {
        _baseSkill.OnStartSkillAnim -= BlockInput;
        _firstSkill.OnStartSkillAnim -= BlockInput;
        _secondSkill.OnStartSkillAnim -= BlockInput;
        _thirdSkill.OnStartSkillAnim -= BlockInput;

        _baseSkill.OnEndSkillAnim -= UnblockInput;
        _firstSkill.OnEndSkillAnim -= UnblockInput;
        _secondSkill.OnEndSkillAnim -= UnblockInput;
        _thirdSkill.OnEndSkillAnim -= UnblockInput;
    }

    private void BlockInput() => _isInputBlocked = true;
    private void UnblockInput() => _isInputBlocked = false;

    public void UseSkill(SkillInputType type) 
    {
        if (_isInputBlocked) return;

        switch (type)
        {
            case SkillInputType.Base:
                _baseSkill.Use(); break; 
            case SkillInputType.First:
                _firstSkill.Use(); break;
            case SkillInputType.Second:
                _secondSkill.Use(); break;
            case SkillInputType.Third:
                _thirdSkill.Use(); break;
        }   
    }
}
