using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Paradigm
{
    public class DialogApp : WindowManager
    {
        [SerializeField] private List<WindowControll> listActiveWindow = new List<WindowControll>();

        public override void CellWindow(WindowControll.TTypeWindow _TypeWindow, bool State = false)
        {
            if(PriotiryWindow(_TypeWindow) == WindowControll.TTypePriority.Singleton)
            {
                for (int i = listActiveWindow.Count - 1; i >= 0; i--)
                {
                    if (listActiveWindow[i].TypePriority == WindowControll.TTypePriority.Singleton)
                    {
                        DestroyWindow(listActiveWindow[i]);
                        listActiveWindow.RemoveAt(i);
                    }
                }

                SpawnWindow(_TypeWindow);
                return;
            }
            else
            {
                for (int i = listActiveWindow.Count - 1; i >= 0; i--)
                {
                    if (listActiveWindow[i].TypeWindow == _TypeWindow)
                    {
                        DestroyWindow(listActiveWindow[i]);
                        listActiveWindow.RemoveAt(i);
                    }
                }

                SpawnWindow(_TypeWindow);
                return;
            }

            base.CellWindow(_TypeWindow, State);
        }

        public void DisableAll(WindowControll.TTypePriority priority)
        {
            for (int i = listActiveWindow.Count - 1; i >= 0; i--)
            {
                if (listActiveWindow[i].TypePriority == priority)
                {
                    DestroyWindow(listActiveWindow[i]);
                    listActiveWindow.RemoveAt(i);
                }
            }
        }

        public void StateRaycast(bool state)
        {
            foreach (WindowControll window in listActiveWindow)
            {
                if (window.GetComponent<GraphicRaycaster>()) { window.GetComponent<GraphicRaycaster>().enabled = state; }
            }
        }

        public override WindowControll GetWindow(WindowControll.TTypeWindow _TypeWindow)
        {
            foreach(WindowControll window in listActiveWindow)
            {
                if(window.TypeWindow == _TypeWindow)
                {
                    return window;
                }
            }

            return base.GetWindow(_TypeWindow);
        }

        private void SpawnWindow(WindowControll.TTypeWindow _TypeWindow)
        {
            GameObject newWindow = Instantiate(GetWindow(_TypeWindow).gameObject);

            WindowControll windowControll = newWindow.GetComponent<WindowControll>();
            windowControll.Initialization();
            windowControll.ShowState(true);

            listActiveWindow.Add(windowControll);
        }

        private void DestroyWindow(WindowControll _window)
        {
            if (_window)
            {
                Destroy(_window.gameObject);
            }
        }
    }
}