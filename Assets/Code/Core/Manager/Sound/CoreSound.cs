using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Paradigm
{
    [System.Serializable]
    public class DataSound
    {
        public CoreSound.TType type;
        public CoreSound.TTypeSound typeSound;
        public AudioClip clip;
    }

    public class CoreSound : MonoBehaviour
    {
        public enum TTypeSound
        {
            Enter,
            Exit,
            Click,
            Switch,
            Death,
            Hit,
            Money,
            Jump,
            StartHook,
            EndHook,
            SwitchGravity,
            Buy,
            None,
            Running
        }

        public enum TType
        {
            Sound,
            Musics
        }

        [Header("Data")]
        public GameObject exampleSound;
        private List<AudioSource> listBackgroundMusic = new List<AudioSource>();

        public void PlayOneShot(TTypeSound typeSound)
        {
            GameObject newSound = Instantiate(exampleSound, transform);
            AudioSource aSource = newSound.GetComponent<AudioSource>();

            DataSound getData = GetSound(typeSound);
            aSource.clip = getData.clip;

            if (aSource.clip)
            {
                aSource.Play();

                aSource.loop = false;
                Destroy(newSound, aSource.clip.length + 0.05f);

            }
            else
            {
                Destroy(newSound);
            }
        }

        public void PlayOneShot(TTypeSound typeSound, TType type)
        {
            GameObject newSound = Instantiate(exampleSound, transform);
            AudioSource aSource = newSound.GetComponent<AudioSource>();

            DataSound getData = GetSound(typeSound, type);
            aSource.clip = getData.clip;

            if (aSource.clip)
            {
                aSource.Play();
                aSource.loop = true;
                listBackgroundMusic.Add(aSource);
            }
            else
            {
                Destroy(newSound);
            }
        }

        public void BackgroundMusic(bool state)
        {
            foreach(AudioSource audio in listBackgroundMusic)
            {
                audio.enabled = state;

                if (state)
                {
                    audio.Play();
                }
                else
                {
                    audio.Stop();
                }
            }
        }

        private DataSound GetSound(TTypeSound typeSound)
        {
            foreach (DataSound sound in CoreAppControl.Instance.ListSounds)
            {
                if (sound.typeSound == typeSound)
                {
                    return sound;
                }
            }

            return new DataSound();
        }

        private DataSound GetSound(TTypeSound typeSound, TType type)
        {
            foreach (DataSound sound in CoreAppControl.Instance.ListSounds)
            {
                if (sound.typeSound == typeSound && sound.type == type)
                {
                    return sound;
                }
            }

            return new DataSound();
        }
    }
}