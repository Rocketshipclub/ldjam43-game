using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : Item {

    public int saleValue = 5;
    int warmthRecovery = 10;
    public override void Use(Character user)
    {
        user.RecoverWarmth(warmthRecovery);
    }

}
