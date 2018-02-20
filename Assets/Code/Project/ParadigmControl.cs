using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Paradigm
{
    public class ParadigmControl : MonoBehaviour
    {
        public static ParadigmControl Instance;

        public enum TState
        {
            Menu,
            Play
        }

        public TState typeState = TState.Menu;
        public List<FinishTrigger> listTriggers = new List<FinishTrigger>();
        public List<TrafficLight> listLight = new List<TrafficLight>();
        public FinishTrigger startGameTrigger;
        public int curCounter = 0;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            CellToPlay();
        }

        private void Update()
        {
            CoreUpdate();

            if (Input.GetKeyDown(KeyCode.G))
            {
                CellToPlay();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                NextTrigger();
            }
        }

        private void CoreUpdate()
        {
            switch(typeState)
            {
                case TState.Menu:
                    break;

                case TState.Play:
                    break;
            }
        }

        public void CellToPlay()
        {
            typeState = TState.Play;
            NextTrigger();
        }

        private void SetTriggres(int index)
        {
            curCounter = index;

            for(int i=0; i<listTriggers.Count; i++)
            {
                if (i == index)
                {
                    listTriggers[i].gameObject.SetActive(true);
                }
                else { listTriggers[i].gameObject.SetActive(false); }
            }

            if (curCounter >= listTriggers.Count)
            {
                startGameTrigger.gameObject.SetActive(true);
            }
            else
            {
                startGameTrigger.gameObject.SetActive(false);
            }
        }

        public void StopGame()
        {
            for (int i = 0; i < listTriggers.Count; i++)
            {
                listTriggers[i].gameObject.SetActive(false);
            }

            startGameTrigger.gameObject.SetActive(false);

            curCounter = 0;

        }

        public void NextTrigger()
        {
            SetTriggres(curCounter);
            curCounter++;
        }

        public void ResetTriggres()
        {
            SetTriggres(listTriggers.Count + 1);
        }
    }
}