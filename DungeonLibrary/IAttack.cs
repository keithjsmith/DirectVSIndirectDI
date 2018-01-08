using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public interface IAttack
    {
        //There is definitely a school of thought that you 
        //would write all of these members into separate 
        //interfaces, but for simplicity we are using a single
        //interface since these 3 methods are basically a 
        //package of behavior

        int CalcDamage();
        int CalcHitChance();
        int CalcBlockChance();
    }
}
