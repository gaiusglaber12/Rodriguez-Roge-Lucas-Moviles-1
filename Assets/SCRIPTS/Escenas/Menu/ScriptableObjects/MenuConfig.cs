using UnityEngine;

[CreateAssetMenu(fileName = "MenuConfig", menuName = "ScriptableObjects/MenuConfig", order = 1)]
public class MenuConfig : ScriptableObject
{
    public string id = string.Empty;
    public ButtonModel[] buttonModels = null;
}
