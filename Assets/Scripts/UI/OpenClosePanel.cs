using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpenClosePanel : MonoBehaviour
{
    private bool isOpen = false;

    [SerializeField]
    private Vector3 openY;

    [SerializeField]
    private Vector3 closeY;

    [SerializeField]
    private TextMeshProUGUI title;

    [SerializeField]
    private string openTitle;

    [SerializeField]
    private string closeTitle;

    public void OpenClose()
    {
        if (isOpen == false)
        {
            OpenPanel();
            title.SetText(openTitle);
        }
        else
        {
            ClosePanel();
            title.SetText(closeTitle);
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
