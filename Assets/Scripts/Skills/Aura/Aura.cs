using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aura : Skill
{
    [SerializeField] private List<AuraUpgrade> _upgrades;
    [SerializeField] protected Transform _parent;

    private Vector3 _initSize = new Vector3(80, 80, 80);
    private ParticleSystem _aura;

    public override void Use()
    {
        base.Use();
        StartCoroutine(AuraCo());
    }

    private IEnumerator AuraCo()
    {
        OnStartSkillAnim?.Invoke();
        if (_aura == null)
            _aura = Instantiate(Resources.Load<GameObject>("Aura"), _parent).GetComponent<ParticleSystem>();

        _aura.transform.localScale = _initSize;

        var currLvl = _upgrades[SkilData.GetSkillLvl(SkillType.Aura)];
        _aura.transform.localScale *= currLvl.size;
        _animator.SetTrigger("Aura");
        yield return new WaitForSeconds(1.25f);

        _aura.Play();
        yield return new WaitForSeconds(1.25f);
        OnEndSkillAnim?.Invoke();
        yield return new WaitForSeconds(currLvl.duration);
        _aura.Stop();
    }
}