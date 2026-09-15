using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCtrl : MonoBehaviour
{
    private static readonly int Exposure = Shader.PropertyToID("_Exposure");

    public Material skyboxMaterial;

    public float exposureSettingInterval = 2f;
    public float minExposure = 1f;
    public float maxExposure = 4f;

    private static SceneCtrl _instance = null;

    public static SceneCtrl instance => _instance;
    
    public void Awake()
    {
        if (_instance)
        {
            Destroy(gameObject);
            return;
        }
        
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(sceneBuildIndex:0);
            Cursor.lockState = CursorLockMode.None;
        }
        
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
        Cursor.lockState = CursorLockMode.None;
    }

    public void ToSphereScene()
    {
        StartCoroutine(GoingToScene(2));
    }

    IEnumerator GoingToScene(int sceneBuildIndex = 1)
    {
        StartCoroutine(SettingExposure(true));
        yield return new WaitForSeconds(exposureSettingInterval);
        SceneManager.LoadScene(sceneBuildIndex);
        StartCoroutine(SettingExposure(false));
    }
    
    public void ToCubeScene()
    {
        StartCoroutine(GoingToScene(1));
    }
    
    public void CaricaGioco()
    {
        SceneManager.LoadScene(sceneBuildIndex:1);
        //ToCubeScene(); // funziona ma bisogna gestire il fatto che aspetta exposureSettingInterval secondi prima di aprire la scene
    }

    public void ChiudiGioco()
    {
        Application.Quit();
    }

  

    IEnumerator SettingExposure(bool toFadeOut)
    {
        var startTime = Time.time;
        var minExp = toFadeOut? minExposure : maxExposure;
        var maxExp = toFadeOut? maxExposure : minExposure;

        while (startTime + exposureSettingInterval >= Time.time)
        {
            var currentPercentage = (Time.time - startTime) / exposureSettingInterval;
            var t = Mathf.InverseLerp(0, 1, currentPercentage);
            var output = Mathf.Lerp(minExp, maxExp, t);
            skyboxMaterial.SetFloat(Exposure, output);
            yield return null;
        }
    }
}
