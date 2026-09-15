using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public GameObject UIPrefab;
    private GameObject currentUI;
    
    public void OpenUI(string text)
    {
        if (currentUI)
        {
            Destroy(currentUI);
        }
        currentUI = Instantiate(UIPrefab, transform.position, Quaternion.identity);
        currentUI.GetComponentInChildren<TextMeshProUGUI>().text = text;
    }

    public void CloseUI()
    {
        currentUI.GetComponentInChildren<TextMeshProUGUI>().text = "";
        Destroy(currentUI);
        currentUI = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            OpenUI("Test me");
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            CloseUI();
        }
    }
}
