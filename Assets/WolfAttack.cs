using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class WolfAttack : Event {

    public WolfAttack()
    {
        description = "Your caravan is attacked by a group of hungry wolves!";
        selectionOneText = "Fight them off!";
        selectionTwoText = "Wait for them to leave..";
    }
    
	public override void Trigger()
    {
        if(selection == 0)
        {
            CalculateFightAgainstWolves();
        }

        else if(selection == 1)
        {
            bool wolvesLeft = CalculateChanceForWolvesToLeave();
            if (wolvesLeft)
            {
                popupText.ShowMessage("The wolves leave and you are free to continue your journey!", "Thank god");
                gc.EndEvent();
            }

            else
            {
                popupText.ShowMessageWithTwoOptions("The wolves are still patrolling outside your caravan!", "Fight", "Wait");
            }
        }
    }

    private bool CalculateChanceForWolvesToLeave()
    {
        if(Random.Range(0.0f, 1.0f) > 0.75f)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    public override void LoadGraphics()
    {
    }

    private void CalculateFightAgainstWolves()
    {
        var caravan = GameObject.Find("Caravan").GetComponent<Caravan>().GetCaravanMembers();
        if (caravan.Count > 0)
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
            popupText.ShowMessage(string.Format("{0} managed to fight off the wolves while remaining unscathed!", fighter.GetName()), "Amazing!");
        }

        else if(value > 0.5f)
        {
            popupText.ShowMessage(string.Format("{0} got slightly injured while fighting off the wolves..", fighter.GetName()), "Our hero!");
            fighter.TakeDamage(25);
        }

        else if (value > 0.35f)
        {
            popupText.ShowMessage(string.Format("{0} sustained severe injuries while fighting off the wolves", fighter.GetName()), "Our hero!");
            fighter.TakeDamage(75);
        }

        else
        {
            fighter.Kill("wolves");
        }

        gc.EndEvent();
    }
}
