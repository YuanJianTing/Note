using NoteClient.Extension;
using NoteClient.Repository;
using System.Windows.Forms;

namespace NoteClient
{
    public class PageManager
    {
        private static PageManager? instance;
        public static PageManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new PageManager();
                return instance;
            }
        }
       
        private readonly ApplicationContext applicationContext;
        private readonly List<MainForm> FormsList;
        private readonly IRepository Repository;
        private WindowsFormsSynchronizationContext? synchronizationContext;
        public PageManager()
        {
            applicationContext = new ApplicationContext();
            FormsList = new List<MainForm>();
            Repository = new LocalFileRepository();
        }

        public int PageIndex { get; private set; }

        public void ShowForm(string pageName)
        {
            MainForm mainForm = new MainForm(pageName);
            mainForm.FormClosed += MainForm_FormClosed;
            FormsList.Add(mainForm);
            mainForm.Show();
        }

        private void MainForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            FormsList.Remove(sender as MainForm);
            if (FormsList.Count == 0)
            {
                applicationContext.ExitThread();
                applicationContext.Dispose();
            }
        }

        public void ShowForm()
        {
            PageIndex++;
            string name = "Page" + PageIndex;
            ShowForm(name);
        }

        public ApplicationContext Run(WindowsFormsSynchronizationContext synchronizationContext)
        {
            this.synchronizationContext= synchronizationContext;
            Load();
            return applicationContext;
        }

        private void Load()
        {
            Repository.GetPagesAsync().ContinueWith(o =>
            {
                Thread.Sleep(500);
                if (o.Status == TaskStatus.RanToCompletion)
                    synchronizationContext?.Post<List<string>>(OnPageList, o.Result);
            });
        }

        private void OnPageList(List<string> pageList)
        {
            PageIndex = pageList.Count;
            foreach (var item in pageList)
            {
                ShowForm(item);
            }
        }
    }
}
