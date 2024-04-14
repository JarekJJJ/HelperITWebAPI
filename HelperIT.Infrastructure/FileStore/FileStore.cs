using HelperIT.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperIT.Infrastructure.FileStore
{
    public class FileStore: IFileStore
    {
        private readonly IFileWrapper _fileWrapper;
        private readonly IDirectoryWrapper _directoryWrapper;  
        public FileStore(IFileWrapper filewrapper, IDirectoryWrapper directoryWrapper)
        {
           _fileWrapper = filewrapper;
           _directoryWrapper = directoryWrapper;
        }
        public string SafeWriteFile(byte[] content, string sourceFileName, string path)
        {
            _directoryWrapper.CreateDirectory(path);
            var outputFile = Path.Combine(path, sourceFileName);
            _fileWrapper.WriteAllBytes(outputFile, content);
            return outputFile;

        }
    }
}
