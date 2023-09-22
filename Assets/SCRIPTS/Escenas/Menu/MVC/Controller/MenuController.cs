using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private Image backgroundImg = null;
    [SerializeField] private MenuCardFactory menuCardFactory = null;
    #endregion

    #region PUBLIC_METHODS
    public void Init(MenuModel menuModel)
    {

    }

    public void ToggleMenu(bool toggle, Action onSuccess)
    {
        if (toggle)
        {

        }
        else
        {
            menuCardFactory.Configure();
        }
    }
    #endregion
}
