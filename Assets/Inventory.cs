using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory {

    private List<Food> foods = new List<Food>();
    private List<Whiskey> whiskeys = new List<Whiskey>();
    private List<Goods> goods = new List<Goods>();

    public void Add(Item item)
    {
        if(item is Food)
        {
            foods.Add((Food)item);
        }

        else if(item is Whiskey)
        {
            whiskeys.Add((Whiskey)item);
        }

        else if(item is Goods)
        {
            goods.Add((Goods)item);
        }
    }

    public void AddMultiple(Item item, int number)
    {
        if(item is Food)
        {
            for(int i = 0; i < number; i++)
            {
                foods.Add((Food)item);
            }
        }

        else if(item is Whiskey)
        {
            for (int i = 0; i < number; i++)
            {
                whiskeys.Add((Whiskey)item);
            }
        }

        else if(item is Goods)
        {
            for (int i = 0; i < number; i++)
            {
                goods.Add((Goods)item);
            }
        }
    }

    public void RemoveItem(Item item)
    {
        if (item is Food)
        {
            foods.RemoveAt(0);
        }

        else if (item is Whiskey)
        {
            whiskeys.RemoveAt(0);
        }

        else if (item is Goods)
        {
            goods.RemoveAt(0);
        }
    }

    public Food GetFood()
    {
        if(foods.Count > 0)
        {
            return foods[0];
        }

        return null;
    }

    public List<Food> GetAllFood()
    {
        return foods;
    }

    public Whiskey GetWhiskey()
    {
        if (whiskeys.Count > 0)
        {
            return whiskeys[0];
        }

        return null;
    }

    public List<Whiskey> GetAllWhiskey()
    {
        return whiskeys;
    }

    public Goods GetGoods()
    {
        if (goods.Count > 0)
        {
            return goods[0];
        }

        return null;
    }

    public List<Goods> GetAllGoods()
    {
        return goods;
    }

    public int GetNumberOfStored(Item item)
    {
        if (item is Food)
        {
            return foods.Count;
        }

        else if (item is Whiskey)
        {
            return whiskeys.Count;
        }

        else if (item is Goods)
        {
            return goods.Count;
        }

        return 0;
    }
    public int GetInventorySize()
    {
        return foods.Count + whiskeys.Count + goods.Count;
    }
}
