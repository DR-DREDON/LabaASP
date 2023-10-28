namespace MVC_Web_App.Models
{
    public class Tool
    {
        public int Id { get; set; }
        public int Id_type_tool { get; set; }
        public Tool_type? Tool_type { get; set; }//тип инструмента
        public string? Tool_material { get; set; }//материал инструмента
        public string? Tool_manufacturer { get; set; }//материал инструмента
        public double? Tool_radius { get; set; }//радиус инструмента для фрез, сверел
        public double? Tool_rounding_radius { get; set; }//радиус скргления режущей
                                                        //кромки для фрез, резцов

    }

    public class Tool_type
    {
        public int Id { get; set; }
        public string? Name_tool_type { get; set; }
        public List<Tool> Tools { get; set; } = new();
    }
}
