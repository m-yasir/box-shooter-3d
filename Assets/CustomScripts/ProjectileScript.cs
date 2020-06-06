using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float timeToLive = 1f;
    public bool detachChildren = true;
    private void Awake()
    {
        Invoke("DestroyObject", timeToLive);
    }

    public void DestroyObject()
    {
        if (detachChildren)
        {
            transform.DetachChildren();
        }
        Destroy(gameObject);
    }
}   
