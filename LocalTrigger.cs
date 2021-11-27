﻿/*
 * Copyright 2021 AlexOttr <alex@ottr.one>
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the
 * "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, 
 * distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to 
 * the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF 
 * MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY 
 * CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE 
 * SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

using UdonSharp;
using UnityEngine;

namespace OttrOne.UdonToolbox
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class LocalTrigger : UdonSharpBehaviour
    {
        public GameObject[] Targets;

        /// <summary>
        /// React to interaction events on the parent gameobject
        /// </summary>
        public override void Interact()
        {
            this._toggle();
        }

        /// <summary>
        /// Exposed event to toggle all known gameobjects
        /// </summary>
        public void Toggle() { this._toggle(); }

        /// <summary>
        /// Exposed event to turn all known gameobjects on
        /// </summary>
        public void TurnOn()
        {
            foreach (GameObject target in Targets)
            {
                target.SetActive(true);
            }
        }

        /// <summary>
        /// Exposed event to turn all known gameobjects off
        /// </summary>
        public void TurnOff()
        {
            foreach (GameObject target in Targets)
            {
                target.SetActive(false);
            }
        }

        private void _toggle()
        {
            foreach (GameObject target in Targets)
            {
                target.SetActive(!target.activeSelf);
            }
        }
    }
}