using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClosePanel : MonoBehaviour
{
    private bool isOpen = false;

    [SerializeField]
    private Vector3 openY;

    [SerializeField]
    private Vector3 closeY;


    public void OpenClose()
    {
        if (isOpen == false)
        {
            OpenPanel();
        }
        else
        {
            ClosePanel();
        }

    }

    private void OpenPanel()
    {
        transform.localPosition = openY;
        isOpen = true;
    }

    private void ClosePanel()
    {
        transform.localPosition = closeY;
        isOpen = false;
    }
}
