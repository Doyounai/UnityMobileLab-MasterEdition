using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBody : MonoBehaviour
{
    public HeroKnight _player;
    public int Health = 3;
    private Animator m_animator;

    private void Start()
    {
        m_animator = this.transform.parent.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Contains("Enemy"))
        {
            if (Health <= 0)
                return;
            //Fetch the current Animation clip information for the base layer
            AnimatorClipInfo[] m_CurrentClipInfo = m_animator.GetCurrentAnimatorClipInfo(0);

            //Access the Animation clip name
            //Debug.Log(m_CurrentClipInfo[0].clip.name);

            if (m_CurrentClipInfo[0].clip.name.Contains("HeroKnight_Block"))
            {

                Vector3 direction = collision.transform.position - this.transform.position;
                Debug.Log("Block: " + direction.ToString());
                _player.ActionSwapDirection(direction.x);

                return;
            }

            _player.ActionUnderAttack();
            Health--;

            if (Health <= 0)
                _player.ActionDeath();

        }
    }

}
