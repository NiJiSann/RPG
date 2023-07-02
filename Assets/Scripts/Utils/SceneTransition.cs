using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private LoadSceneMode _loadSceneMode;
    [SerializeField] private string _sceneName;
    [SerializeField] private bool _isUnload;
    private Button _btn;

    private void Start()
    {
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(StartTransition);
    }

    private void StartTransition() 
    {
        if (_isUnload)
            SceneManager.UnloadSceneAsync(_sceneName);
        else
            SceneManager.LoadScene(_sceneName, _loadSceneMode);
    }
}