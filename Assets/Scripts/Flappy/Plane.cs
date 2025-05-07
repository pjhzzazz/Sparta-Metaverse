using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    Animator animator;
    Rigidbody2D _rigidbody;

    public GameObject gameOverUI;
    public float flapForce = 6f;
    public float forwardSpeed = 3f;
    public bool isDead = false;
    private bool isAlive = true;

    float deathCooldown = 0f;

    bool gameStarted = false;

    bool isFlap = false;

    int bestScore = 0;
    public int BestScore { get { return bestScore; } }

    public bool godMode = false;

    private const string BestScoreKey = "Flappy_BestScore";
    FlappyUIManager uiManager;

   
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        uiManager = FindObjectOfType<FlappyUIManager>();

        bestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
        animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();

        if (animator == null)
        {
            Debug.LogError("Not Founded Animator");
        }
        if (_rigidbody == null)
        {
            Debug.LogError("Not Founded Rigidbody");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted) return;
        if (isDead)
        {
            if (deathCooldown <= 0.0f)
            {
                StartCoroutine(Delay());
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        if(isAlive)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isFlap = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDead) return;

        Vector3 velocity = _rigidbody.velocity;
        velocity.x = forwardSpeed;
        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }

        _rigidbody.velocity = velocity;

        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode) return;
        if (isDead) return;

        isDead = true;
        deathCooldown = 1f;

        animator.SetInteger("isDie", 1);
        StartCoroutine(DelayAlive());
    }

    IEnumerator DelayAlive()
    {
        yield return new WaitForSecondsRealtime(deathCooldown);
        animator.SetInteger("isDie", 0);
    }
    public void StartGame()
    {
        if (gameStarted) return;
        
        isDead = false;
        deathCooldown = 0f;
        gameStarted = true;
    }

    public void Reset()
    {
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        _rigidbody.velocity = Vector2.zero;
    }

    IEnumerator Delay()
    {
        gameOverUI.SetActive(true);
        yield return new WaitForSecondsRealtime(1);
        gameOverUI.SetActive(false);
        uiManager.SetScoreUI();
        Reset();
        isDead = false;
        gameStarted = false;
        Time.timeScale = 0f;
    }
}
