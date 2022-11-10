using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CutSceneManager : MonoBehaviour
{

    [SerializeField] private Transform[] focalPoints;
    [SerializeField] private CinemachineVirtualCamera vitualCamera;


    float tempTimer = 20;


    public void SetupCutscene (int id)
    {
        switch (id)
        {
            case 0:
                vitualCamera.Follow = focalPoints[0];
                break;
            case 1:
                vitualCamera.Follow = focalPoints[1];
                break;
        }
    }

    private void Update()
    {
        tempTimer -= Time.deltaTime;

        if(tempTimer > 15 && tempTimer < 16)
        {
            SetupCutscene(0);
        }
        else if( tempTimer >5 && tempTimer < 6)
        {
            SetupCutscene(1);
        }
    }
}
