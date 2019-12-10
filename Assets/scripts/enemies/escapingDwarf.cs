using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class escapingDwarf : MonoBehaviour
{

    Rigidbody2D body;
    [SerializeField] Animator animator;
    [SerializeField] AudioSource cry;
    Vector2 direction;
    [SerializeField] float speed;
    bool run = false;
    PlayerController player;
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();
    }
    void Update()
    {
        if (run)
        {
            direction = new Vector2(1 * speed, 0);
        }
    }

    enum State
    {
        IDLE,
        SURPRISED,
        RUN
    }
    State state = State.IDLE;

    private void FixedUpdate()
    {
        body.velocity = direction;
    }
    public void playerDetected()
    {
        cry.Play();
        animator.SetBool("playerOnSight", true);
        state = State.SURPRISED;
        player.freeze();
    }
    void startRunning()
    {
        animator.transform.Rotate(0, 180, 0);
        animator.SetBool("startRunning", true);
        run = true;
        state = State.RUN;
    }
    void loadWinningScene()
    {
        SceneManager.LoadScene("Winning");
    }
    private void OnBecameInvisible()
    {
        if (run)
        {
            Destroy(gameObject);
        }
    }
}
