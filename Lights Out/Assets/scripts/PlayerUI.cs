using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerUI : MonoBehaviour
{
    public Player player;
    public Text saveText;
    public Animator anim;
    public GameObject howToPlayMenu;
    public GameObject pauseMenu;
    public GameManager gm;
    public bool loading;
    public Text popupText;

    public static PlayerUI instance;

    void Awake()
    {
        instance = this;
    }

    public void LoadingScreen()
    {
        anim.SetTrigger("Loading");
        StartCoroutine(Wait(6, "", false));
        loading = true;
    }
    public void Resume()
    {
        Debug.Log("Resume button pressed");
        player.isPaused = false;
        pauseMenu.SetActive(false);
        gm.ButtonPressed();
    }
    public void Save()
    {
        Debug.Log("Save button pressed");
        saveText.text = "...";
        StartCoroutine(Wait(0.3f, "", false));
        saveText.text = "NOT WORKING";
        gm.PlayerDies();
    }
    public void HowToPlay()
    {
        Debug.Log("How to play button pressed");
        howToPlayMenu.SetActive(true);
        gm.ButtonPressed();
    }
    public void MainMenu()
    {
        Debug.Log("Main menu button pressed");
        gm.ButtonPressed();
        StartCoroutine(Wait(0.3f, "Main Menu", true));
    }
    public void Back()
    {
        howToPlayMenu.SetActive(false);
        gm.ButtonPressed();
    }
    public void Continue()
    {
        gm.ButtonPressed();
        StartCoroutine(Wait(0.3f, SceneManager.GetActiveScene().name, true));
    }

    public void Death()
    {
        anim.SetTrigger("Death");
    }

    public void NoMoreDeath()
    {
        anim.ResetTrigger("Death");
    }

    private IEnumerator Wait(float length, string sceneName, bool loadScene)
    {
        yield return new WaitForSeconds(length);
        if (loadScene)
        {
            SceneManager.LoadScene(sceneName);
        }
        if (loading)
        {
            anim.ResetTrigger("Loading");
            loading = false;
        }
    }

    public void ChangePopupText(int length, string text)
    {
        StartCoroutine(ChangeTextCoroutine(length, text));
    }

    private IEnumerator ChangeTextCoroutine(int length, string text)
    {
        popupText.text = text;
        yield return new WaitForSeconds(length);
        popupText.text = "";
    }
}
