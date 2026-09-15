using System;
using UnityEngine;

public class FindSceneCtrl : MonoBehaviour
{
    public EventHandler eventHandler;
    public string targetScene = "cubi";
    private SceneCtrl sceneCtrl;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sceneCtrl = SceneCtrl.instance;
        eventHandler.OnEnter.AddListener(OnEnter);
    }

    /// <summary>
    /// se vuoi modificare la sequenza delle scene, qui è dove andiamo forzatamente alla scena dei cubi dalla scena 
    /// </summary>
    private void OnEnter()
    {
        switch (targetScene)
        {
            case "cubi":
                sceneCtrl.ToCubeScene();
                break;
            case "sfere":
                sceneCtrl.ToSphereScene();
                break;
            default:
                sceneCtrl.ToMenu();
                break;
        }
    }

    private void OnDestroy()
    {
        eventHandler.OnEnter.RemoveListener(OnEnter);
    }
}
