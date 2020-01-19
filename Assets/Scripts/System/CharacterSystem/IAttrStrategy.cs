using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defence
{
    //角色计算方法
   public interface IAttrStrategy
   {
       /// <summary>
       /// 得到随等级增加的HP
       /// </summary>
       int GetExtraHpValue(int lv);

       /// <summary>
       /// 
       /// </summary>
       int GetDmgDescValue(int lv);

         // int GetCriti

   }
}
