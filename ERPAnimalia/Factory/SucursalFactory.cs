using ERPAnimalia.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPAnimalia.Factory
{
    public class SucursalFactory
    {
        public static SucursalManager CreateSucursalManager()
        {            
            return new SucursalManager ();
        }
    }
}