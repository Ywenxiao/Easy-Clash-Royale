using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defence
{
    public static class FactoryManage
    {
        private static IAssetLoadFactory _assetFactory;
        private static EnemyFactory _enemyFactory;  
        private static SoliderFactory _soliderFactory;
        private static IWeaponFactory _weaponFactory;

        public static IAssetLoadFactory AssetResources => _assetFactory ?? (_assetFactory = new ResourcesLoad());
        public static EnemyFactory EnemyFactor => _enemyFactory ?? (_enemyFactory = new EnemyFactory());
        public static SoliderFactory SoliderFactor => _soliderFactory ?? (_soliderFactory = new SoliderFactory());
        public static IWeaponFactory WeaponFactor => _weaponFactory ?? (_weaponFactory = new WeaponFactory());

    }
}
