using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BTNS_POSITIONS
{
    LEFT_UP_0,
    LEFT_UP_1,
    LEFT_DOWN_0,
    LEFT_DOWN_1,
    RIGHT_UP_0,
    RIGHT_UP_1,
    RIGHT_DOWN_0,
    RIGHT_DOWN_1,
}
public class MenuController : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private MenuView menuView = null;
    #endregion

    #region CONSTANT_FIELDS
    private const string gameplaySceneName = "conduccion9";
    #endregion

    #region PUBLIC_METHODS
    public void SetMenu(MenuConfig menuConfig, Action<string> onBackPreseed)
    {
        ClearMenu();

        for (int i = 0; i < menuConfig.buttonModels.Length; i++)
        {
            ButtonModel buttonModel = menuConfig.buttonModels[i];
            buttonModel.onPressed = null;
            if (menuConfig.buttonModels[i].menuConfig != null)
            {
                buttonModel.onPressed =
                    (buttonModel) =>
                    {
                        SetMenu(buttonModel.menuConfig, onBackPreseed);
                    };
            }
            else
            {
                Action onChangeScene = null;
                switch (buttonModel.id)
                {
                    case "easy":
                        onChangeScene =
                            () =>
                            {
                                GameDataSingleton.Instance.dificulty = GameDataSingleton.DIFICULTY.EASY;
                                GameDataSingleton.Instance.mode = GameDataSingleton.MODE.SINGLE;
                                GameDataSingleton.Instance.ChangeScene(gameplaySceneName);
                            };
                        break;
                    case "medium":
                        onChangeScene =
                            () =>
                            {
                                GameDataSingleton.Instance.dificulty = GameDataSingleton.DIFICULTY.NORMAL;
                                GameDataSingleton.Instance.mode = GameDataSingleton.MODE.SINGLE;
                                GameDataSingleton.Instance.ChangeScene(gameplaySceneName);
                            };
                        break;
                    case "hard":
                        onChangeScene =
                            () =>
                            {
                                GameDataSingleton.Instance.dificulty = GameDataSingleton.DIFICULTY.HARD;
                                GameDataSingleton.Instance.mode = GameDataSingleton.MODE.SINGLE;
                                GameDataSingleton.Instance.ChangeScene(gameplaySceneName);
                            };
                        break;
                    case "easy_mult":
                        onChangeScene =
                            () =>
                            {
                                GameDataSingleton.Instance.dificulty = GameDataSingleton.DIFICULTY.EASY;
                                GameDataSingleton.Instance.mode = GameDataSingleton.MODE.MULTIPLAYER;
                                GameDataSingleton.Instance.ChangeScene(gameplaySceneName);
                            };
                        break;
                    case "medium_mult":
                        onChangeScene =
                            () =>
                            {
                                GameDataSingleton.Instance.dificulty = GameDataSingleton.DIFICULTY.NORMAL;
                                GameDataSingleton.Instance.mode = GameDataSingleton.MODE.MULTIPLAYER;
                                GameDataSingleton.Instance.ChangeScene(gameplaySceneName);
                            };
                        break;
                    case "hard_mult":
                        onChangeScene =
                            () =>
                            {
                                GameDataSingleton.Instance.dificulty = GameDataSingleton.DIFICULTY.HARD;
                                GameDataSingleton.Instance.mode = GameDataSingleton.MODE.MULTIPLAYER;
                                GameDataSingleton.Instance.ChangeScene(gameplaySceneName);
                            };
                        
                        break;
                    case "back":
                        break;
                    case "exit":
                        buttonModel.onPressed =
                            (buttonModel) =>
                            {
                                onBackPreseed.Invoke(buttonModel.id);
                            };
                        break;
                    case "credits":
                        break;
                    default:
                        break;
                }
                if (onChangeScene != null)
                {
                    buttonModel.onPressed = (buttonModel) => onChangeScene.Invoke();
                }
            }
        }
        menuView.Configure(menuConfig);
    }

    public void ClearMenu()
    {
        menuView.ClearMenu();
    }
#endregion
}
