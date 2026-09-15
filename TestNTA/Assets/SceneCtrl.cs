using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
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

    public void CaricaGioco()
        {
            SceneManager.LoadScene(sceneBuildIndex:1);
        }

    public void ChiudiGioco()
        {
            Application.Quit();
        }
}
