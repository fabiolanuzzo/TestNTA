using System.Collections;
using UnityEngine;

public class TimeHandler : MonoBehaviour
{
    public int initialWait = 60;

    public float showInterval = 30;
    public float closeInterval = 15;
    public float minInterval = 1;

    public UIHandler uiHandler;
    
    public string[] messages = {};
    
    int messageIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(WaitRoutine());
    }

    void Show()
    {
        if (messageIndex >= messages.Length) messageIndex = 0;
        uiHandler.OpenUI(messages[messageIndex++]);
    }

    void Hide()
    {
        uiHandler.CloseUI();
    }

    IEnumerator WaitRoutine()
    {
        yield return new WaitForSeconds(initialWait);
        
        StartCoroutine(ShowRoutine());
    }

    IEnumerator ShowRoutine()
    {
        Show();
        StartCoroutine(CloseRoutine());

        yield return new WaitForSeconds(showInterval);
        
        if (showInterval >= minInterval) showInterval /= 2;
        
        StartCoroutine(ShowRoutine());
    }

    IEnumerator CloseRoutine()
    {
        yield return new WaitForSeconds(closeInterval);
        if (closeInterval >= minInterval / 2) closeInterval /= 2;
        Hide();
    }
}
