using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HandManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject buyZone;
    public GameObject sellZone;
    public CardManager[] cards;
    public GameObject cardTemplate;
    public Camera playerCamera;

    private Vector2 defaultSpacing;
    private GridLayoutGroup grid;
    private float defaultYPosition; 

    void Start()
    {
        this.grid = gameObject.GetComponent<GridLayoutGroup>();
        this.defaultSpacing = this.grid.spacing;
        this.defaultYPosition = this.transform.position.y;
        this.SetUpCards();
        this.EnableCards();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.grid.spacing = new Vector2(20f, 0f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.grid.spacing = defaultSpacing;
    }

    private void SetUpCards()
    {
        for (int i=0; i<6; i++)
        {
            GameObject card = Instantiate(cardTemplate, this.gameObject.transform);
            CardManager cardManager = card.GetComponent<CardManager>();
            cardManager.myCamera = this.playerCamera;
            this.cards.SetValue(cardManager, i);
            //card.transform.SetParent(gameObject.transform);
        }
    }

    private void EnableCards()
    {
        foreach (CardManager card in this.cards)
        {
            card.EnableCard(this.buyZone, this.sellZone);
        }
    }
}
