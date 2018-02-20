using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Paradigm
{
    public class ButtonUI : CoreUI
    {
        public void OnEnter()
        {
            Sound(CoreSound.TTypeSound.Enter);
        }

        public void OnExit()
        {
            Sound(CoreSound.TTypeSound.Exit);
        }
    }
}