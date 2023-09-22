using System;

using UnityEngine;

[Serializable]
public class ButtonModel
{
    public string id;
    public string btnName;
    public BTNS_POSITIONS btnPosition = BTNS_POSITIONS.RIGHT_UP_1;
    public MenuConfig menuConfig = null;
    public Color btnColor = Color.black;
    public Action<ButtonModel> onPressed = null;
}
