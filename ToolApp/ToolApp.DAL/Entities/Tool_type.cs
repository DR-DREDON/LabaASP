using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolApp.DAL.Entities;

namespace ToolApp.DAL.Entities
{
    public class Tool_type
    {
        public int Id { get; set; }
        public string Name_tool_type { get; set; } //Название типа инструмента
        public ICollection<Tool> Tools { get; set; } //Все инструмента данного типа
    }
}                         