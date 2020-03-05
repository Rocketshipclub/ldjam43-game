using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Perk {

    // -1 is negative, 0 is neutral and 1 is positive
    public int value;
    public string positive;
    public string negative;

    public int positiveEffect;
    public int negativeEffect;

    public string descriptionPositive;
    public string descriptionNegative;

    public void Effect(ref int h)
    {
        if (value == 1)
        {
            h += positiveEffect;
        }

        else if (value == -1)
        {
            h += negativeEffect;
        }
    }


    public bool IsPositive()
    {
        if(value == 1)
        {
            return true;
        }

        return false;
    }
    public void Effect(ref int h, Character character)
    {
    }

    public void Effect(ref int h, ref int i, ref int j)
    {
    }
}
