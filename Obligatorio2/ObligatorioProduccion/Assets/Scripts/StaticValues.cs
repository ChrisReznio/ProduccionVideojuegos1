using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticValues 
{
    private static int actualLife = 50;

    public static int ActualLife
    {
        get
        {
            return actualLife;
        }
        set
        {
            actualLife = value;
        }
    }
}
