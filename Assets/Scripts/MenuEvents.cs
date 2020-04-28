using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEvents : MonoBehaviour
{
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
        GameObject panel = new GameObject();
        panel = GameObject.Find("ChapterSelectPanel");
        panel.SetActive(!panel.activeSelf);

    }

    public void MenuOptionsShow()
    {
        GameObject panel = new GameObject();
        panel = GameObject.Find("OptionsPanel");
        panel.SetActive(!panel.activeSelf);
    }
}
