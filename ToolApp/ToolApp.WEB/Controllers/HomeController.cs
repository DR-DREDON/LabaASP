using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ToolApp.BLL.DTO;
using ToolApp.BLL.Interfaces;
using ToolApp.BLL.Servises;
using ToolApp.DAL.Entities;
using ToolApp.WEB.Models;

namespace ToolApp.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IToolAppService toolAppService;

        public HomeController(IToolAppService toolAppService)
        {
            this.toolAppService = toolAppService;
        }

        public async Task<IActionResult> Index(string tool_material,
            string tool_manufacturer, int tool_type = 0, int page = 1)
        {
            int pageSize = 7;

            //фильтрация

            var tools = toolAppService.GetAllTools();

            if (tool_type != 0)
            {
                tools = tools.Where(p => p.Id_type_tool == tool_type);
                   
            }
            if (!string.IsNullOrEmpty(tool_material))
            {
                tools = tools.Where(p => p.Tool_material!.Contains(tool_material));
            }
            // пагинация
            var count = tools.Count();
            var items = tools.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            // формируем модель представления
            IndexViewModel viewModel = new IndexViewModel(
                items,
                new PageViewModel(count, page, pageSize),
                new FilterViewModel(toolAppService.GetAllTool_Types().ToList(), tool_type, tool_manufacturer)
            );
            return View(viewModel);
        }
        public IActionResult Create()
        {
            ViewBag.Tool_types = new SelectList(toolAppService.GetAllTool_Types(), "Id", "Name_tool_type");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ToolDTO toolDTO)
        {
            toolAppService.CreateNewTool(toolDTO);
            return RedirectToAction("Index");//Редирект на индекс
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id != null)
            {
                toolAppService.DeleteTool(id);
                return RedirectToAction("Index");
            }
            return NotFound();
        }

    }
}
