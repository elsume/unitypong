using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LpaddleController : paddleController
{
    protected override string GetInputAxisName()
    {
        if (!IsSpawned) return "paddleL";
        
        return (OwnerClientId == 0) ? "paddleL" : "paddleR";
    }
}
