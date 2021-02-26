using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    private AudioManager audiomanager;

    public string selectSoundName;

    public GameObject levelselect;

    public string sceneName;

    void Start()
    {
        audiomanager = AudioManager.instance;
        if (audiomanager == null)
        {
            Debug.LogError("FREAK OUT! no audio manager found");
        }
    }

    public void LevelOne()
    {
        audiomanager.PlaySound(selectSoundName);
        StartCoroutine(Wait(0.3f, false, ""));
    }

    public void LevelTwo()
    {
        audiomanager.PlaySound(selectSoundName);
        StartCoroutine(Wait(0.3f, false, ""));
    }

    public void LevelThree()
    {
        audiomanager.PlaySound(selectSoundName);
        StartCoroutine(Wait(0.3f, false, ""));
    }

    public void LevelFour()
    {
        audiomanager.PlaySound(selectSoundName);
        StartCoroutine(Wait(0.3f, false, ""));
    }

    public void TestChamber()
    {
        audiomanager.PlaySound(selectSoundName);
        StartCoroutine(Wait(0.3f, true, "test maybe"));
    }

    public void Back()
    {
        levelselect.SetActive(false);
        audiomanager.PlaySound(selectSoundName);
    }

    private IEnumerator Wait(float length, bool loadScene, string sceneName)
    {
        yield return new WaitForSeconds(length);
        if (loadScene)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
