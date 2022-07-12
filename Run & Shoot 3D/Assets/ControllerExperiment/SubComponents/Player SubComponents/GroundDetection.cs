﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ControllerExperiment.Keys.Player;

namespace ControllerExperiment.SubComponents.Player
{
    public class GroundDetection : BaseSubComponent
    {
        [Header("Ground Detection Debug")]
        [SerializeField] bool mIsGrounded;

        private void Start()
        {
            subComponentProcessor.DelegateGetBool(PlayerBool.IS_GROUNDED, IsGrounded);
            subComponentProcessor.DelegateSetBool(PlayerBool.IS_GROUNDED, SetGroundStatus);
        }

        void SetGroundStatus(bool b)
        {
            mIsGrounded = b;
        }

        bool IsGrounded()
        {
            return mIsGrounded;
        }
    }
}