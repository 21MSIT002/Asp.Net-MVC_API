using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 

namespace studentApi.Exceptionhandle
{
    public class customexception : Exception
    {
        public customexception(string msg) : base(msg)
        {

        }
    }
}