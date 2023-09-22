using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Jobs;

public class CardFactory : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] protected GameObject[] cardsPrefabs = null;
    #endregion

    #region PROTECTED_FIELDS
    protected List<Card> cards = null;
    #endregion
}

public class MenuCardFactory : CardFactory
{
    #region EXPOSED_FIELDS
    [SerializeField] private Camera mainCamera = null;
    [SerializeField] private Transform holder = null;
    [SerializeField] private Vector2[] initialCardsUIPosiution = null;
    [SerializeField] private Vector2 selectedPosition = Vector2.zero;
    [SerializeField] private Vector2 dissapearPosition = Vector2.zero;
    [SerializeField] private float minYvalue = 0.0f;
    [SerializeField] private float maxYvalue = 0.0f;
    #endregion

    #region PRIVATE_FIELDS
    private MenuCard selectedCard = null;
    private bool selected = false;
    #endregion

    #region UNITY_CALLS
    private void Awake()
    {
        Configure();
    }

    private void Update()
    {
        InitialInteraction();
        DragInteraction();
    }
    #endregion

    #region PUBLIC_METHODS
    public void Configure()
    {
        cards = new List<Card>();
        for (int i = 0; i < initialCardsUIPosiution.Length; i++)
        {
            GameObject go = Instantiate(cardsPrefabs[i], Vector3.zero, Quaternion.identity, holder);
            MenuCard card = go.GetComponent<MenuCard>();
            card.Init();
            card.SetPosition(initialCardsUIPosiution[i]);
            cards.Add(card);
        }
    }
    #endregion

    #region PRIVATE_METHODS
    private bool CheckAABB(Vector2 firstPosition, Vector2 firstWH, Vector2 secondPosition)
    {
        return secondPosition.x > firstPosition.x &&
            secondPosition.x < firstPosition.x + firstWH.x &&
            secondPosition.y < firstPosition.y &&
            secondPosition.y > firstPosition.y + firstWH.y;
    }

    private void InitialInteraction()
    {
        if (!selected)
        {
            PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
            pointerEventData.position = Input.mousePosition;

            List<RaycastResult> racastAllResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerEventData, racastAllResults);

            for (int i = 0; i < racastAllResults.Count; i++)
            {
                MenuCard menuCard = racastAllResults[i].gameObject.GetComponent<MenuCard>();
                if (menuCard != null)
                {
                    if (Input.GetMouseButtonDown(0) && selectedCard != menuCard)
                    {
                        selectedCard = menuCard;
                        selectedCard.SetPosition(selectedPosition);

                        for (int j = 0; j < cards.Count; j++)
                        {
                            if (cards[j].id != selectedCard.id)
                            {
                                MenuCard card = cards[j] as MenuCard;
                                card.SetPosition(card.SpawnPosition);
                            }
                        }
                        selected = true;
                    }
                    else
                    {
                        menuCard.SetScale(menuCard.SelectedScale);
                    }
                }
                else
                {
                    for (int j = 0; j < cards.Count; j++)
                    {
                        MenuCard card = cards[j] as MenuCard;
                        card.SetScale(card.InitialScale);
                    }
                }
            }
        }
    }

    private void DragInteraction()
    {
        if (selectedCard != null && selected)
        {
            PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
            pointerEventData.position = Input.mousePosition;

            List<RaycastResult> racastAllResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerEventData, racastAllResults);

            for (int i = 0; i < racastAllResults.Count; i++)
            {
                MenuCard menuCard = racastAllResults[i].gameObject.GetComponent<MenuCard>();
                if (menuCard != null && menuCard.id == selectedCard.id)
                {
                    if (selectedCard.RectTransform.anchoredPosition.y < maxYvalue)
                    {
                        selectedCard.SetPosition(new Vector3(selectedPosition.x, pointerEventData.position.y, 0));
                    }
                    else
                    {
                        selectedCard.SetPosition(dissapearPosition);
                        selectedCard = null;
                        selected = false;
                        //TOGGLE SCREEN
                    }
                }
            }
        }
    }

    
    #endregion
}
