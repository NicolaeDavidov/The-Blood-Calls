﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    public class CameraFacing : MonoBehaviour
    {
        Canvas canvas;

        // Update is called once per frame
        void Update()
        {
            transform.forward = Camera.main.transform.forward;
        }
    }
}
