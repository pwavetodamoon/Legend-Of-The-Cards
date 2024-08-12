using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
[CreateAssetMenu(fileName = "NewPlayerData", menuName = "ScriptableObjects/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    public string playerName;           // Tên người chơi
    public int level;                   // Level của người chơi
    public List<Card> cardList;         // Danh sách thẻ bài mà người chơi đang sở hữu

    // Property cho playerName
    public string PlayerName
    {
        get { return playerName; }
        set { playerName = value; }
    }

    // Property cho level
    public int Level
    {
        get { return level; }
        set { level = value; }
    }
    
    public void AddCard(Card newCard)
    {
        cardList.Add(newCard);
    }
    public int GetCardCount()
    {
        return cardList.Count;
    }
}
