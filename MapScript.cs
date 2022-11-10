using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    RectTransform mapBorder;
    bool largeMap = false;
    [SerializeField] Camera miniMapCamera;
    Transform player;
    Vector3 newPosition;

    private void Start()
    {
        mapBorder = GetComponent<RectTransform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        newPosition.y = transform.position.y;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            ToggleLargeMap();
        }

        newPosition.x = player.position.x;
        newPosition.z = player.position.z;

        miniMapCamera.transform.position = newPosition;
    }

    private void ToggleLargeMap()
    {
        if(largeMap)
        {
            MakeSmall();
        }
        else
        {
            MakeLarge();
        }
    }

    private void MakeLarge()
    {
        mapBorder.offsetMin = new Vector2(0, 0);
        mapBorder.offsetMax = new Vector2(0, 0);
        mapBorder.anchorMax = new Vector2(1, 1);
        miniMapCamera.orthographicSize = 200;
        largeMap = true;
    }

    private void MakeSmall()
    {
        mapBorder.anchorMax = new Vector2(0, 0);
        mapBorder.position = new Vector3(100, 100, 0);
        mapBorder.sizeDelta = new Vector2(200, 200);
        miniMapCamera.orthographicSize = 50;
        largeMap = false;
    }
}
