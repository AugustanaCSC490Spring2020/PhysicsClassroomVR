using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEvents : MonoBehaviour
{

    private GameObject panel;

    public void ChapterClick()
    {
            SceneManager.LoadScene(this.name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChapterSelectShow()
    {
        panel = GameObject.Find("ChapterSelectPanel");
        panel.SetActive(!panel.activeSelf);

    }

    public void MenuOptionsShow()
    {
        panel = GameObject.Find("OptionsPanel");
        panel.SetActive(!panel.activeSelf);
    }
}
