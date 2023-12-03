using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolApp.DAL.EF;
using ToolApp.DAL.Entities;
using ToolApp.DAL.Interfaces;

namespace ToolApp.DAL.Repositories
{
    public class ToolTypeRepository : IToolTypeRepository
    {
        private readonly ToolDBContext db; //Контекст базы данных для репозитория

        public ToolTypeRepository(ToolDBContext db) // Инициализирую контекст в конструкторе
        {
            this.db = db;

            Tool_type mill = new Tool_type { Name_tool_type = "Фреза" };
            Tool_type cutter = new Tool_type { Name_tool_type = "Резец" };
            Tool_type drill = new Tool_type { Name_tool_type = "Сверло" };
            Tool_type grinding_stone = new Tool_type { Name_tool_type = "Шлифовальный камень" };



            if(!db.Tool_type.Any())
            {
                db.Tool_type.Add(mill);
                db.Tool_type.Add(cutter);
                db.Tool_type.Add(drill);
                db.Tool_type.Add(grinding_stone);
                db.SaveChanges();
            }

            Tool_type tool_Type = db.Tool_type.FirstOrDefault();

            //Tool tool = new Tool()
            //{
            //    Id_type_tool = tool_Type.Id,
            //    Tool_type = tool_Type,
            //    Tool_material = "Быстрорежущая сталь",
            //    Tool_manufacturer = "Iscar",
            //    Tool_radius = 5,
            //    Tool_rounding_radius = 0.1
            //};

            //if (!db.Tools.Any())
            //{
            //    db.Tools.Add(tool);
            //    db.SaveChanges();
            //}

        }

        public List<Tool_type> GetAllTool_Types()
        {
            return db.Tool_type.ToList();
        }


        public Tool_type GetTool_Type(int id)
        {
            return db.Tool_type.FirstOrDefault(o => o.Id == id);
        }
    }
}
