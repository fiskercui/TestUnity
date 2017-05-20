using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ConfigDatabase1
{
    private static ConfigDatabase1 _DefaultCfg = null;
    public static ConfigDatabase1 DefaultCfg
    {
        get
        {
            return _DefaultCfg;
        }
        set
        {
            if (_DefaultCfg == null)
            {
                _DefaultCfg = new ConfigDatabase1();
            }
        }
    }

}
