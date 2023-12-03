using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolApp.BLL.DTO
{
    public class ToolDTO //DataTransferObject
    {
        public int Id { get; set; }
        public int Id_type_tool { get; set; } //Индификатор типа инструмента
        public string Str_Tool_type { get; set; }//Строка типа инструмента // ToDo : надо ли мне передавать в ДТО объект? лучше строчку, иначе лучше сразу лать модель из DAL
        public string Tool_material { get; set; }//материал инструмента
        public string Tool_manufacturer { get; set; }//материал инструмента
        public double Tool_radius { get; set; }//радиус инструмента для фрез, сверел
        public double Tool_rounding_radius { get; set; }//радиус скргления режущей
                                                        //кромки для фрез, резцов
    }
}


