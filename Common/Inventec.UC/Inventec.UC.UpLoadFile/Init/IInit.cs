﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventec.UC.UpLoadFile.Init
{
    interface IInit
    {
        UserControl InitUC(MainUpLoadFile.EnumTemplate Template, UpLoadFileToServer UpLoad);
    }
}
