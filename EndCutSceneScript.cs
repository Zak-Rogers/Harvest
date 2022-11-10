using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCutSceneScript : MonoBehaviour
{
   
    public void EndCutScene()
    {
        GameManager.instance.LoadGameScene();
    }
}
