using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PointerDownUpHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    public UnityEvent OnDown;
    public UnityEvent OnUp;

    public UnityEvent WhilePressed;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private IEnumerator WhilePressedCo()
    {
        while (true)
        {
            WhilePressed?.Invoke();
            yield return null;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!_button.interactable) return;

        StopAllCoroutines();
        StartCoroutine(WhilePressedCo());

        OnDown?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StopAllCoroutines();
        OnUp?.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
        OnUp?.Invoke();
    }
    public void OnPointerEnter(PointerEventData eventData) { }
}