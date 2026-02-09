using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RpaddleController : paddleController
{
    protected override string GetInputAxisName()
    {
        return "paddleR";
    }
}
