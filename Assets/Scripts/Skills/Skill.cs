using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Skill : MonoBehaviour 
{
    [SerializeField] protected Animator _animator;
    [SerializeField] protected Rigidbody _rigidbody;

    public Action OnStartSkillAnim;
    public Action OnEndSkillAnim;


    private void OnEnable()
    {
        OnStartSkillAnim += StopWitch;
        OnEndSkillAnim += MoveWitch;
    }

    private void OnDisable()
    {
        OnStartSkillAnim -= StopWitch;
        OnEndSkillAnim -= MoveWitch;
    }

    private void StopWitch() { _rigidbody.isKinematic = true; }
    private void MoveWitch() { _rigidbody.isKinematic = false; }

    public virtual void Use()
    {
    }
}
