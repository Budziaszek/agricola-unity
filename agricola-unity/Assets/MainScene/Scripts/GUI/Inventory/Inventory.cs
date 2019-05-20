﻿using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    public Image[] itemImages = new Image[numItemSlots];
    public Image[] quantityBackgrounds = new Image[numItemSlots];
    public Item[] items = new Item[numItemSlots];
    public Text[] quantities = new Text[numItemSlots];
    public ItemType[] types = new ItemType[numItemSlots];

    public const int numItemSlots = 6;

    public void AddItem(ItemType type, int quantityToAdd = 1)
    {
        int i = 0;
        for (; i < items.Length; i++)
        {
            if (items[i] != null)
            {
                if (items[i].type == type)
                {
                    items[i].quantity+= quantityToAdd;
                    quantities[i].text = items[i].quantity.ToString();
                    return;
                }
            }
        }
        types[i] = type;
        items[i] = new Item(type, quantityToAdd);
        itemImages[i].sprite = Resources.Load<Sprite>(type.directory);
        itemImages[i].enabled = true;
        quantityBackgrounds[i].enabled = true;
        quantities[i].text = items[i].quantity.ToString();
        return; 
    }
    public void RemoveItem(ItemType type, int quantityToRemove = 1)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] != null && items[i].type == type)
            {
                if (items[i].quantity > quantityToRemove)
                {
                    items[i].quantity -= quantityToRemove;
                    quantities[i].text = items[i].quantity.ToString();
                    return;
                }
                else
                {
                    types[i] = null;
                    items[i] = null;
                    itemImages[i].sprite = null;
                    itemImages[i].enabled = false;
                    quantityBackgrounds[i].enabled = false;
                    quantities[i].text = "";
                    return;
                }
            }
        }
    }
    public void RemoveItem(string name, int quantityToRemove = 1)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] != null && items[i].type.name == name)
            {
                if (items[i].quantity > quantityToRemove)
                {
                    items[i].quantity -= quantityToRemove;
                    quantities[i].text = items[i].quantity.ToString();
                    return;
                }
                else
                {
                    types[i] = null;
                    items[i] = null;
                    itemImages[i].sprite = null;
                    itemImages[i].enabled = false;
                    quantityBackgrounds[i].enabled = false;
                    quantities[i].text = "";
                    return;
                }
            }
        }
    }
    public bool DoesContain(ItemType type)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] != null && items[i].type == type)
            {
                return true;
            }
        }
        return false;
    }
    public bool DoesContain(string name)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] != null && items[i].type.name == name)
            {
                return true;
            }
        }
        return false;
    }


    public int GetInventoryValue()
    {
        int value = 0;
        for(int i = 0; i<items.Length; i++)
        {
            if(items[i] != null)
            {
                int itemQuantity = items[i].quantity;
                int itemPrice = types[i].priceSell;
                value += itemPrice * itemQuantity;
            }
        }

        return value;
    }
}