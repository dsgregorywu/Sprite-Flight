using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.Collections.Generic;



public class PlayerController : MonoBehaviour
{
    private bool hasDied = false;
    public float thrustForce = 1f;
    public GameObject boosterFlame;
    private float elapsedTime = 0f;
    private float score = 0f;
    public float scoreMultiplier = 10f;
    public UIDocument uiDocument;
    private Label scoreText;
    public GameObject explosionEffect;
    private Button restartButton;
    [SerializeField] private List<GameObject> walls;
    [SerializeField] private AudioClip boosterSound;
    [SerializeField] private AudioClip deathSound;
    private AudioSource audioSource;



    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scoreText = uiDocument.rootVisualElement.Q<Label>("ScoreLabel");
        restartButton = uiDocument.rootVisualElement.Q<Button>("RestartButton");
        restartButton.style.display = DisplayStyle.None;
        restartButton.clicked += ReloadScene;
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing on the GameObject!");
        }
    }

    void Update()
    {
        Debug.Log("uiDocument: " + uiDocument);
        elapsedTime += Time.deltaTime;
        Debug.Log("Elapsed time: " + elapsedTime);
        score = Mathf.FloorToInt(elapsedTime * scoreMultiplier);
        scoreText.text = "Score: " + score;
        Debug.Log("Score: " + score);

        if (Mouse.current.leftButton.isPressed)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
            Vector2 direction = (mousePos - transform.position).normalized;
            Debug.Log("Mouse position: " + mousePos);
            transform.up = direction;
            rb.AddForce(direction * thrustForce);
            if (!audioSource.isPlaying)
            {
                PlayBoosterSound();
            }
            boosterFlame.SetActive(true);
        }
        else
        {
            if (audioSource.isPlaying)
            {
                StopBoosterSound();
            }
            boosterFlame.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasDied && collision.gameObject.name != "Spaceship")
        {
            hasDied = true;
            boosterFlame.SetActive(false);
            StopBoosterSound();
            PlayDeathSound();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            restartButton.style.display = DisplayStyle.Flex;
            foreach (var wall in walls)
            {
                wall.SetActive(false);
            }
            foreach (var sr in GetComponentsInChildren<SpriteRenderer>())
            {
                sr.enabled = false;
            }
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;
            float delay = (deathSound != null) ? deathSound.length : 0.5f;
            StartCoroutine(DeactivateAfterDelay(delay));
        }
    }

    private System.Collections.IEnumerator DeactivateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }


    void ReloadScene()
    {
        if (audioSource != null)
        {
            audioSource.Stop(); 
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        foreach (var wall in walls)
        {
            wall.SetActive(true);
        }
    }

    private void PlayBoosterSound()
    {
        if (audioSource != null && boosterSound != null)
        {
            audioSource.clip = boosterSound;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    private void StopBoosterSound()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }
    
    private void PlayDeathSound()
    {
        if (audioSource != null && deathSound != null)
        {
            audioSource.PlayOneShot(deathSound);
        }
    }
}
