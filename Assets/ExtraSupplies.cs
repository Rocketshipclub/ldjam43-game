using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ExtraSupplies : Event {

    public ExtraSupplies()
    {
        description = "You see an abandoned caravan cart buried in snow";
        selectionOneText = "Dig it up!";
        selectionTwoText = "We have enough supplies already";
    }
	public override void Trigger()
    {
        var caravan = gc.GetCaravan();
        if(selection == 0)
        {
            var foodFound = Random.Range(1, 8);
            var goodsFound = Random.Range(0, 10);
            var whiskeyFound = Random.Range(0, 4);
            foreach (Character character in caravan.GetCaravanMembers())
            {
                character.ReduceWarmth(20);
            }
            caravan.OpenInventory().AddMultiple(new Food(), foodFound);
            caravan.OpenInventory().AddMultiple(new Whiskey(), whiskeyFound);
            caravan.OpenInventory().AddMultiple(new Goods(), goodsFound);

            popupText.ShowMessage(string.Format("{0} food found, {2} whiskey found, {1} goods found!", foodFound, goodsFound, whiskeyFound), "Something positive for change");
            gc.EndEvent();
        }

        else if(selection == 1)
        {
            popupText.ShowMessage("You decide to leave the cart alone, it's not worth the effort.", "Let's just get to somewhere warm");
            gc.EndEvent();
        }
    }

    public override void LoadGraphics()
    {
    }

}
