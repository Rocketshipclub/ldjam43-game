using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flu : Disease, IInfectious {
   
    public Flu()
    {
        effectOnHealth = 5;
        turnsToLast = 3;
        diseaseName = "flu";
    }

    public void Spread()
    {

    }
}
