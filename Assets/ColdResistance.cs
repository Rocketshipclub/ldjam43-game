using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColdResistance : Perk {

    public ColdResistance(int value)
    {
        this.value = value;
        positive = "Cold-blooded";
        negative = "Southerner";
        positiveEffect = 2;
        negativeEffect = -2;
        descriptionPositive = string.Format("Resists {0} loss of warmth per turn", positiveEffect);
        descriptionNegative = string.Format("Warmth goes down extra {0} per turn", negativeEffect);
    }

    public new void Effect(ref int h, Character character)
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

}
