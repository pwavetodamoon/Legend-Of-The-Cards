
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
[CreateAssetMenu(fileName = "NewCardData", menuName = "ScriptableObjects/CardData", order = 2)]
public class CardData : ScriptableObject
{
    [SerializeField]private CardType _cardType;
    [SerializeField]private string _cardName;
    [SerializeField]private int _hp;
    [SerializeField]private string DescriptTions;
    [FormerlySerializedAs("_attack")] [SerializeField]private int _attackPower;

    // Property cho playerName
    public CardType GetCardType
    {
        get { return _cardType; }
    }
    
    
    public CardType SetCardType
    {
        set { _cardType = value; }
    }
    
    public string GetCardName
    {
        get { return _cardName; }
    }
    
    
    public string SetCardName
    {
        set { _cardName = value; }
    }
    
    public int GetHP
    {
        get { return _hp; }
    }
    
    
    public int SetHP
    {
        set { _hp = value; }
    }
   
    
    public int GetAttackPowerPower
    {
        get { return _attackPower; }
    }
    
    
    public int SetAttackPowerPower
    {
        set { _attackPower = value; }
    }
    public string GetDescriptsTions
    {
        get { return DescriptTions; }
    }
    
    
    public string SetDescriptsTions
    {
        set { DescriptTions = value; }
    }
}
