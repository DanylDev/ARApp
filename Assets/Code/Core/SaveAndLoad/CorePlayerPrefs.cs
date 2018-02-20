using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Paradigm.SystemSaveAndLoad
{
    public class CorePlayerPrefs
    {
        public void Initialization()
        {

        }

        #region Core

        #region Int

        public void PrefsInt(string key, ref int value)
        {
            if (PlayerPrefs.HasKey(key))
            {
                int getInt = PlayerPrefs.GetInt(key);

                value = PlayerPrefs.GetInt(key);
                CoreUI.DebugLog("Get ref prefsInt " + key + " value " + getInt.ToString(), DDebug.TColor.System);
            }
            else
            {
                PlayerPrefs.SetInt(key, value);
                CoreUI.DebugLog("Create prefsInt " + key, DDebug.TColor.System);
            }
        }

        public void PrefsInt(string key, int value)
        {
            if (PlayerPrefs.HasKey(key))
            {
                int getInt = PlayerPrefs.GetInt(key);

                if (value != getInt)
                {
                    PlayerPrefs.SetInt(key, value);
                    PlayerPrefs.Save();
                    CoreUI.DebugLog("Set prefsInt " + key + " value " + PlayerPrefs.GetInt(key).ToString(), DDebug.TColor.System);
                }
            }
            else
            {
                PlayerPrefs.SetInt(key, value);
                CoreUI.DebugLog("Create prefsInt " + key, DDebug.TColor.System);
            }
        }

        public int PrefsInt(string key)
        {
            if (PlayerPrefs.HasKey(key))
            {
                int getInt = PlayerPrefs.GetInt(key);

                CoreUI.DebugLog("Get prefsInt " + key + " value " + getInt.ToString(), DDebug.TColor.System);
                return getInt;
            }
            else
            {
                CoreUI.DebugLog("PlayerPrefs not found key, return 0", DDebug.TColor.Error);
                return 0;
            }
        }

        #endregion

        #region String

        public void PrefsString(string key, ref string value)
        {
            if (PlayerPrefs.HasKey(key))
            {
                string getString = PlayerPrefs.GetString(key);

                value = PlayerPrefs.GetString(key);
                CoreUI.DebugLog("Get ref prefsString " + key + " value " + getString, DDebug.TColor.System);
            }
            else
            {
                PlayerPrefs.SetString(key, value);
                CoreUI.DebugLog("Create prefsString " + key, DDebug.TColor.System);
            }
        }

        public void PrefsString(string key, string value)
        {
            if (PlayerPrefs.HasKey(key))
            {
                string getString = PlayerPrefs.GetString(key);

                if (value != getString)
                {
                    PlayerPrefs.SetString(key, value);
                    PlayerPrefs.Save();
                    CoreUI.DebugLog("Set prefsString " + key + " value " + PlayerPrefs.GetString(key), DDebug.TColor.System);
                }
            }
            else
            {
                PlayerPrefs.SetString(key, value);
                CoreUI.DebugLog("Create prefsString " + key, DDebug.TColor.System);
            }
        }

        public string PrefsString(string key)
        {
            if (PlayerPrefs.HasKey(key))
            {
                string getString = PlayerPrefs.GetString(key);

                CoreUI.DebugLog("Get prefsString " + key + " value " + getString, DDebug.TColor.System);
                return getString;
            }
            else
            {
                CoreUI.DebugLog("PlayerPrefs not found key, return null", DDebug.TColor.Error);
                return "";
            }
        }

        #endregion

        #region Bool

        public void PrefsBool(string key, ref bool value)
        {
            if (PlayerPrefs.HasKey(key))
            {
                int getInt = PlayerPrefs.GetInt(key);

                if(getInt == 0)
                {
                    value = false;
                    CoreUI.DebugLog("Get ref prefsBool " + key + " value false", DDebug.TColor.System);
                }
                else
                {
                    value = true;
                    CoreUI.DebugLog("Get ref prefsBool " + key + " value true", DDebug.TColor.System);
                }
            }
            else
            {
                if (!value)
                {
                    PlayerPrefs.SetInt(key, 0);
                    CoreUI.DebugLog("Create ref prefsInt " + key + " value false", DDebug.TColor.System);
                }
                else
                {
                    PlayerPrefs.SetInt(key, 1);
                    CoreUI.DebugLog("Create ref prefsInt " + key + " value true", DDebug.TColor.System);
                }
            }
        }

        public void PrefsBool(string key, bool value)
        {
            if (PlayerPrefs.HasKey(key))
            {
                int getInt = PlayerPrefs.GetInt(key);
                short parseBool;

                if (!value) { parseBool = 0; }
                else { parseBool = 1; }

                if (parseBool != getInt)
                {
                    if (!value)
                    {
                        PlayerPrefs.SetInt(key, 0);
                    }
                    else
                    {
                        PlayerPrefs.SetInt(key, 1);
                    }

                    PlayerPrefs.Save();
                    CoreUI.DebugLog("Set prefsBool " + key + " value " + value.ToString(), DDebug.TColor.System);
                }
            }
            else
            {
                if (!value)
                {
                    PlayerPrefs.SetInt(key, 0);
                }
                else
                {
                    PlayerPrefs.SetInt(key, 1);
                }

                CoreUI.DebugLog("Create prefsBool " + key, DDebug.TColor.System);
            }
        }

        public bool PrefsBool(string key)
        {
            if (PlayerPrefs.HasKey(key))
            {
                int getInt = PlayerPrefs.GetInt(key);

                CoreUI.DebugLog("Get prefsInt " + key + " value " + getInt.ToString(), DDebug.TColor.System);

                if (getInt == 0)
                {
                    return false;
                }
                else if (getInt == 1)
                {
                    return true;
                }
                else
                {
                    CoreUI.DebugLog("PlayerPrefs not found key, return false", DDebug.TColor.Error);
                    return false;
                }
            }
            else
            {
                CoreUI.DebugLog("PlayerPrefs not found key, return false", DDebug.TColor.Error);
                return false;
            }
        }

        #endregion

        #region Time

        public void PrefsTime(string key, ref DateTime value)
        {
            if (PlayerPrefs.HasKey(key))
            {
                string getTime = PlayerPrefs.GetString(key);
                string[] splitTime = getTime.Split('/',' ', ':');

                DateTime newTime = new DateTime(int.Parse(splitTime[0]), int.Parse(splitTime[2]), int.Parse(splitTime[4]), int.Parse(splitTime[6]), int.Parse(splitTime[8]), int.Parse(splitTime[10]));

                value = newTime;
                CoreUI.DebugLog("Get ref prefsTime " + key + " value " + newTime, DDebug.TColor.System);
            }
            else
            {
                PlayerPrefs.SetString(key, DateTime.Now.ToString());
            }
        }

        public void PrefsTime(string key, DateTime value)
        {
            if(PlayerPrefs.HasKey(key))
            {
                DateTime getTime = DateTime.Parse(PlayerPrefs.GetString(key));

                if (value != getTime)
                {
                    PlayerPrefs.SetString(key, value.ToString());
                    PlayerPrefs.Save();
                    CoreUI.DebugLog("Set prefsTime " + key + " value " + PlayerPrefs.GetString(key), DDebug.TColor.System);
                }
            }
            else
            {
                PlayerPrefs.SetString(key, value.ToString());
                CoreUI.DebugLog("Create prefsTime " + key, DDebug.TColor.System);
            }
        }

        public DateTime PrefsTime(string key)
        {
            if (PlayerPrefs.HasKey(key))
            {
                string getTime = PlayerPrefs.GetString(key);
                DateTime newTime = DateTime.Parse(getTime);

                CoreUI.DebugLog("Get ref prefsTime " + key + " value " + newTime.ToString(), DDebug.TColor.System);
                return newTime;
            }
            else
            {
                PlayerPrefs.SetString(key, DateTime.Now.ToString());
                return DateTime.Now;
            }
        }

        #endregion

        public bool DeleteKey(string key)
        {
            if(PlayerPrefs.HasKey(key))
            {
                PlayerPrefs.DeleteKey(key);
                CoreUI.DebugLog("Delete prefs " + key, DDebug.TColor.System);
                return true;
            }
            else
            {
                CoreUI.DebugLog("Not found prefs " + key, DDebug.TColor.Error);
                return false;
            }
        }

        #endregion
    }
}