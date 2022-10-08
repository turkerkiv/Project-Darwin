using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuiscFilesNN {

    public class MuiscFiles : MonoBehaviour
    {
        public List<AudioClip> music = new List<AudioClip>();
        void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
