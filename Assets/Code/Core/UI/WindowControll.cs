using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Paradigm
{
    public abstract class WindowControll : CoreUI
    {
        #region Data

        public enum TTypeWindow
        {
            MainMenu,
            ShopSkin,
            ShopHome,
            Gameplay,
            Pause,
            PreEnd,
            End,
            SplashLoad,
            Settings,
            BuySkin,
            Manual,
            Bank,
            Skills,
            ARLoading,
            PreStart
        }

        public enum TTypePriority
        {
            Singleton,
            Multiple
        }

        [Header("Data Window")]
        public TTypeWindow TypeWindow;
        public TTypePriority TypePriority;
        public bool InitState = false;
        public bool findCameraToCanvas = false;

        public GameObject Main { get; private set; }
        public Canvas canvas { get; private set; }
        public Animator animControl { get; private set; }

        #endregion

        #region Core

        public virtual void Initialization()
        {
            Main = gameObject;
            canvas = GetComponent<Canvas>();
            animControl = GetComponent<Animator>();

            if (findCameraToCanvas && canvas)
            {
                canvas.worldCamera = Camera.main;
                canvas.planeDistance = 1;
            }
        }

        public virtual void CoreUpdate()
        {

        }

        public virtual void ShowState(bool state)
        {
            if (animControl)
            {
                if(state)
                {
                    SetActive(Main, true);
                }
                else if(!state && Main.activeSelf)
                {
                    StartCoroutine(DelayClose(state, animControl.GetCurrentAnimatorStateInfo(0).length));
                }

                animControl.SetBool("Enable", state);
            }
            else
            {
                SetActive(Main, state);
                print("state active " + state);
            }
        }

        public virtual bool GetState()
        {
            if (animControl)
            {
                return animControl.GetBool("Enable");
            }
            else
            {
                return Main.activeSelf;
            }
        }

        public virtual void Open()
        {

        }

        public virtual void Close()
        {

        }

        public IEnumerator DelayClose(bool state, float time)
        {
            yield return new WaitForSeconds(time);

            SetActive(Main, state);
        }

        #endregion
    }
}