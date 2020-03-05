using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class BanditAttack : Event {

    public GameObject bandits;

    public BanditAttack()
    {
        description = "Your caravan is attacked by bandits!";
        selectionOneText = "Fight them off!";
        selectionTwoText = "Offer them supplies to avoid trouble";
        bandits = GameObject.Find("Bandits");
    }

    public override void LoadGraphics()
    {
        bandits.transform.position = new Vector2(bandits.transform.position.x, -2);
    }
    
	public override void Trigger()
    {
        if (selection == 0)
        {
            CalculateFightAgainstBandits();
        }

        else if(selection == 1)
        {
            var accepted = GetSacrificedGoods();
            if (!accepted)
            {
                popupText.ShowMessage("You have no goods to give to bandits! Prepare for battle!", "Oh dear");
                CalculateFightAgainstBandits();
            }
            else
            {
                popupText.ShowMessage("The bandits leave and you are free to continue your journey!", "Thank god");
                gc.EndEvent();
            }
        }
    }

    private void CalculateFightAgainstBandits()
    {
        var caravan = GameObject.Find("Caravan").GetComponent<Caravan>().GetCaravanMembers();
        if(caravan.Count > 0)
        {
            var g = caravan[Random.Range(0, caravan.Count)];
        }
        else
        {
            Debug.Log("Everyone is dead!");
        }
        var fighter = caravan[Random.Range(0, caravan.Count)];
        float value = Random.Range(0.0f, 1.0f);
        if (value > 0.85f)
        {
            popupText.ShowMessage(string.Format("{0} managed to fight off the bandits while remaining unscathed!", fighter.GetName()), "Amazing!");
            gc.EndEvent();
            bandits.transform.position = new Vector2(bandits.transform.position.x, -100);
        }

        else if(value > 0.5f)
        {
            popupText.ShowMessage(string.Format("{0} got slightly injured while fighting off the bandits..", fighter.GetName()), "Our hero!");
            fighter.TakeDamage(25);
            gc.EndEvent();
            bandits.transform.position = new Vector2(bandits.transform.position.x, -100);
        }

        else if (value > 0.35f)
        {
            popupText.ShowMessage(string.Format("{0} sustained severe injuries while fighting off the bandits", fighter.GetName()), "Our hero!");
            fighter.TakeDamage(75);
            gc.EndEvent();
            bandits.transform.position = new Vector2(bandits.transform.position.x, -100);
        }

        else
        {
            popupText.ShowMessage(string.Format("{0} was slain while fighting off the bandits.", fighter.GetName()), "Tragic..");
            fighter.Kill("bandits");

            popupText.ShowMessageWithTwoOptions("The bandits are still looking to rob your caravan!", "Fight", "Give them some of our goods");
        }
        
    }

    private bool GetSacrificedGoods()
    {
        List<Goods> goods = new List<Goods>();
        var caravan = gc.GetCaravan();

        if (caravan.OpenInventory().GetNumberOfStored(new Goods()) == 0)
        {
            return false;
        }

        else if(goods.Count < 4)
        {
            List<Goods> removable = caravan.OpenInventory().GetAllGoods();

            foreach (Item i in removable)
            {
                caravan.OpenInventory().RemoveItem(i);
            }
        }

        else if(goods.Count > 4)
        {
            for (int i = 0; i < 5; i++)
            {
                caravan.OpenInventory().RemoveItem(new Goods());
            }
        }

        bandits.transform.position = new Vector2(bandits.transform.position.x, -100);
        return true;
    }
}
