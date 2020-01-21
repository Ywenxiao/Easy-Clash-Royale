using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Defence
{
    public class ResourcesLoad : IAssetLoadFactory
    {
        private const string PathAudioClip = "Audios/";
        private const string CharacterEnemy = "Charactes/Enemy/";
        public const string CharacterSoldier = "Charactes/Soldier/";
        public const string Sprite = "Sprites/";

        public AudioClip LoadAudioClip(string name)
        {
            var clip = Resources.Load<AudioClip>(PathAudioClip + name);
            return clip;
        } 

        public GameObject LoadCharacterEnemy(string name)
        {
            var prefab = Resources.Load<GameObject>(CharacterEnemy + name);
            return prefab;
        }

        public GameObject LoadCharacterSoldier(string name)
        {
            var prefab = Resources.Load<GameObject>(CharacterSoldier + name);
            return prefab;
        }

        public Sprite LoadSprite(string name)
        {
            var sprite = Resources.Load<Sprite>(Sprite + name);
            return sprite;
        }
    }
}