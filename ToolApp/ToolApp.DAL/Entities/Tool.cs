using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolApp.DAL.Entities
{
    public class Tool //Модель инструмента в базе данных
    {
        public int Id { get; set; }
        public int Id_type_tool { get; set; } //Индификатор типа инструмента
        public Tool_type Tool_type { get; set; }//Объект типа инструмента
        public string Tool_material { get; set; }//материал инструмента
        public string Tool_manufacturer { get; set; }//материал инструмента
        public double Tool_radius { get; set; }//радиус инструмента для фрез, сверел
        public double Tool_rounding_radius { get; set; }//радиус скргления режущей
                                                         //кромки для фрез, резцов

    }
}
