using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Web_App.Models;
using static System.Formats.Asn1.AsnWriter;

namespace MVC_Web_App.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
            if(!db.Tool_types.Any())
            {
                Tool_type mill = new Tool_type { Name_tool_type = "Фреза" };
                Tool_type cutter = new Tool_type { Name_tool_type = "Резец" };
                Tool_type drill = new Tool_type { Name_tool_type = "Сверло" };
                Tool_type grinding_stone = new Tool_type { Name_tool_type = "Шлифовальный камень" };

                db.Tool_types.AddRange(mill, cutter, drill, grinding_stone);

                db.SaveChanges();
            }
        }

        public async Task<IActionResult> Index(string tool_material, 
            string tool_manufacturer, int tool_type = 0, int page = 1)
        {
            int pageSize = 3;

            //фильтрация
            IQueryable<Tool> tools = db.Tools.Include(x => x.Tool_type);

            if (tool_type != 0)
            {
                tools = tools.Where(p => p.Id_type_tool == tool_type);
            }
            if (!string.IsNullOrEmpty(tool_material))
            {
                tools = tools.Where(p => p.Tool_material!.Contains(tool_material));
            }
            // пагинация
            var count = await tools.CountAsync();
            var items = await tools.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            // формируем модель представления
            IndexViewModel viewModel = new IndexViewModel(
                items,
                new PageViewModel(count, page, pageSize),
                new FilterViewModel(db.Tool_types.ToList(), tool_type, tool_manufacturer)
            );
            return View(viewModel);
        }

        public IActionResult Create()
        {
            ViewBag.Tool_types = new SelectList(db.Tool_types, "Id", "Name_tool_type");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Tool tool)
        {
            tool.Tool_type = db.Tool_types.FirstOrDefault(e => e.Id == tool.Id_type_tool);
            db.Tools.Add(tool);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");//редирект на индекс
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Tool tool = new Tool { Id = id.Value };
                db.Entry(tool).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
