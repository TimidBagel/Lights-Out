using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Light2D playerlight;

    [Header("Sounds")]
    public string selectSoundName;
    public string hurtSoundName;
    public string explosionSoundName;
    public string pickupSoundName;
    public string shootSoundName;

    [Header("Audio Manager")]
    private AudioManager audiomanager;

    void Start()
    {
        audiomanager = AudioManager.instance;
        if (audiomanager == null)
        {
            Debug.LogError("FREAK OUT! no audio manager found");
        }
    }

    public void ItemPickup()
    {
        audiomanager.PlaySound(pickupSoundName);
    }

    public void PlayerDies()
    {
        audiomanager.PlaySound(explosionSoundName);
    }

    public void ButtonPressed()
    {
        audiomanager.PlaySound(selectSoundName);
    }

    public void EnterRoom()
    {
        audiomanager.PlaySound("Entering Room");
    }
}
