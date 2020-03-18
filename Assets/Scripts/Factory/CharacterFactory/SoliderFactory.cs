using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defence
{
    public class SoliderFactory : ICharacterFactory
    {
        public Character CreateCharacter<T>(WeaponType type) where T : Character, new()
        {
            return null; //TODO:创建角色
        }
    }
}