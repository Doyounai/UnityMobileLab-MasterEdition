using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAI : MonoBehaviour
{
    [SerializeField] float m_speed = 4.0f;
    private Animator m_animator;
    private Rigidbody2D m_body2d;
    private int m_facingDirection = 1;
    private float m_delayToIdle = 0.0f;

    public float Direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        m_animator.SetBool("Grounded", true);
    }

    // Update is called once per frame
    void Update()
    {
        // -- Handle input and movement --
        float inputX = Direction;
        ActionSwapDirection(inputX);
        // Move
        m_body2d.velocity = new Vector2(inputX * m_speed, m_body2d.velocity.y);
        if (Mathf.Abs(inputX) > Mathf.Epsilon)
        {
            ActionRun();
        }
    }

    public void ActionSwapDirection(float inputX)
    {
        // Swap direction of sprite depending on walk direction
        if (inputX > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            m_facingDirection = 1;
        }
        else if (inputX < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            m_facingDirection = -1;
        }
    }
    void ActionRun()
    {
        // Reset timer
        m_delayToIdle = 0.05f;
        m_animator.SetInteger("AnimState", 1);
    }
    void ActionIdle()
    {
        // Prevents flickering transitions to idle
        m_delayToIdle -= Time.deltaTime;
        if (m_delayToIdle < 0)
            m_animator.SetInteger("AnimState", 0);
    }

}
