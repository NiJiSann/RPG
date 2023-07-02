using UnityEditor.iOS.Xcode;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkillButtonView : MonoBehaviour
{
    [SerializeField] private SkillType _skillType;
    [SerializeField] private Image _icon;

    private Button _btn;

    private void Start()
    {
        _btn = GetComponent<Button>();
        _btn.interactable = false;
        UpdateView();
    }

    private void OnEnable()
    {
        SceneManager.sceneUnloaded += UpdateView;
    }

    private void OnDisable()
    {
        SceneManager.sceneUnloaded -= UpdateView;
    }

    void UpdateView(Scene arg = default)
    {
        if (SkillData.GetSkillLvl(_skillType) == 0) return;

        _icon.gameObject.SetActive(true);
        _btn.interactable = true;

    }
}
