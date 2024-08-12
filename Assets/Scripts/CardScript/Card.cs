using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public CardData CardData;
    public CardType CardType;
    public string CardName;   
    public int HP;       // Sức mạnh của thẻ bài
    public int Power; 
    public string DescriptTions;

    public TextMeshProUGUI NameCardText;
    public TextMeshProUGUI HPText;
    public TextMeshProUGUI PowerText;
    public TextMeshProUGUI DeScriptTionText;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Transform originalPosition;
    private Transform currentDropZone = null;
    public GameObject gameObject;


    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = this.transform;
        GetCardInfo();
    }

    private void GetCardInfo()
    {
        CardType = CardData.GetCardType;
        CardName = CardData.GetCardName;
        HP = CardData.GetHP;
        Power = CardData.GetAttackPowerPower;
        DescriptTions = CardData.GetDescriptsTions;

        NameCardText.text = CardName;
        HPText.text = HP.ToString();
        PowerText.text = Power.ToString();
        DeScriptTionText.text = DescriptTions.ToString();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnPointerUp(PointerEventData eventData)
    {

        if (currentDropZone != null)
        {
            List<Transform> slots = new List<Transform>();
            foreach (Transform child in currentDropZone)
            {
                if (child.CompareTag("Slot"))
                {
                    slots.Add(child);
                }
            }

            foreach (Transform slot in slots)
            {
                if (slot.childCount == 0)
                {
                    this.transform.SetParent(slot);
                    this.transform.position = Vector3.zero;
                    return;
                }
            }

            this.transform.position = originalPosition.position;
        }
        else
        {
            this.transform.position = originalPosition.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DropZone"))
        {
            currentDropZone = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("DropZone") && currentDropZone == other.transform)
        {
            currentDropZone = null;
        }
    }
}
