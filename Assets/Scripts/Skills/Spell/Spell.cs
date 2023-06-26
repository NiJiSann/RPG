using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : Skill
{
    [SerializeField] private List<SpellUpgrade> _upgrades;
    [SerializeField] private Transform _parent;
    [SerializeField] private Transform _witch;
    private Vector3 _initSize = new Vector3(40f, 40f, 40f);
    private ParticleSystem _spell;
    private float _coolDown = 1.5f;
    public override void Use()
    {
        StartCoroutine(AuraCo());
    }

    private IEnumerator AuraCo()
    {
        OnStartSkillAnim?.Invoke();

        if (_spell == null)
            _spell = (Resources.Load<GameObject>("Blast")).GetComponent<ParticleSystem>();

        _spell.transform.localScale = _initSize;

        var instance = Instantiate(_spell, _parent);
        var currLvl = _upgrades[SkilData.GetSkillLvl(SkillType.shield)];
        var animDuration = .9f; 
        instance.transform.localScale *= currLvl.size;

        if (currLvl.isTwoHandAnim)
        {
            _animator.SetBool("isBlast2", true);
            animDuration = 1.5f;
        }
        _animator.SetTrigger("Blast");
        instance.Play();
        yield return new WaitForSeconds(animDuration);

        instance.transform.parent = null;
        instance.GetComponent<Rigidbody>().velocity = _witch.transform.forward * 10;

        yield return new WaitForSeconds(_coolDown);
        OnEndSkillAnim?.Invoke();
    }
}
