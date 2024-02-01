using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public void Open()
    {
        GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
    }
    public void Hide()
    {
        GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 2000, 0);
        Time.timeScale = 1;
    }
}
