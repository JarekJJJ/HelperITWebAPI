﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperIT.Application.Common.Interfaces
{
    public interface IFileStore
    {
        string SafeWriteFile(byte[] content, string sourceFileName, string path);
    }
}
