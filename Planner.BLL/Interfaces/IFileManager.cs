using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Planner.BLL.Interfaces
{
    public interface IFileManager
    {
        string GetExtension(string fileName);
        bool CheckExtensionAllow(string extension);
        string GetPath();
        Task SaveAsync(string filePath);
        string CreateName();
    }
}
