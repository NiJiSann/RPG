using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Skill
{
    [SerializeField] private List<ShieldUpgrade> _upgrades;
    [SerializeField] protected Transform _parent;
    
    private Vector3 _initSize = new Vector3(80,80,80);
    private ParticleSystem _shield;
    public override void Use()
    {
        base.Use();
        StartCoroutine(ShieldCo());
    }

    private IEnumerator ShieldCo() 
    {
        OnStartSkillAnim?.Invoke();
        if (_shield == null)
            _shield = Instantiate(Resources.Load<GameObject>("Shield"), _parent).GetComponent<ParticleSystem>();

        _shield.transform.localScale = _initSize;

        var currLvl =  _upgrades[SkilData.GetSkillLvl(SkillType.shield)];
        _shield.transform.localScale *= currLvl.size;
        _animator.SetTrigger("Shield");
        yield return new WaitForSeconds(1.5f);

        _shield.Play();
        yield return new WaitForSeconds(1.5f);
        OnEndSkillAnim?.Invoke();

        yield return new WaitForSeconds(currLvl.duration);
        _shield.Stop();
    }
}