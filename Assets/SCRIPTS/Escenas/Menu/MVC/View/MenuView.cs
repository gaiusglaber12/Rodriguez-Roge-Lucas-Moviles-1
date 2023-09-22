using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuView : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private ButtonView[] buttonViews = null;
    #endregion

    #region PUBLIC_METHODS
    public void Configure(MenuConfig menuConfig)
    {
        foreach (var view in buttonViews)
        {
            foreach (var btnConfig in menuConfig.buttonModels)
            {
                if (btnConfig.btnPosition == view.BtnPoisition)
                {
                    view.Configure(btnConfig, btnConfig.onPressed);
                    view.ToggleImg(true);
                }
            }
        }
    }

    public void ClearMenu()
    {
        foreach (var view in buttonViews)
        {
            view.Configure(null, null);
            view.RemoveListeners();
            view.ToggleImg(false);
        }
    }
    #endregion
}
