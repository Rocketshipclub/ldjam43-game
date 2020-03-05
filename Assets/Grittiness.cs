using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grittiness : Perk {

	public Grittiness(int value)
    {
        this.value = value;
        positive = "Food lover";
        negative = "Picky eater";
        positiveEffect = 5;
        negativeEffect = -5;
        descriptionPositive = string.Format("Eating replenishes {0} more hunger", positiveEffect);
        descriptionNegative = string.Format("Eating replenishes {0} less hunger", negativeEffect);
    }
}
