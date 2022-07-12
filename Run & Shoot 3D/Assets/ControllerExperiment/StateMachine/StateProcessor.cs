﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ControllerExperiment
{
    public enum StateProcessorType
    {
        NONE,
        
        PLAYER_PHYSICS,

        RAGDOLL_ANIMATION,
        RAGDOLL_TRANSFORM,

        PLAYER_RENDER,
    }
}

namespace ControllerExperiment.States
{
    public class StateProcessor : MonoBehaviour
    {
        [Header("State Processor Attributes")]
        public StateProcessorType m_StateType;

        [Header("State Processor Debug")]
        public List<BaseState> AllStates = new List<BaseState>();
        [Space(10)]
        public BaseState Current = null;

        private ControllerEntity m_owner;

        public ControllerEntity owner
        {
            get
            {
                if (m_owner == null)
                {
                    m_owner = this.gameObject.GetComponentInParent<ControllerEntity>();
                }
                return m_owner;
            }
        }

        private void Awake()
        {
            AllStates.Clear();
        }

        public void FixedUpdateState()
        {
            Current.ProcStateFixedUpdate();
        }

        public void UpdateState()
        {
            if (Current.Do_UpdateState)
            {
                Current.ProcStateUpdate();
            }
        }

        void InitState(System.Type type)
        {
            Debug.Log("State initialized: " + type.Name);

            BaseState newState = AttachToGameObj(type);

            newState.stateProcessor = this;

            if (!AllStates.Contains(newState))
            {
                AllStates.Add(newState);
            }

            CheckOverride(newState);

            TransitionTo(newState.GetType());
        }

        BaseState AttachToGameObj(System.Type type)
        {
            GameObject obj = new GameObject();
            obj.transform.parent = this.transform;
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;

            obj.name = type.Name;
            obj.AddComponent(type);

            BaseState newState = obj.GetComponent<BaseState>();

            return newState;
        }

        void CheckOverride(BaseState newState)
        {
            System.Type child = newState.GetType();
            newState.Do_OnEnter = OverrideCheck.IsOverridden(child, typeof(BaseState), "OnEnter");
            newState.Do_UpdateState = OverrideCheck.IsOverridden(child, typeof(BaseState), "ProcStateUpdate");
        }

        public void TransitionTo(System.Type type)
        {
            if (!type.IsSubclassOf(typeof(BaseState)))
            {
                Debug.LogError(type.Name + " is not a state");
            }

            //Debug.Log("Attempting transition to " + type.Name + "..");

            BaseState s = GetState(type);

            if (s == null)
            {
                //Debug.Log(type.Name + " is null. Initiating..");
                InitState(type);
            }
            else
            {
                Debug.Log("Transitioned to: " + type.Name);

                Current = s;

                if (Current.Do_OnEnter)
                {
                    Current.OnEnter();
                }
            }
        }

        BaseState GetState(System.Type type)
        {
            foreach(BaseState s in AllStates)
            {
                if (s.GetType() == type)
                {
                    return s;
                }
            }

            return null;
        }
    }
}