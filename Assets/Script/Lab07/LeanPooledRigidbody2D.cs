using Lean.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LeanPooledRigidbody2D : MonoBehaviour, IPoolable
{
    public void OnDespawn()
    {
        var rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = Vector2.zero;
        rigidbody.angularVelocity = 0;
    }
    public void OnSpawn()
    {
    }
}
