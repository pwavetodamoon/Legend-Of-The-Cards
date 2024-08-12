using System.Collections.Generic;
using UnityEngine;

public class CardInHandController : MonoBehaviour
{
    public List<GameObject> CardInHands = new List<GameObject>();
    public GameObject Slot;
    public GameObject Container;

    private void Start()
    {
        CreateSlotByIndex(6);
    }

    public void CreateSlotByIndex(int index)
    {
        for (int i = 0; i <= index - 1; i++)
        {
            Instantiate(Slot.gameObject, Container.transform);
        }
    }
    public void AddCard(GameObject newCard)
    {
        if (newCard != null)
        {
            CardInHands.Add(newCard);
            Debug.Log("Card added to hand.");
        }
        else
        {
            Debug.LogWarning("Attempted to add a null card to hand.");
        }
    }
    
    public void RemoveCard(GameObject cardToRemove)
    {
        if (CardInHands.Contains(cardToRemove))
        {
            CardInHands.Remove(cardToRemove);
            Debug.Log("Card removed from hand.");
        }
        else
        {
            Debug.LogWarning("Attempted to remove a card that is not in the hand.");
        }
    }
    public void SortCardsByType()
    {
        CardInHands.Sort((card1, card2) => 
        {
            var card1Type = card1.GetComponent<Card>().CardType;
            var card2Type = card2.GetComponent<Card>().CardType;
            return card1Type.CompareTo(card2Type);  // So sánh theo giá trị enum
        });
    }
    
}
