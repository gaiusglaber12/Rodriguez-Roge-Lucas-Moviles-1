using System.Linq;
using UnityEngine;

public class MenuView : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private TMPro.TMP_Text titleTxt = null;
    [SerializeField] private ButtonView[] buttonViews = null;
    #endregion

    #region PUBLIC_METHODS
    public void Configure(MenuConfig menuConfig)
    {
        foreach (var view in buttonViews)
        {
            foreach (var btnConfig in menuConfig.buttonModels)
            {
#if UNITY_ANDROID
                if (btnConfig.btnPosition == view.BtnPoisition && !btnConfig.id.Contains("coop"))
                {
                    view.Configure(btnConfig, btnConfig.onPressed);
                    view.ToggleImg(true);
                }
#else
                if (btnConfig.btnPosition == view.BtnPoisition)
                {
                    view.Configure(btnConfig, btnConfig.onPressed);
                    view.ToggleImg(true);
                }
#endif
            }
        }
        if (menuConfig.mainText != string.Empty)
        {
            titleTxt.text = menuConfig.mainText;
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
        titleTxt.text = string.Empty;
    }
    #endregion
}
