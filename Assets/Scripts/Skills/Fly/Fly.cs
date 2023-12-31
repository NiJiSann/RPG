using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Fly : Skill
{
    [SerializeField] private List<FlyUpgrade> _upgrades;

    public Rigidbody PlayerRb { get; set; }

    public override void Use()
    {
        base.Use();
        StartCoroutine(UseCo());
    }

    private IEnumerator UseCo() 
    {
        var currLvl = _upgrades[SkillData.GetSkill(SkillType.Fly)];

        _animator.SetBool("isFlying", true);
        var initDrag = _rigidbody.drag;
        _rigidbody.drag = currLvl.drag;
        yield return new WaitForSeconds(currLvl.duration);
        _rigidbody.drag = initDrag;
        _animator.SetBool("isFlying", false);
    }
}
