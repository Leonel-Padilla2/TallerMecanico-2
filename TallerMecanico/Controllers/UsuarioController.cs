using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TallerMecanico.Filters;
using TallerMecanico.Models.Domain;
using TallerMecanico.Models.Domain.Entities;
using TallerMecanico.Models.ViewModels;

namespace TallerMecanico.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ILogger<UsuarioController> _logger;
        private TallerMecanicoDBContext _context;

        public UsuarioController(ILogger<UsuarioController> logger, TallerMecanicoDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        [ClaimRequirement("Usuario")]
        public IActionResult Index()
        {
            var ListaUsuarios = _context.Usuario.Where(w => w.Eliminado == false).ProjectToType<UsuarioVm>().ToList();
            return View(ListaUsuarios);
        }

        [HttpGet]
        [ClaimRequirement("Usuario")]
        public IActionResult Insertar()
        {
            var registro = new UsuarioVm();
            var listaRoles= _context.Rol.Where(w => w.Eliminado == false).ProjectToType<RolVm>().ToList();
            List<SelectListItem> itemsTaxis = listaRoles.ConvertAll(t => {
                return new SelectListItem()
                {
                    Text = t.Descripcion.ToString(),
                    Value = t.Id.ToString(),
                    Selected = false
                };
            });
            registro.Roles = itemsTaxis;

            return View(registro);
        }

        [HttpPost]
        [ClaimRequirement("Usuario")]
        public IActionResult Insertar(UsuarioVm registro)
        {
            var listaRoles = _context.Rol.Where(w => w.Eliminado == false).ProjectToType<RolVm>().ToList();
            List<SelectListItem> itemsTaxis = listaRoles.ConvertAll(t => {
                return new SelectListItem()
                {
                    Text = t.Descripcion.ToString(),
                    Value = t.Id.ToString(),
                    Selected = false
                };
            });
            registro.Roles = itemsTaxis;

            var validacion = registro.Validar();

            TempData["Mensaje"] = validacion.Mensaje;
            if (!validacion.IsValid)
            {
                return View(registro);
            }

            var newEntidadRegistro = Usuario.Create(
                registro.Nombre,
                registro.Apellido,
                registro.Correo,
                Utilidades.Utilidades.GetMD5(registro.Password),
                registro.RolId
            );

            _context.Usuario.Add(newEntidadRegistro);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        [ClaimRequirement("Usuario")]
        public IActionResult Editar(Guid Id)
        {
            var registro = _context.Usuario.Where(w => w.UsuarioId == Id && w.Eliminado == false).ProjectToType<UsuarioVm>().FirstOrDefault();

            var listaRoles = _context.Rol.Where(w => w.Eliminado == false).ProjectToType<RolVm>().ToList();
            List<SelectListItem> itemsTaxis = listaRoles.ConvertAll(t => {
                return new SelectListItem()
                {
                    Text = t.Descripcion.ToString(),
                    Value = t.Id.ToString(),
                    Selected = false
                };
            });
            registro.Roles = itemsTaxis;

            return View(registro);
        }

        [HttpPost]
        [ClaimRequirement("Usuario")]
        public IActionResult Editar(UsuarioVm registro)
        {
            var listaRoles = _context.Rol.Where(w => w.Eliminado == false).ProjectToType<RolVm>().ToList();
            List<SelectListItem> itemsTaxis = listaRoles.ConvertAll(t => {
                return new SelectListItem()
                {
                    Text = t.Descripcion.ToString(),
                    Value = t.Id.ToString(),
                    Selected = false
                };
            });
            registro.Roles = itemsTaxis;

            var validacion = registro.ValidarEnUpdate();

            TempData["Mensaje"] = validacion.Mensaje;
            if (!validacion.IsValid)
            {
                return View(registro);
            }

            var registroActual = _context.Usuario.FirstOrDefault(w => w.UsuarioId == registro.UsuarioId);
            registroActual.Update(
                registro.Nombre,
                registro.Apellido,
                registro.Correo,
                registro.Password,
                registro.RolId
            );
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        [ClaimRequirement("Usuario")]
        public IActionResult Eliminar(Guid Id)
        {
            var registro = _context.Usuario.Where(w => w.UsuarioId == Id && w.Eliminado == false).ProjectToType<UsuarioVm>().FirstOrDefault();

            return View(registro);
        }

        [HttpPost]
        [ClaimRequirement("Usuario")]
        public IActionResult Eliminar(UsuarioVm registro)
        {
            var validacion = registro.ValidarEnDelete();
            TempData["Mensaje"] = validacion.Mensaje;
            if (!validacion.IsValid)
            {
                return View(registro);
            }

            var registroActual = _context.Usuario.FirstOrDefault(w => w.UsuarioId == registro.UsuarioId);
            registroActual.Delete();
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        [ClaimRequirement("Usuario")]
        public IActionResult ExportarExcel()
        {
            var ListaUsuarios = _context.Usuario.Where(w => w.Eliminado == false).ProjectToType<UsuarioVm>().ToList();
            DataTable dt = Utilidades.Utilidades.ConvertToDataTable(ListaUsuarios);

            string filename = "Usuarios.xlsx";
            string filepath = $"{AppDomain.CurrentDomain.BaseDirectory}\\{filename}";

            // Creamos una instancia de Excel
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Visible = false;
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.ActiveSheet;

            // Copiamos los datos de la tabla al archivo de Excel
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    sheet.Cells[i + 1, j + 1] = dt.Rows[i][j].ToString();
                }
            }

            // Guardamos el archivo y lo descargamos al usuario
            workbook.SaveAs(filepath);
            workbook.Close();
            excel.Quit();

            byte[] fileBytes = System.IO.File.ReadAllBytes(filepath);
            System.IO.File.Delete(filepath);

            return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", filename);
        }

    }
}
