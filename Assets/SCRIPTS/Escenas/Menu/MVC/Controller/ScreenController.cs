using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenController : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private Image backgroundImg = null;
    [SerializeField] private MenuCardFactory menuCardFactory = null;
    [SerializeField] private ScreenView screenView = null;
    [SerializeField] private MenuController menuController = null;
    #endregion

    #region PRIVATE_FIELDS
    private MenuConfig selectedMenuConfig = null;
    #endregion

    #region PUBLIC_METHODS
    public void Init(ScreenModel screenModel)
    {
        screenView.ToggleScreen(true);
        selectedMenuConfig = screenModel.menuConfig;
    }

    public void ToggleMenu(bool toggle)
    {
        if (!toggle)
        {
            menuCardFactory.Configure();
            menuController.ClearMenu();
        }
        else
        {
            menuController.SetMenu(selectedMenuConfig,
                onBackPreseed: (btnPressed) =>
                {
                    if (btnPressed == "exit")
                    {
                        ToggleMenu(false);
                    }
                });
        }
        screenView.ToggleScreen(toggle);
    }
    #endregion
}