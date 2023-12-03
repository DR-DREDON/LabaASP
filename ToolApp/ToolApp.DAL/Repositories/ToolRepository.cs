using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolApp.DAL.EF;
using ToolApp.DAL.Entities;
using ToolApp.DAL.Interfaces;

namespace ToolApp.DAL.Repositories
{
    public class ToolRepository : IToolRepository
    {
        private readonly ToolDBContext db; //Контекст базы данных для репозитория

        public ToolRepository(ToolDBContext db) // Инициализирую контекст в конструкторе
        {
            this.db = db;
        }
        public bool CreateNewTool(Tool tool)
        {
            try
            {
                db.Tools.Add(tool);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteTool(int id)
        {
            Tool tool = db.Tools.Find(id);
            if (tool != null)
                db.Tools.Remove(tool);
            db.SaveChanges();
            return true;
        }

        public List<Tool> GetAllTools()
        {
            return db.Tools.Include(e => e.Tool_type).ToList();
        }

        public Tool GetTool(int id)
        {
            return db.Tools.FirstOrDefault(o => o.Id == id);
        }
    }
}
