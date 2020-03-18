using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Defence
{
    class AddressAbleLoad : IAssetLoadFactory
    {
        public AudioClip LoadAudioClip(string name)
        {
            throw new NotImplementedException();
        }

        public GameObject LoadCharacter(string name)
        {
            throw new NotImplementedException();
        }

        // public GameObject LoadCharacterEnemy(string name)
        // {
        //     throw new NotImplementedException();
        // }

        // public GameObject LoadCharacterSoldier(string name)
        // {
        //     throw new NotImplementedException();
        // }

        public Sprite LoadSprite(string name)
        {
            throw new NotImplementedException();
        }
    }
}
