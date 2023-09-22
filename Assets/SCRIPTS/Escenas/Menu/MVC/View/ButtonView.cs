using System;

using UnityEngine;
using UnityEngine.UI;

public class ButtonView : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private BTNS_POSITIONS btnPoisition = BTNS_POSITIONS.RIGHT_DOWN_1;
    [SerializeField] private Button btn = null;
    [SerializeField] private GameObject img = null;
    [SerializeField] private TMPro.TMP_Text tmp;
    #endregion

    #region PRIVATE_FIELDS
    private string id = string.Empty;
    #endregion


    #region PROPERTIES
    public BTNS_POSITIONS BtnPoisition { get => btnPoisition; set => btnPoisition = value; }
    #endregion

    #region PUBLIC_METHODS
    public void Configure(ButtonModel btnModel, Action<ButtonModel> onPressed)
    {
        btn.onClick.AddListener(() => onPressed?.Invoke(btnModel));
        tmp.text = btnModel == null ? string.Empty : btnModel.btnName;
        tmp.color = btnModel == null ? Color.black : btnModel.btnColor;
    }

    public void RemoveListeners()
    {
        btn.onClick.RemoveAllListeners();
    }

    public void ToggleImg(bool toggle)
    {
        img.SetActive(toggle);
    }
    #endregion
}
