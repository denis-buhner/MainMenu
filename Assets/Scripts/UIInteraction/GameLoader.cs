using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    public void LadScene()
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void Quit()
    {
        #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}
