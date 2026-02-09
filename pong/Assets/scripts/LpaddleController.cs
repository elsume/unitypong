using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LpaddleController : paddleController
{
    protected override string GetInputAxisName()
    {
        return "paddleL";
    }
}
