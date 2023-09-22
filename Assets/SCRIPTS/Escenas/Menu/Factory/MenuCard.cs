using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] public string id = string.Empty;
    [SerializeField] protected Sprite sprite = null;
    #endregion

    #region PUBLIC_METHODS
    public virtual void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    public virtual void SetScale(Vector3 scale)
    {
        transform.localScale = scale;
    }
    #endregion
}

public class MenuCard : Card
{
    #region EXPOSED_FIELDS
    [SerializeField] private Vector3 selectedScale = Vector3.one;
    [SerializeField] private MenuConfig menuConfig = null;
    #endregion

    #region PRIVATE_FIELDS
    private RectTransform rectTransform = null;
    private float lerperSpeed = 0.0f;
    private Vector3 initialScale = Vector3.zero;

    private Vector3 destScale = Vector3.zero;
    private Vector2 destPosition = Vector2.zero;
    #endregion

    #region CONSTANT_FIELDS
    private Vector2 spawnPosition = new Vector3(0, -2000, 0);
    #endregion

    #region PROPERTIES
    public RectTransform RectTransform { get { return rectTransform; } }
    public Vector2 SpawnPosition { get { return spawnPosition; } }
    public Vector3 InitialScale { get { return initialScale; } }
    public Vector3 SelectedScale { get { return selectedScale; } }

    public MenuConfig MenuConfig { get => menuConfig; }
    #endregion

    #region UNITY_CALLLS
    private void Update()
    {
        rectTransform.anchoredPosition = Vector3.Lerp(rectTransform.anchoredPosition, destPosition, lerperSpeed);
        //rectTransform.sizeDelta = Vector3.Lerp(rectTransform.sizeDelta, destScale, lerperSpeed);
    }
    #endregion

    #region PUBLIC_METHODS
    public void Init()
    {
        rectTransform = GetComponent<RectTransform>();
        Image image = GetComponent<Image>();
        image.sprite = sprite;
        image.color = Color.white;
        rectTransform.anchoredPosition = spawnPosition;
        lerperSpeed = 0.3f;
    }

    public void SetLerpSpeed(float speed)
    {
        lerperSpeed = speed;
    }

    public override void SetPosition(Vector3 position)
    {
        destPosition = position;
    }

    public override void SetScale(Vector3 scale)
    {
        //destScale = scale;
    }
    #endregion
}
