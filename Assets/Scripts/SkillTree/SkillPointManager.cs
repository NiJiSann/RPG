using System;
using UnityEngine;
using UnityEngine.UI;

public class SkillPointManager: MonoBehaviour
{
    [SerializeField] private Button _addPoint;

    private string KEY;

    public Action OnValueChange;

    private void Start()
    {
        _addPoint.onClick.AddListener(() => AddPoints(1));
        OnValueChange?.Invoke();
    }

    public int GetPonts() => PlayerPrefs.GetInt(KEY, 0);

    public void AddPoints(int val) 
    {
        int t = PlayerPrefs.GetInt(KEY, 0);
        PlayerPrefs.SetInt(KEY, t+val);

        OnValueChange?.Invoke();
    }
}