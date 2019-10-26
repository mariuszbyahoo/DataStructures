using System;
using System.Collections.Generic;
using System.Text;

namespace ReflectIt
{
    public class Container
    {
        public Container For<T1>()
        {
            return this;
        }

        public void Use<T>()
        {

        }

        public Container Resolve<T>()
        {
            return this;
        }
    }
}
