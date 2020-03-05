using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pneumonia : Disease, IInfectious {

    public Pneumonia()
    {
        effectOnHealth = 20;
        turnsToLast = 4;
        diseaseName = "pneumonia";
    }

    public void Spread()
    {

    }
}
