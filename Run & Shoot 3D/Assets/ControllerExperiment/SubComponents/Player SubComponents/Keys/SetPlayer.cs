﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ControllerExperiment.Keys.Player
{
    public class SetPlayer : SubComponentKey
    {
        // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members
        public static int SET_WALK_DIRECTION => GetKey("SET_WALK_DIRECTION");
        public static int WALK_TO_TARGET_DIRECTION => GetKey("WALK_TO_TARGET_DIRECTION");
        public static int CANCEL_HORIZONTAL_VELOCITY => GetKey("CANCEL_HORIZONTAL_VELOCITY");
        public static int CANCEL_HORIZONTAL_ANGULAR_VELOCITY => GetKey("CANCEL_HORIZONTAL_ANGULAR_VELOCITY");
        public static int ROTATE_TO_TARGET_ANGLE => GetKey("ROTATE_TO_TARGET_ANGLE");
        public static int ADD_JUMP_FORCE => GetKey("ADD_JUMP_FORCE");
        public static int CANCEL_VERTICAL_VELOCITY => GetKey("CANCEL_VERTICAL_VELOCITY");
        public static int PLAY_ANIMATION_IDLE => GetKey("PLAY_ANIMATION_IDLE");
        public static int PLAY_ANIMATION_WALK => GetKey("PLAY_ANIMATION_WALK");
    }
}