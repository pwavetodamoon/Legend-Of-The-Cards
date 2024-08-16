using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
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
    private Vector3 originalPosition;
    public Transform currentDropZone = null;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = this.transform.position;
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
        // Lưu lại vị trí ban đầu của thẻ bài
        originalPosition = rectTransform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("pointer up");

        // Kiểm tra nếu thẻ bài được thả vào vùng DropZone
        if (currentDropZone != null)
        {
            rectTransform.position = currentDropZone.position;
            Debug.Log("Thả vào DropZone: " + currentDropZone.name);
        }
        else
        {
            // Trả lại vị trí ban đầu nếu không thả vào vùng DropZone
            rectTransform.position = originalPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra nếu collider của thẻ bài chạm vào một đối tượng có tag "DropZone"
        Debug.Log("OnTriggerEnter2D");
        if (collision.CompareTag("DropZone"))
        {
            currentDropZone = collision.transform;
            Debug.Log("On Drop ZOne");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("OnTriggerExit2D");

        // Khi rời khỏi vùng DropZone, hủy tham chiếu đến nó
        if (collision.CompareTag("DropZone"))
        {
            currentDropZone = null;
        }
    }
}
