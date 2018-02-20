using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Paradigm
{
    public class WindowManager : CoreUI
    {
        #region Data

        [Header("Data")]
        [SerializeField] private List<WindowControll> listWindow;

        public List<WindowControll> ListWindow { get { return listWindow; } }

        #endregion

        protected virtual void Update()
        {
            CoreUpdate();
        }

        #region Core

        public virtual void Initialization()
        {
            foreach (WindowControll Window in ListWindow)
            {
                Window.Initialization();
                Window.ShowState(Window.InitState);
            }
        }

        public virtual void CoreUpdate()
        {
            foreach(WindowControll window in ListWindow)
            {
                if (window.gameObject.activeSelf)
                {
                    window.CoreUpdate();
                }
            }
        }

        public virtual void CellWindow(WindowControll.TTypeWindow _TypeWindow, bool State = false)
        {
            var Priority = GetWindow(_TypeWindow).TypePriority;

            foreach (WindowControll Window in ListWindow)
            {
                if (Window.TypeWindow == _TypeWindow)
                {
                    if (State)
                    {
                        Window.Open();
                    }
                    else
                    {
                        Window.Close();
                    }

                    Window.ShowState(State);
                    DebugLog("Cell window " + Window.name + " " + State, DDebug.TColor.Default);
                }
                else if (Priority == WindowControll.TTypePriority.Singleton)
                {
                    Window.Close();
                    Window.ShowState(false);
                }
            }
        }

        public virtual WindowControll GetWindow(WindowControll.TTypeWindow _TypeWindow)
        {
            foreach (WindowControll Window in ListWindow)
            {
                if (Window.TypeWindow == _TypeWindow)
                {
                    return Window;
                }
            }

            return null;
        }

        public virtual bool GetWindowState(WindowControll.TTypeWindow _TypeWindow)
        {
            foreach (WindowControll Window in ListWindow)
            {
                if (Window.TypeWindow == _TypeWindow)
                {
                    return Window.GetState();
                }
            }

            DebugLog("Window not found", DDebug.TColor.Error);
            return false;
        }

        protected virtual WindowControll.TTypePriority PriotiryWindow(WindowControll.TTypeWindow _TypeWindow)
        {
            foreach(WindowControll window in ListWindow)
            {
                if(window.TypeWindow == _TypeWindow)
                {
                    return window.TypePriority;
                }
            }

            return WindowControll.TTypePriority.Singleton;
        }

        #endregion
    }
}