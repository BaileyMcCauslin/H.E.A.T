using UnityEngine;

public class UIDirectionControl : MonoBehaviour
{
    public bool m_UseRelativeRotation = true;  


    private Quaternion m_RelativeRotation;     


    private void Start()
    {
        m_RelativeRotation = transform.parent.localRotation;
        // Access the GameObject to which this script is attached
        GameObject myGameObject = gameObject;

        // You can now perform operations on myGameObject
        Debug.Log("This script is attached to: " + myGameObject.name);
    }


    private void Update()
    {
        if (m_UseRelativeRotation)
            transform.rotation = m_RelativeRotation;
    }
}
