using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metabolism : Perk {

    public Metabolism(int value)
    {
        this.value = value;
        negative = "Fast metabolism";
        positive = "Light eater";
        positiveEffect = 1;
        negativeEffect = -2;
        descriptionPositive = string.Format("Feels {0} less hungy than others per turn", positiveEffect);
        descriptionNegative = string.Format("Gets hungry {0} per turn quicker than others", negativeEffect);
    }
}
