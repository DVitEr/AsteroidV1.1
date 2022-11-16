using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonRestart : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    public void SettingButton()
    {
        SceneManager.LoadScene(0);
        PanelPlay();
    }
    public void PanelPlay()
    {
        panel.SetActive(false);
    }
    public void PanelPause()
    {
        panel.SetActive(true);
    }
}
