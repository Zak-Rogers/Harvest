using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    [SerializeField] private int id;

    private void Start()
    {
        if(id <= GameManager.instance.SoulsCollected || id > GameManager.instance.SoulsCollected + 1)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            CollectableEventSystem.current.CollectableCollected(id);
            Destroy(gameObject);
        }
    }

}
