using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroTouchUnraveled
{
    /// <summary>
    /// Wrapper class for my first node.
    /// </summary>
    public class MyFirstNode
    {
        //this hides the overall class as a node 
        private MyFirstNode() { }

        /// <summary>
        /// This is my first node that outputs a string that says Hello World. Awesome. 😁
        /// </summary>
        /// <returns name="helloWorldString">Our hello world node.</returns>
        public static string HelloWorld()
        {
            //returns one output of hello world
            return "Hello world";
        }
    }
}
