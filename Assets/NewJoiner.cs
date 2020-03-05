using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class NewJoiner : Event {

    public NewJoiner()
    {
        description = "You see a stranger waving his hand at you!";
        selectionOneText = "Join us friend!";
        selectionTwoText = "Too much mouths to feed already";
    }
	public override void Trigger()
    {
        var caravan = gc.GetCaravan();
        if(selection == 0)
        {
            if(caravan.GetCaravanMembers().Count >= 5)
            {
                popupText.ShowMessage(string.Format("Unfortunately the caravan is full already! You leave the poor fella to freeze in the forest."), "Sorry buddy!");
                gc.EndEvent();
            }
            else
            {
                popupText.ShowMessage("Caravan grew by one!", "Don't get too excited friend..");
                caravan.AddCaravanMember();
                gc.EndEvent();
            }
        }

        else if(selection == 1)
        {
            popupText.ShowMessage("You leave the poor fella to freeze in the forest.", "Bye bye!");
            gc.EndEvent();
        }
    }

    public override void LoadGraphics()
    {
        
    }


}
