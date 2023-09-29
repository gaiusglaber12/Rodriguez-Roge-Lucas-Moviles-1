using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDataSingleton : MonoBehaviour
{
    #region ENUMS
    public enum DIFICULTY
    {
        EASY,
        NORMAL,
        HARD
    }

    public enum MODE
    {
        SINGLE,
        MULTIPLAYER
    }
    #endregion

    #region EXPOSED_FIELDS
    [SerializeField] private Image backgroundImg = null;
    [SerializeField] private float lerperSpeed = 0.1f;
    #endregion

    #region PUBLIC_FIELDS
    public static GameDataSingleton Instance;
    public DIFICULTY dificulty = DIFICULTY.EASY;
    public MODE mode = MODE.MULTIPLAYER;
    #endregion

    #region PRIVATE_FIELDS
    private float currAlphaLerper = 0.0f;
    #endregion

    #region UNITY_CALLS
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
    }

    private void Update()
    {
        backgroundImg.color = new Color(backgroundImg.color.r, backgroundImg.color.g, backgroundImg.color.b, Mathf.Lerp(backgroundImg.color.a, currAlphaLerper, lerperSpeed));
    }
    #endregion

    #region PUBLIC_METHODS
    public void ChangeScene(string sceneName)
    {
        StartCoroutine(ChangeSceneAsync(sceneName));
    }
    #endregion

    #region PRIVATE_METHODS
    private IEnumerator ChangeSceneAsync(string sceneName)
    {
        currAlphaLerper = 1;
        while (backgroundImg.color.a < 0.99f)
        {
            yield return new WaitForEndOfFrame();
        }
        var op = SceneManager.LoadSceneAsync(sceneName);
        while (!op.isDone)
        {
            yield return new WaitForEndOfFrame();
        }
        currAlphaLerper = 0;
    }
    #endregion
}
