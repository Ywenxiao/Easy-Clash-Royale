using System;
using System.Collections.Generic;
using UnityEngine;

namespace Defence
{
    public interface IAssetLoadFactory
    {
        GameObject LoadCharacterEnemy(string name);
        GameObject LoadCharacterSoldier(string name);
        Sprite LoadSprite(string name);
        AudioClip LoadAudioClip(string name);
    }
}
