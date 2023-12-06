using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenView : MonoBehaviour
{
    [SerializeField] private Image backgroundImg = null;
    [SerializeField] private Image selectCardImg = null;

    public void ToggleScreen(bool toggle)
    {
        backgroundImg.color = new Color(backgroundImg.color.r, backgroundImg.color.g, backgroundImg.color.b, toggle ? 1 : 0);
        selectCardImg.gameObject.SetActive(!toggle);
    }
}
