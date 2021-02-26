using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Text versiontext;
    public string currentVersion;

    public string selectSoundName;

    //cache
    private AudioManager audiomanager;

    public GameObject levelselect;

    void Start()
    {
        versiontext.text = currentVersion;

        //caching
        audiomanager = AudioManager.instance;
        if(audiomanager == null)
        {
            Debug.LogError("FREAK OUT! no audio manager found");
        }
    }

    public void Play()
    {
        audiomanager.PlaySound(selectSoundName);
        levelselect.SetActive(true);
    }

    public void Quit()
    {
        audiomanager.PlaySound(selectSoundName);
        StartCoroutine(Wait(0.3f, true));
    }
    
    private IEnumerator Wait(float length, bool quit)
    {
        yield return new WaitForSeconds(length);
        if (quit)
        {
            Application.Quit();
        }
    }
}
