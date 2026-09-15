using UnityEngine;

public class ShapeChanger : MonoBehaviour
{
    public GameObject sphereGameObject;
    public int defaultShape = 0;
    
    /// <summary>
    /// quando newShape è 1 attiva la sfera, altrimenti resta disabilitata
    /// </summary>
    /// <param name="newShape"></param>
    public void ChangeShape(int newShape)
    {
        sphereGameObject.SetActive(newShape == 1);
    }

    void Start()
    {
        ChangeShape(defaultShape);
    }
}
