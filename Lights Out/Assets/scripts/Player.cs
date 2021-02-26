using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Experimental.Rendering.Universal;

public class Player : MonoBehaviour
{
    #region declarations
    [Header("Player Stats")]
    public float playerMaxHealth;
    public float playerHealth;
    public float playerMoveSpeed;
    public int playerDamage = 1;

    [Header("General Components")]
    public Rigidbody2D rb;
    public Animator anim;
    public GameManager gm;
    public GameObject pauseMenu;
    public PlayerGFX playerGFX;
    public GameObject gameOverScreen;
    public PlayerUI playerUI;
    public GameObject inventoryPannel;
    public bool inventoryActive = false;
    public string currentObject;
    public Interactable interactable;

    [Header("General Settings")]

    [Header("Audio Manager")]
    private AudioManager audiomanager;

    [Header("Player Light")]
    public Light2D playerlight;
    public float playerLightDecay = 0.1f;

    [Header("Misc")]
    public bool isPaused;
    public bool canInteract = false;

    Vector2 movement;

    public Interactable[] firstList;

    public static Player instance;
    #endregion
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        playerlight.intensity = 1f;
        playerHealth = playerMaxHealth;
        audiomanager = AudioManager.instance;
        if (audiomanager == null)
        {
            Debug.LogError("FREAK OUT! no audio manager found");
        }

        firstList = GameObject.FindObjectsOfType<Interactable>();
    }

    void Update()
    {
        if (playerlight.intensity > 1)
        {
            playerlight.intensity = 1;
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerMoveSpeed = 4;
        }
        else
        {
            playerMoveSpeed = 2;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerTakeDamage();
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                isPaused = false;
                pauseMenu.SetActive(false);
                return;
            }
            isPaused = true;
            pauseMenu.SetActive(true);
        }
    
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (inventoryActive)
            {
                inventoryActive = false;
                inventoryPannel.SetActive(false);
            }
            else
            {
                inventoryPannel.SetActive(true);
                inventoryActive = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (playerlight.intensity >= 0f && !isPaused)
        {
            playerlight.intensity -= (playerLightDecay * Time.fixedDeltaTime/10);
        }
        if (!isPaused)
        {
            rb.MovePosition(rb.position + movement * playerMoveSpeed * Time.fixedDeltaTime);
        }
    }

    public void PlayerTakeDamage()
    {
        playerHealth -= playerDamage;
        anim.Play("Player Hurt");
        audiomanager.PlaySound("Hurt");

        if (playerHealth <= 0)
        {
            PlayerDeath();
        }
    }

    public void GainHealth(int health)
    {
        if (playerHealth < 3)
        {
            playerHealth += health;
        }
    }

    public void PlayerDeath()
    {
        gm.PlayerDies();
        StartCoroutine(PlayerDeath_Coroutine());
    }

    private IEnumerator PlayerDeath_Coroutine()
    {
        playerUI.Death();
        yield return new WaitForSeconds(3f);
        playerUI.NoMoreDeath();
        gameOverScreen.SetActive(true);
        playerGFX.DestroyGFX();
    }

    public void LightIncrease(float lightIncrease)
    {
        playerlight.intensity += lightIncrease;
    }
}
