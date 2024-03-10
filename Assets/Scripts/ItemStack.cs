using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class ItemStack
{
    // Start is called before the first frame update
    private int sizeOfStack;
    private ItemType item;
    public ItemStack(ItemType item)
    {
        this.item = item;
        sizeOfStack = 1;
    }
    public void increaseStack()
    {
        if (!item.CanStack || isFull()) return;
        sizeOfStack++;

    }
    public ItemType useItem()   
    {
        if (item.CanStack)
            sizeOfStack--;
        if (sizeOfStack < 0)
        {
            sizeOfStack = 0;
            return null;
        }
        return item;
    }
    public bool sizeOfStackIsEmpty()
    {
        return sizeOfStack == 0;
    }
    public ItemType DropItem()
    {
        sizeOfStack--;
        return item;
    }
    public bool CompareID(string id)
    {
        return id == item.ItemName;
    }
    public bool CompareCat(ItemCatergory itemCat)

    {
        return item.itemCatergory == itemCat; //meow :3c
    }
    public bool isFull()
    {
        return sizeOfStack > 10;
    }
    public override string ToString()
    {
        return item.ItemName + ": " + sizeOfStack;
    }

    public ItemType GetItem()
    {
        return item;
    }
}
