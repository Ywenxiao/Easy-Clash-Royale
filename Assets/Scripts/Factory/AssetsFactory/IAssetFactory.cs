using System;
using System.Collections.Generic;
using UnityEngine;

namespace Defence
{
    public interface IAssetLoadFactory
    {
        GameObject LoadCharacter(string name);
        Sprite LoadSprite(string name);
        AudioClip LoadAudioClip(string name);
          }
}
