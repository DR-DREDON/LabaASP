namespace MVC_Web_App.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Tool> Tools { get; }
        public PageViewModel PageViewModel { get; }
        public FilterViewModel FilterViewModel { get; }
        public IndexViewModel(IEnumerable<Tool> tools, PageViewModel pageViewModel,
            FilterViewModel filterViewModel)
        {
            Tools = tools;
            PageViewModel = pageViewModel;
            FilterViewModel = filterViewModel;
        }
    }
}
