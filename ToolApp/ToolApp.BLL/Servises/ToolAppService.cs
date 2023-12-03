using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolApp.BLL.DTO;
using ToolApp.BLL.Interfaces;
using ToolApp.DAL.Entities;
using ToolApp.DAL.Interfaces;
using ToolApp.DAL.Repositories;

namespace ToolApp.BLL.Servises
{
    public class ToolAppService : IToolAppService
    {
        private readonly IToolRepository toolRepository; // Репозиторий инструументов
        private readonly IToolTypeRepository toolTypeRepository; //Репозиторий типов инструментов

        public ToolAppService(IToolRepository toolRepository, IToolTypeRepository toolTypeRepository)
        {
            this.toolRepository = toolRepository;
            this.toolTypeRepository = toolTypeRepository;
        }

        public bool CreateNewTool(ToolDTO toolDTO)
        {
            var tool_type = new Tool_type(); 
            // Пробую найти выбранный тип инструмента в БД
            try
            {
                tool_type = toolTypeRepository.GetTool_Type(toolDTO.Id_type_tool); // Нахожу выбранный тип инструмента в БД

                if (tool_type == null)
                {
                    return false;
                }
            }

            catch (Exception)
            {
                return false;
            }

            // Создаю на основе DTO новый объект для записи в БД
            Tool tool = new Tool()
            {
                Id_type_tool = tool_type.Id,
                Tool_type = tool_type,
                Tool_material = toolDTO.Tool_material,
                Tool_manufacturer = toolDTO.Tool_manufacturer,
                Tool_radius = toolDTO.Tool_radius,
                Tool_rounding_radius = toolDTO.Tool_rounding_radius
            };

            //Пробую добавить инстрмуент в БД

            try
            {
                toolRepository.CreateNewTool(tool);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteTool(int id)
        {
            // Пробую найти в бд такой инструмент
            try
            {
                var tool = toolRepository.GetTool(id);
                if (tool == null)
                {
                    return false;
                }
                toolRepository.DeleteTool(id);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<ToolDTO> GetAllTools()
        {
            var tools = toolRepository.GetAllTools();

            var toolDTOs = new List<ToolDTO>();
            // По списку от БД заполняю аналогичный список с DTO инструментов
            if (tools.Count != 0) // ToDo : если обработаю получение пустого списка в вебе - условие можно убрать, так как и пустой список будет получен в любом случае
            {
                for (int i = 0; i < tools.Count; i++)
                {
                    var toolsDTO = new ToolDTO()
                    {
                        Id = tools[i].Id,
                        Id_type_tool = tools[i].Id_type_tool,
                        Str_Tool_type = tools[i].Tool_type.Name_tool_type,
                        Tool_material = tools[i].Tool_material,
                        Tool_manufacturer = tools[i].Tool_manufacturer,
                        Tool_radius = tools[i].Tool_radius,
                        Tool_rounding_radius = tools[i].Tool_rounding_radius
                    };
                    toolDTOs.Add(toolsDTO);
                }
            }
            return toolDTOs;
        }

        public IEnumerable<Tool_TypeDTO> GetAllTool_Types()
        {
            var tool_types = toolTypeRepository.GetAllTool_Types();

            var tool_typeDTOs = new List<Tool_TypeDTO>();
            // По списку от БД заполняю аналогичный список с DTO типлв инструментов
            if (tool_types.Count != 0)
            {
                for (int i = 0; i < tool_types.Count; i++)
                {
                    var tool_typeDTO = new Tool_TypeDTO()
                    {
                        Id = tool_types[i].Id,
                        Name_tool_type = tool_types[i].Name_tool_type
                    };
                    tool_typeDTOs.Add(tool_typeDTO);
                }
            }
            return tool_typeDTOs;
        }

        public ToolDTO GetTool(int id)
        {
            var tool = toolRepository.GetTool(id);

            if (tool != null)
            {
                ToolDTO toolDTO = new ToolDTO()
                {
                    Id = tool.Id,
                    Id_type_tool = tool.Id_type_tool,
                    Str_Tool_type = tool.Tool_type.Name_tool_type,
                    Tool_material = tool.Tool_material,
                    Tool_manufacturer = tool.Tool_manufacturer,
                    Tool_radius = tool.Tool_radius,
                    Tool_rounding_radius = tool.Tool_rounding_radius
                };

                return toolDTO;
            }

            return null;
        }

        public Tool_TypeDTO GetTool_Type(int id)
        {
            var tool_type = toolTypeRepository.GetTool_Type(id);
            
            if (tool_type != null)
            {
                Tool_TypeDTO tool_TypeDTO = new Tool_TypeDTO()
                {
                    Id = tool_type.Id,
                    Name_tool_type = tool_type.Name_tool_type
                };

                return tool_TypeDTO;
            }

            return null;
        }
    }
}
