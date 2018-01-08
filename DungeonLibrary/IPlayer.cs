using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public interface IPlayer
    {
        //if we were going to make multiple datatypes that were
        //going to be used as players we would need all of the 
        //things that a player needs for the other datatypes
        //therefore we need to define them here in the interface
        IWeapon EquippedWeapon { get; set; }
        int MaxLife { get; set; }
        int BlockChance { get; set; }
        int HitChance { get; set; }
        string Name { get; set; }

    }
}
