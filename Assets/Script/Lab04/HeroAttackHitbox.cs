using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttackHitbox : MonoBehaviour
{
    private Animator m_animator;

    //Attack Hit Box
    public GameObject _AttackZoneR;
    public GameObject _AttackZoneL;
    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        //Fetch the current Animation clip information for the base layer
        AnimatorClipInfo[] m_CurrentClipInfo = m_animator.GetCurrentAnimatorClipInfo(0);

        //Access the Animation clip name
        Debug.Log(m_CurrentClipInfo[0].clip.name);

        if (m_CurrentClipInfo[0].clip.name.Contains("HeroKnight_Idle"))
        {
            _AttackZoneR.GetComponent<BoxCollider2D>().enabled = false;
            _AttackZoneL.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void AttackZone(float inputX)
    {
        // Swap direction of sprite depending on walk direction
        if (inputX > 0)
            _AttackZoneR.GetComponent<BoxCollider2D>().enabled = true;
        else if (inputX < 0)
            _AttackZoneL.GetComponent<BoxCollider2D>().enabled = true;
    }

}
