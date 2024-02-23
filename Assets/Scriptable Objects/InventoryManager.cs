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
	public int mainHandPtr = 0;
	public void Awake()
	{
		// items = new ItemStack[30];
	}
	/// <summary>
	/// adds on list 
	/// </summary>
	///
	/// <param name="item"></param>
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
				items[i] = new ItemStack(item);
				return true;
			}

		}
		return false;
	}
	/// <summary>
	/// uses item in main hand
	/// </summary>
	/// <returns>null if it doesnt exist or the item type if it can </returns>
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
	public StringBuilder TestDisplay()
	{
		StringBuilder t = new StringBuilder();
		for (int i = 0; i < 10; i++)
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
}
