using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEvents : MonoBehaviour
{

    private GameObject chapterPanel;
    private GameObject optionsPanel;

    private void Start()
    {
        chapterPanel = GameObject.Find("ChapterSelectPanel");
        optionsPanel = GameObject.Find("OptionsPanel");
    }

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
        chapterPanel.SetActive(!chapterPanel.activeSelf);

    }

    public void MenuOptionsShow()
    {
        optionsPanel.SetActive(!optionsPanel.activeSelf);
    }
}
