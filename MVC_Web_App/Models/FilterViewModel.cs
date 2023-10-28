using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC_Web_App.Models
{
    public class FilterViewModel
    {
        public FilterViewModel(List<Tool_type> tool_types, int tool_type, string tool_material)
        {
            tool_types.Insert(0, new Tool_type { Name_tool_type = "Все", Id = 0 });
            Tool_types = new SelectList(tool_types, "Id", "Name_tool_type", tool_type);
            Selected_Tool_type = tool_type;
            SelectedName = tool_material;
        }
        public SelectList Tool_types { get; } // список всех видов инструментов
        public int Selected_Tool_type { get; } // выбранный инструмент
        public string SelectedName { get; } // выбор сортировки
    }
}
