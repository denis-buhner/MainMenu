using UnityEngine;

public class MenuNavigator : MonoBehaviour
{
    [SerializeField] private GameObject _menuLayer;
    [SerializeField] private GameObject _aboutLayer;
    [SerializeField] private GameObject _soundSettingsLayer;

    public void ShowAbout()
    {
        _menuLayer.SetActive(false);
        _aboutLayer.SetActive(true);
    }

    public void ShowSoundSettings()
    {
        _menuLayer.SetActive(false);
        _soundSettingsLayer.SetActive(true);
    }

    public void BackToMenu()
    {
        _menuLayer.SetActive(true);
        _aboutLayer.SetActive(false);
        _soundSettingsLayer.SetActive(false);
    }
}
