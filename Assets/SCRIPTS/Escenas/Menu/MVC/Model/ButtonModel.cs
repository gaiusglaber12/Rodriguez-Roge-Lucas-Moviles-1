using System;

[Serializable]
public class ButtonModel
{
    public string id;
    public string btnName;
    public BTNS_POSITIONS btnPosition = BTNS_POSITIONS.RIGHT_UP_1;
    public MenuConfig menuConfig = null;
    public Action<ButtonModel> onPressed = null;
}
