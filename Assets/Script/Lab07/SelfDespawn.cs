using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDespawn : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Contains("Touch"))
        {
            Lean.Pool.LeanPool.Despawn(this.gameObject);
            GameManagement.singleton.PlusScore();
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (transform.position.y < -10)
            Lean.Pool.LeanPool.Despawn(this.gameObject);
    }
}
