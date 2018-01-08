using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    //By making an interface it will provide us with
    //an abstraction layer between individual weapon 
    //datatypes and our implmentation of those datatypes
    //in the Player class
    public interface IWeapon
    {   
        //at a minimum we need to know about MinDamage, MaxDamage, 
        //and BonusHitChance for all of our Weapons, but we
        //already have one made that includes Name and IsTwohanded
        //so we will include them all.
        //NOTE:  We could structure this similar to Character/Player
        //and use a base class to inherit, but this shows another tool
        //to put in our toolbox as well as illustrating the similarites
        //between inheritance and implmentation of interfaces
        //Real world:  Be consistent in your architecture
        int MaxDamage { get; }
        int MinDamage { get; }
        int BonusHitChance { get; }
        string Name { get; }
        bool IsTwohanded { get; }
    }
}
