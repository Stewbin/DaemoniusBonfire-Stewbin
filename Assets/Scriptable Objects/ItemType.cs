using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "ItemType", menuName = "Spawnable Objects/Items", order = 0)]
public class ItemType : ScriptableObject
{
    public string ItemName; //name of item (can be useful if we assign "jump boost")
    public int HealthDamageIncrease; //every item will have a set "Health/Dama increase"
    public bool CanStack;
    public ItemCatergory itemCatergory; //what catergory it is (either Sword or Power up)
    public Sprite sprite;
}

public enum ItemCatergory
{
    SWORD,
    POWERUP,

}