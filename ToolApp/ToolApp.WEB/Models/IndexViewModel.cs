using ToolApp.BLL.DTO;

namespace ToolApp.WEB.Models
{
    public class IndexViewModel
    {
        public IEnumerable<ToolDTO> Tools { get; }
        public PageViewModel PageViewModel { get; }
        public FilterViewModel FilterViewModel { get; }
        public IndexViewModel(IEnumerable<ToolDTO> tools, PageViewModel pageViewModel,
            FilterViewModel filterViewModel)
        {
            Tools = tools;
            PageViewModel = pageViewModel;
            FilterViewModel = filterViewModel;
        }
    }
}
