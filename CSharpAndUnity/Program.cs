using DungeonLibrary;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAndUnity
{
    class Program
    {

        static void Main(string[] args)
        {


            var unityContainer = new UnityContainer();
            //InjectionProperty injectedProperty = new InjectionProperty("EquippedWeapon",)
            unityContainer.RegisterType<IWeapon, Axe>();

            //could set up some randomization code to register random type each time
            //Random rand = new Random();
            //switch (rand.Next(1, 3))
            //{
            //    case 1:
            //        unityContainer.RegisterType<IWeapon, Axe>();
            //        break;

            //    case 2:
            //        unityContainer.RegisterType<IWeapon, Sword>();
            //        break;
            //}

            Console.WriteLine("Dungeon App!");

            //Player p1 = new Player();
            //Console.WriteLine(p1.Name + " wields " + p1.EquippedWeapon.Name);

            //using default ctor without DI
            IPlayer p1 = new Player();
            Console.WriteLine(p1.Name + " wields the " + p1.EquippedWeapon.GetType().Name + " , " + p1.EquippedWeapon.Name);

            //using FQ ctor without DI
            var w2 = new Sword(10, 20, "SuperSword", 25, false);
            IPlayer p2 = new Player("El Macho", 50, 50, 70, 70, w2);
            Console.WriteLine(p2.Name + " wields the " + p2.EquippedWeapon.GetType().Name + " , " + p2.EquippedWeapon.Name);

            //direct resolving with DI through Unity
            var w3 = unityContainer.Resolve<IWeapon>();
            IPlayer p3 = new Player(w3);
            Console.WriteLine(p3.Name + " wields the " + p3.EquippedWeapon.GetType().Name + " , " + p3.EquippedWeapon.Name);

            //indirect resolving with DI through Unity
            IPlayer p4 = unityContainer.Resolve<Player>();
            Console.WriteLine(p4.Name + " wields the " + p4.EquippedWeapon.GetType().Name + " , " + p4.EquippedWeapon.Name);

            //indirect resolving with parameter injection through Unity
            IPlayer p5 = unityContainer.Resolve<Player>(new ParameterOverride("equippedWeapon", new Sword()));
            Console.WriteLine(p5.Name + " wields the " + p5.EquippedWeapon.GetType().Name + " , " + p5.EquippedWeapon.Name);


            //Dependency Injection relies upon our ability to provide
            //the dependent class instance (Sword or Axe) from outside 
            //the reliant class (Player).  By abstracting our classes
            //we provide greater flexibility, by making the parameter
            //reliant upon a class that implements an interface rather
            //than a specific concrete class that is tightly coupled
            //to the reliant class.

            //Inversion of Control takes the decision of what concrete
            //class to provide to the interface parameter. MS Unity is 
            //an IOC framework (Ninject and Structuremap are also popular)
            //that can be configured to automatically handle the DI
            //decisions.

        }
    }
}
