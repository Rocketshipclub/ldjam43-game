using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diarrhea : Disease {

	public Diarrhea()
    {
        effectOnHealth = 10;
        turnsToLast = 3;
        diseaseName = "diarrhea";
    }
}
