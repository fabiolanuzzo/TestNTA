using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCtrl : MonoBehaviour
{
   

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(sceneBuildIndex:0);
            Cursor.lockState = CursorLockMode.None;
        }
        
    }

    public void ToSphereScene()
    {
        SceneManager.LoadScene(sceneBuildIndex:2);
    }

    public void ToCubeScene()
    {
        SceneManager.LoadScene(sceneBuildIndex:1);
    }
    
    public void CaricaGioco()
        {
            SceneManager.LoadScene(sceneBuildIndex:1);
        }

    public void ChiudiGioco()
        {
            Application.Quit();
        }
}
