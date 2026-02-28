using UnityEngine;

public class About : MonoBehaviour
{
    [SerializeField] private GameObject _menuLayer;
    [SerializeField] private GameObject _aboutLayer;

    public void ShowAbout()
    {
        _menuLayer.SetActive(false);
        _aboutLayer.SetActive(true);
    }

    public void BackToMenu()
    {
        _menuLayer.SetActive(true);
        _aboutLayer.SetActive(false);
    }
}
