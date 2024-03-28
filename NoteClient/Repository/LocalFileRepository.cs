namespace NoteClient.Repository
{
    public class LocalFileRepository : IRepository
    {
        private readonly string SaveDir;
        public LocalFileRepository()
        {
            SaveDir = Path.Combine(Directory.GetCurrentDirectory(),"Data");
            Directory.CreateDirectory(SaveDir);
        }

        public List<string> GetPages()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(SaveDir);
            return directoryInfo.GetFiles("*.rtf").Select(i => Path.GetFileNameWithoutExtension(i.Name)).ToList();
        }

        public Task<List<string>> GetPagesAsync()
        {
            return Task.FromResult(GetPages());
        }

        public string Get(string pageName)
        {
            string fileName = GetFileName(pageName);
            if(!File.Exists(fileName)) return string.Empty;
            return File.ReadAllText(fileName);
        }

        public Task<string> GetAsync(string pageName)
        {
            string fileName = GetFileName(pageName);
            if (!File.Exists(fileName)) return Task.FromResult(string.Empty);
            return File.ReadAllTextAsync(fileName);
        }

        public void Save(string pageName, string rtf)
        {
            File.WriteAllText(GetFileName(pageName), rtf);
        }

        public async Task SaveAsync(string pageName, string rtf)
        {
            await File.WriteAllTextAsync(GetFileName(pageName), rtf);
        }

        private string GetFileName(string pageName)
        {
            return Path.Combine(SaveDir,pageName+".rtf");
        }

        public void Delete(string pageName)
        {
            if (File.Exists(GetFileName(pageName))) 
                File.Delete(GetFileName(pageName)); 
        }

        public Task DeleteAsync(string pageName)
        {
            return Task.Run(()=> Delete(pageName));
        }
    }
}
