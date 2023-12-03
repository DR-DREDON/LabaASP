using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolApp.DAL.Entities;

namespace ToolApp.DAL.Interfaces
{
    public interface IToolRepository // Интерфейс для доступа к репозиторию инструментов
    {
        bool CreateNewTool(Tool tool); //Создать новый инструмент (передаю готовую модель инструмента) //ToDo: в логике добавить возможность отправлять модель инструмента с привязанным типом инструмента
        bool DeleteTool(int id); // Удалить инструмент по ID
        Tool GetTool(int id); // Передать из БД инструмент по ID
        List<Tool> GetAllTools(); // Передать из БД все инструметы
    }
}
