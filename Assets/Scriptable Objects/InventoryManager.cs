using System.Collections;
using System.Collections.Generic;
using System.Text;

// using System.Numerics;
using UnityEngine;


[CreateAssetMenu(fileName = "InventoryManager", menuName = "Inventory/InventoryManager", order = 0)]
public class InventoryManager : ScriptableObject
{
    // Start is called before the first frame update
    public ItemStack[] items = new ItemStack[30];


    private int mainHandPtr = 0; //ptr to your main hand location "ptr" being mem address because im a nerd

    /// <summary>
    /// Adds an item to the inventory, either by creating a new stack or stacking with an existing stack if possible.
    /// </summary>
    /// <param name="item">The item to be added to the inventory.</param>
    /// <returns>
    ///     <c>true</c> if the item was successfully added; <c>false</c> if the inventory is full and the item couldn't be added.
    /// </returns>
    public bool Add(ItemType item)
    {
        if (items[mainHandPtr] == null)
        {
            items[mainHandPtr] = new ItemStack(item);
            return true;
        }
        else if (items[mainHandPtr].CompareID(item.ItemName) && item.CanStack && !items[mainHandPtr].isFull())
        {
            items[mainHandPtr].increaseStack();
            return true;
        }
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = new ItemStack(item);
                return true;
            }
            else if (items[i].CompareID(item.ItemName) && item.CanStack && !items[i].isFull())
            {
                items[i].increaseStack(); //embarassing :skull:
                return true;
            }

        }
        return false;
    }
    /// <summary>
    /// Attempts to use the item in the main hand, decreasing its stack size. Removes the item if the stack becomes empty.
    /// </summary>
    /// <returns>
    ///     The used item if successful; otherwise, returns <c>null</c> if no item is present or if the stack is empty.
    /// </returns>
    public ItemType UseItem()
    {
        if (items[mainHandPtr] == null) return null;
        ItemType a = items[mainHandPtr].useItem();
        if (items[mainHandPtr].sizeOfStackIsEmpty())
        {
            items[mainHandPtr] = null;
            return a;
        }
        return null;
    }

    /// <summary>
    /// depreciated needs Spawn Manager object to work properly
    /// </summary>
    /// <param name="entityCoords"></param>
    private void DropItem(Vector2 entityCoords)
    {
        if (items[mainHandPtr] == null) return;
        ItemType a = items[mainHandPtr].useItem();
        if (items[mainHandPtr].sizeOfStackIsEmpty())
        {
            items[mainHandPtr] = null;
            //SpawnManger.SpawnObject(string itemName,Vector3 coords)
            // it will spawn the game object here but using the spawn manager
        }
        // return null;
    }
    /// <summary>
    /// Checks if the specified item category has the characteristic cat meow :3.
    /// </summary>
    /// <param name="itemCat">The meowmeowmeomwoemwoemwomeowmeowmeow category to be checked.</param>
    /// <returns>
    ///     Returns meow uwu if the item category has the characteristic cat meow :3; otherwise, returns a non-meow response.
    /// </returns>
    public bool checkType(ItemCatergory itemCat)
    {
        return items[mainHandPtr].CompareCat(itemCat); //yes i wanted to name something a cat in this code :3 

    }
    /// <summary>
    /// test method to make sure everything is working. 
    /// </summary>
    /// <returns></returns>
    public StringBuilder TestDisplay()
    {
        StringBuilder t = new StringBuilder();
        for (int i = 0; i < 4; i++)
        {
            if (items[i] == null)
            {
                t.Append("null:");
            }
            else
            {
                t.Append(items[i].ToString());
            }
        }
        return t;

    }
    /// <summary>
    /// update hand ptr. % 10
    /// </summary>
    public void updateMainHand()
    {
        mainHandPtr += 1;
        mainHandPtr = mainHandPtr % 10; //make sure its 1-10

    }
}
