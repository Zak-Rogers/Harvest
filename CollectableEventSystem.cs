using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableEventSystem : MonoBehaviour
{

    public static CollectableEventSystem current;

    void Awake()
    {
        current = this;
    }

    public event Action<int> onCollectableCollected;


    private void Start()
    {
        GameManager.instance.SubscriptToCollectableEvents();// may need moving to event system?
    }

    public void CollectableCollected(int id)
    {
        if (onCollectableCollected == null) return;

        onCollectableCollected(id);
    }
}
