using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace czTest
{
    class x2_virtual_method
    {
        public static void Main1()
        {
            //var animal = new Animal();
            //Console.WriteLine(animal.DoSomething());    // I can breathe
            //var bird = new Bird();
            //Console.WriteLine(bird.DoSomething());       //  I can fly
            //var cat = new Cat();
            //Console.WriteLine(cat.DoSomething());　　　//  I can run


            var animal = new Animal();
            animal.DoSomething();    // I can breathe


            Animal bird = new Bird();
            Console.WriteLine(bird.GetType());
            Console.WriteLine(bird.DoSomething());// Bird.DoSomething()
            Console.WriteLine(((Bird)bird).DoSomething());// Bird.DoSomething()
                                                          // bird 的真实类型是 Bird
                                                          // 所以CLR会调用 Bird重写过的版本，这是多态性的保证
                                                          // 子类使用override关键字重写父类方法，则调用谁的方法由”**运行时引用真实的对象决定**“。

            Animal cat = new Cat();
            Console.WriteLine(cat.GetType());
            Console.WriteLine(cat.DoSomething());// Animal.DoSomething()
            Console.WriteLine(((Cat)cat).DoSomething());// Cat.DoSomething()

            Console.WriteLine("//////////////");
            cat.xx();

            Console.Read();
        }
    }

    public class Animal
    {
        public virtual string DoSomething()
        {
            return "I can breathe";
        }

        public void xx()
        {
            var aa = MemberwiseClone();
            Console.WriteLine(aa.GetType());

        }
    }

    public class Bird : Animal
    {
        public override string DoSomething()
        {
            return "I can fly";
        }
    }

    public class Cat : Animal
    {
        public new string DoSomething()
        {
            return "I can run";
        }
    }
}
