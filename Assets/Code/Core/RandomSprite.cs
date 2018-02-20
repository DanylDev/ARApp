using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Paradigm
{
    public class RandomSprite : MonoBehaviour
    {
        [Header("Data")]
        public List<Sprite> listSprite = new List<Sprite>();
        public bool randomSize;
        public bool randomMirror;

        private SpriteRenderer sRenderer;
        private Transform localTransform;

        private void Start()
        {
            sRenderer = GetComponent<SpriteRenderer>();
            localTransform = transform;

            if (sRenderer)
            {
                if (listSprite.Count > 0)
                {
                    Sprite find = null;
                    while (!find)
                    {
                        find = listSprite[Random.Range(0, listSprite.Count)];
                    }

                    sRenderer.sprite = listSprite[Random.Range(0, listSprite.Count)];
                }

                if(randomSize)
                {
                    float factor = Random.Range(0.9f, 1.5f);

                    //localTransform.localScale *= factor;
                    localTransform.localScale = new Vector3(1, 1, 1);
                }

                if(randomMirror)
                {
                    float factor = 0;

                    while (factor == 0)
                    {
                        factor = Random.Range(-1, 1);
                    }

                    Vector3 fix = localTransform.localScale;
                    fix.x *= factor;

                    localTransform.localScale = fix;
                }
            }
        }
    }
}