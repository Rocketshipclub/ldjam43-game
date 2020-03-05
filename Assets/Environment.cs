using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment {

    [SerializeField]
    private int temperature;
    private bool isWindy;
    private bool isRaining;

    private int warmthReductionOfWind = 5;
    private int warmthReductionOfRain = 3;
    private int warmthReductionWhenFreezing = 6;
    private int warmthReductionWhenCool = 3;
    private int minTemperature = -10;
    private int maxTemperature = 20;

    public Environment()
    {
        temperature = Random.Range(minTemperature, maxTemperature);
    }

    public int GetWeatherEffectOnWarmth()
    {
        int reduction = 0;

        if (isRaining) { reduction += warmthReductionOfRain; }
        if (isWindy) { reduction += warmthReductionOfWind; }

        if(temperature < -15) { reduction += warmthReductionWhenFreezing; }
        else if(temperature >= -15 && temperature < 0) { reduction += warmthReductionWhenCool; }

        return reduction;
    }

    public int GetTemperature()
    {
        return temperature;
    }
}
