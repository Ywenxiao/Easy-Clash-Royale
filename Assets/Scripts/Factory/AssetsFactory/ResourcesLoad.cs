using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Defence
{
    public class ResourcesLoad : IAssetLoadFactory
    {
        public AudioClip LoadAudioClip(string name)
        {
            throw new NotImplementedException();
        }

        public GameObject LoadCharacter(string name)
        {
            throw new NotImplementedException();
        }

        public Sprite LoadSprite(string name)
        {
            throw new NotImplementedException();
        }
    }
}
