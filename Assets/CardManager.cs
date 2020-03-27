using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject card;
    public TextManager priceText;
    public TextManager descriptionText;
    public Camera myCamera;

    private int goldPrice;
    private int ropePrice;
    private int steelPrice;
    private int woodPrice;
    private string priceContent;
    private string descriptionContent;
    private Vector3 cachedScale;
    private Vector3 cachedPosition;
    private bool mouseDown = false;

    private GameObject buyZone;
    private GameObject sellZone;

    public void SetPrice(int gold, int rope, int steel, int wood)
    {
        this.goldPrice = gold;
        this.ropePrice = rope;
        this.steelPrice = steel;
        this.woodPrice = wood;
    }

    public void SetDescription(string desc)
    {
        this.descriptionContent = desc;
        this.descriptionText.Write(this.descriptionContent);
    }

    private void BuildCardCanvas()
    {
        return;
        // TODO : Same for image & refacto
    }

    private void WritePriceContent()
    {
        this.priceContent = "Gold: " + this.goldPrice + "\n";
        this.priceContent += "Rope: " + this.ropePrice + "\n";
        this.priceContent += "Steel: " + this.steelPrice + "\n";
        this.priceContent += "Wood: " + this.woodPrice;
        this.priceText.Write(this.priceContent);
    }

    public void EnableCard(GameObject buyZone, GameObject sellZone)
    {
        this.buyZone = buyZone;
        this.sellZone = sellZone;
        this.cachedPosition = this.gameObject.transform.position;
        this.cachedScale = this.gameObject.transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = cachedScale;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        this.mouseDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (this.sellZone.GetComponent<RectTransform>().rect.Contains(this.transform.position))
        {
            print("sell");
        }
        if (this.buyZone.GetComponent<RectTransform>().rect.Contains(this.transform.position))
        {
            print("buy");
        }
        this.mouseDown = false;
        transform.position = cachedPosition;
    }

    void Update()
    {
        if (mouseDown)
        {
            Vector3 currentPos = Input.mousePosition;
            currentPos.z = 9f;
            transform.position = this.myCamera.ScreenToWorldPoint(currentPos);

        }
    }
}
