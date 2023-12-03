using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolApp.BLL.DTO;
using ToolApp.DAL.Entities;

namespace ToolApp.BLL.Interfaces
{
    public interface IToolAppService //Интерфейс бизнес-логики, позволяет передавать данные между DAL и WEB
    {
        bool CreateNewTool(ToolDTO toolDTO); //Создать новый инструмент
        bool DeleteTool(int id); // Удалить инструмент по ID

        IEnumerable<ToolDTO> GetAllTools(); // Получить все инструменты
        ToolDTO GetTool(int id); //Получить инструмент по ID

        IEnumerable<Tool_TypeDTO> GetAllTool_Types(); //Получить все типы инструментов
        Tool_TypeDTO GetTool_Type(int id); //Получить тип инструмена по ID
    }
}