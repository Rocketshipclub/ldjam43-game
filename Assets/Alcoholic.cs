using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alcoholic : Perk {

    public Alcoholic(int value)
    {
        this.value = value;
        positive = "Alcoholic";
        negative = "Flyweight";
        positiveEffect = 5;
        negativeEffect = -5;
        descriptionPositive = string.Format("Drinking replenishes {0} hunger along with warmth", positiveEffect);
        descriptionNegative = string.Format("Drinking does {0} damage to health", negativeEffect);
    }

    public new void Effect(ref int h, ref int i, ref int j)
    {
        if (value == 1)
        {
            h += positiveEffect;
            j += positiveEffect;
        }

        else if (value == -1)
        {
            i += negativeEffect;
        }
    }
}
