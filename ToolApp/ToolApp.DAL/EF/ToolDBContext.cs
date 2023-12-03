using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolApp.DAL.Entities;

namespace ToolApp.DAL.EF
{
    public class ToolDBContext : DbContext //Контекст базы данных
    {
        public DbSet<Tool> Tools { get; set; } = null!; //Таблица инструментов
        public DbSet<Tool_type> Tool_type { get; set; } = null!; //Таблица Типов инструментов
        public ToolDBContext(DbContextOptions<ToolDBContext> options)
            : base(options)
        {
            Database.EnsureCreated(); // Если база данных не создана - создает новую базу данных
        }
    }
}
