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
        /// <param name="extraMessage">Optional extra message from dynamo.</param>
        /// <returns name="helloWorldString">Our hello world node.</returns>
        public static string HelloWorld(string extraMessage = "")
        {
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            //returns one output of hello world
            return $"Hello, {userName}. {extraMessage}";
        }
    }
}
