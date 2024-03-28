using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteClient.Repository
{
    public interface IRepository
    {
        List<string> GetPages();
        Task<List<string>> GetPagesAsync();

        void Save(string pageName, string rtf);

        string Get(string pageName);

        Task SaveAsync(string pageName, string rtf);

        Task<string> GetAsync(string pageName);

        void Delete(string pageName);
        Task DeleteAsync(string pageName);

    }
}
