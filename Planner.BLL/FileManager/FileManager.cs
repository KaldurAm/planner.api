using Planner.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Planner.BLL.FileManager
{
    public class FileManager : IFileManager
    {
        public bool CheckExtensionAllow(string extension)
        {
            throw new NotImplementedException();
        }

        public string CreateName()
        {
            throw new NotImplementedException();
        }

        public string GetExtension(string fileName)
        {
            throw new NotImplementedException();
        }

        public string GetPath()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
