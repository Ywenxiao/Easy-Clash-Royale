using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defence
{
    interface ICharacterFactory
    {
        Character CreateCharacter<T>(WeaponType type) where T : Character, new();
    }
}