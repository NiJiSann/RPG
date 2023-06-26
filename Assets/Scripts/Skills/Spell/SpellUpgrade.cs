using UnityEngine;

[CreateAssetMenu(fileName = "SpellUpgrade", menuName = "ScriptableObjects/SpellUpgrade", order = 1)]

public class SpellUpgrade : ScriptableObject
{
    public float damage;
    public float size;
    public bool isTwoHandAnim;
}
