using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolApp.DAL.Entities;

namespace ToolApp.DAL.Interfaces
{
    public interface IToolTypeRepository // Интерфейс для доступа к репозиторию типов инструмента
    {
        Tool_type GetTool_Type(int id); // Передать из БД тип инструмента по ID
        List<Tool_type> GetAllTool_Types(); // Передать из БД все инструмента // ToDo :: сделать сортировку по всем типам инструмента и передать туда все инструменты
    }
}
