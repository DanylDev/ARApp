﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Paradigm
{
    public class PlayerControl : MonoBehaviourSingleton<PlayerControl>
    {
        [Header("Ground")]
        public bool initGroud = false;
        private bool groundStart = false;
        public GameObject prefabGround;

        public DesignConstrctor designerContructor;

        public void Inititalization()
        {
            InputManager.Instance.startHold += GroundStart;
            InputManager.Instance.startHold += designerContructor.FixPoint;
            designerContructor.Initialization();
        }

        public void ResetInitialization()
        {
            InputManager.Instance.startHold -= GroundStart;
            InputManager.Instance.startHold -= designerContructor.FixPoint;
        }

        public void CoreUpdate()
        {
            //Как только мы нашли поверхность стартуем игру
            //if(CoreAR.Instance.init)
            //{
            if (designerContructor.fixInit)
            {
                InitGround();
            }
            else
            {
                designerContructor.CoreUpdate();
                designerContructor.PointControl(CoreAR.Instance.hitUpdatePosition);
            }
            //}
        }

        protected void Update()
        {
            CoreUpdate();

            if(Input.GetKeyDown(KeyCode.Space))
            {
                GroundStart();
            }
        }

        private void OnConstructor()
        {

        }

        private void InitGround()
        {
            if (initGroud == true) { return; }

            //cursorEnable = false;
            initGroud = true;

            //CoreAppControl.Instance.DialogApp.CellWindow(WindowControll.TTypeWindow.PreStart);
            GroundStart();
        }

        private void GroundStart()
        {
            if (initGroud == false || groundStart == true) { return; }

            CoreAppControl.Instance.DialogApp.CellWindow(WindowControll.TTypeWindow.Gameplay);

            var getZone = CoreAR.Instance.InstantiateObj(prefabGround);

            //getZone.transform.rotation = hit.Pose.rotation;
            getZone.transform.rotation = Quaternion.Euler(0.0f, getZone.transform.rotation.eulerAngles.y, getZone.transform.rotation.z);

            Vector3 newPos = getZone.transform.position;

            //newPos.x = firstCamera.position.x + (ParadigmControl.Instance.transform.position.x - ParadigmControl.Instance.StartPoint.position.x);
            //newPos.z = firstCamera.position.z + (ParadigmControl.Instance.transform.position.z - ParadigmControl.Instance.StartPoint.position.z);

            newPos.x = designerContructor.midleWorldPoint.x;
            newPos.z = designerContructor.midleWorldPoint.z;

            getZone.transform.position = newPos;

            groundStart = true;
        }
    }
}