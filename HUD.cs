using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{

    [SerializeField] private TMP_Text soulsCollectedTxt;

    private void Start()
    {
        CollectableEventSystem.current.onCollectableCollected += IncrementSoulsCollected;

        soulsCollectedTxt.text = "Souls Harvested: " + GameManager.instance.SoulsCollected + "/5";
    }

    private void IncrementSoulsCollected(int id)
    {
        GameManager.instance.SoulsCollected++;
        soulsCollectedTxt.text = "Souls Harvested: " + GameManager.instance.SoulsCollected + "/5";
    }

    private void OnDestroy()
    {
        CollectableEventSystem.current.onCollectableCollected -= IncrementSoulsCollected;
    }
}
