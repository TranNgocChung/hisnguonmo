﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventec.UC.ComboTHX.Init
{
    interface IInit
    {
        UserControl InitCombo(string template, Data.DataInitTHX Data);
    }
}
