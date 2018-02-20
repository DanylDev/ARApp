using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Paradigm
{
    public class CoreAppControl : MonoBehaviourSingleton<CoreAppControl>
    {
        #region Data
        [Header("Debug")]
        [SerializeField] private DataDebug dataDebug;
        [SerializeField] private List<DataSound> listSounds;
        [SerializeField] private CoreSound coreSound;
        [SerializeField] private DialogApp dialogApp;

        public DataDebug DataDebug { get { return dataDebug; } }
        public List<DataSound> ListSounds { get { return listSounds; } }


        public CoreSound CoreSound { get { return coreSound; } }
        public DialogApp DialogApp { get { return dialogApp; } }

        private const string nameSceneLoader = "LoadManager";
        public float progress { get; private set; }

        #endregion

        public delegate void OnLoad();
        public event OnLoad eventLoad;

        #region Unity

        private void Awake()
        {
            Initialization();
        }

        private void Update()
        {
            CoreUpdate();
        }

        #endregion

        #region Core

        public void Initialization()
        {
            Globals.Instance.Initialization();

            DontDestroyOnLoad(gameObject);

            //StartCoroutine(DelayInit());
        }

        public void CoreUpdate()
        {
            Globals.Instance.CoreUpdate();
        }

        private IEnumerator DelayInit()
        {
            yield return new WaitForSeconds(0.5f);

            List<int> initScene = new List<int>();

            initScene.Add(2);

            LoadScene(initScene, LoadSceneMode.Additive);
        }

        public void LoadScene(List<int> sceneIndex, LoadSceneMode mode = LoadSceneMode.Single)
        {
            StartCoroutine(LoadAsynchronously(sceneIndex, mode));
        }

        IEnumerator LoadAsynchronously(List<int> sceneIndex, LoadSceneMode mode = LoadSceneMode.Single)
        {
            SceneManager.LoadScene(nameSceneLoader);

            yield return new WaitForSeconds(0.5f);

            for (int i = 0; i < sceneIndex.Count; i++)
            {
                AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex[i], mode);

                if (operation == null)
                {
                    Debug.Log(CoreUI.GetStringColor("Scene not found", DDebug.TColor.Error));
                    yield return null;
                }

                while (!operation.isDone)
                {
                    if (operation.progress > 0)
                    {
                        progress = (Mathf.Clamp01(operation.progress / .9f) / sceneIndex.Count) * (i + 1);
                    }
                    CoreUI.DebugLog("Load: " + (progress * 100), DDebug.TColor.Warning);

                    yield return null;
                }
            }

            //DialogApp.CellWindow(WindowControll.TTypeWindow.SplashLoad, true);
            //DialogApp.GetWindow(WindowControll.TTypeWindow.SplashLoad).transform.SetParent(transform);
            //DialogApp.GetWindow(WindowControll.TTypeWindow.SplashLoad).GetComponent<SplashLoadUI>().SetTime();

            //yield return new WaitForSeconds(DialogApp.GetWindow(WindowControll.TTypeWindow.SplashLoad).GetComponent<SplashLoadUI>().defaultTimer);

            if (progress >= 1)
            {
                SceneManager.UnloadSceneAsync(nameSceneLoader);
            }

            //eventLoad();
        }

        #endregion
    }
}