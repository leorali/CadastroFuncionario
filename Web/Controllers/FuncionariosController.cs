using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AcessoDados;
using Negocio;

namespace Web.Controllers
{
    public class FuncionariosController : BaseController
    {
        private CadastroFuncionarioContext db = new CadastroFuncionarioContext();

        // GET: CadastroFuncionario
        public ActionResult Index()
        {
            var funcionarios = Mapper.Map<IEnumerable<Funcionario>, IEnumerable<ViewModel.Funcionario>>(db.Funcionarios.ToList());
            return View(funcionarios);
        }

        [HttpPost]
        public ActionResult Index(string nome)
        {
            var funcionarios = Mapper.Map<IEnumerable<Funcionario>, IEnumerable<ViewModel.Funcionario>>(db.Funcionarios.Where(f => f.Nome.Contains(nome)).OrderBy(f => f.Nome).ToList());
            return View(funcionarios);
        }

        // GET: CadastroFuncionario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.Funcionarios.Find(id);
            var funcionarios = Mapper.Map<Funcionario, ViewModel.Funcionario>(db.Funcionarios.Find(id));
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionarios);
        }

        public void PopulaDados()
        {
            ListaGestores();
            ListaAreas();
            ListaCargos();
        }

        // GET: CadastroFuncionario/Create
        public ActionResult Create()
        {
            PopulaDados();
            return View();
        }

        // POST: CadastroFuncionario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ViewModel.Funcionario funcionario)
        {
            PopulaDados();
            if (ModelState.IsValid)
            {
                SalvarFuncionario(funcionario, false);
                return RedirectToAction("Index");
            }
            return View(funcionario);
        }

        // GET: CadastroFuncionario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.Funcionarios.Find(id);
            var funcionarios = Mapper.Map<Funcionario, ViewModel.Funcionario>(db.Funcionarios.Find(id));

            if (funcionario == null)
            {
                return HttpNotFound();
            }
            PopulaDados();
            return View(funcionarios);
        }

        // POST: CadastroFuncionario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ViewModel.Funcionario funcionario)
        {
            PopulaDados();

            if (ModelState.IsValid)
            {
                SalvarFuncionario(funcionario, true);
                return RedirectToAction("Index");
            }
            return View(funcionario);
        }

        // GET: CadastroFuncionario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.Funcionarios.Find(id);
            var funcionarios = Mapper.Map<Funcionario, ViewModel.Funcionario>(db.Funcionarios.Find(id));
            if (funcionario == null)
            {
                return HttpNotFound();
            }

            return View(funcionarios);
        }


        //metodo ComparaArea

        public int ComparaArea(Area area)
        {
            var comparaArea = db.Areas.SingleOrDefault(c => c.NomeArea == area.NomeArea);

            if (comparaArea != null) return comparaArea.Id;
            db.Areas.Add(area);
            db.SaveChanges();
            return area.Id;
        }

        // metodo ComparaCargo

        public int ComparaCargo(Cargo cargo)
        {
            var comparaCargo = db.Cargos.SingleOrDefault(c => c.NomeCargo == cargo.NomeCargo);

            if (comparaCargo != null) return comparaCargo.Id;
            db.Cargos.Add(cargo);
            db.SaveChanges();
            return cargo.Id;
        }

        //metodo ListaGestores
        public void ListaGestores()
        {
            var funcionarios = db.Funcionarios.ToList();
            var gestoresSelectList = new SelectList(funcionarios, "Id", "Nome");
            ViewBag.GestoresSelectList = gestoresSelectList;
        }

        //metodo ListaAreas

        public void ListaAreas()
        {
            var areaList = db.Areas.Select(a => a.NomeArea).ToList();
            var selectListAreas = new SelectList(areaList, "Id", "NomeArea");
            ViewBag.AreasSelectList = selectListAreas;
        }

        public void ListaAreasCompleto()
        {
            var areaList = db.Areas.ToList();
            ViewBag.AreaList = areaList;
        }

        //metodo salvar funcionario

        public void SalvarFuncionario(ViewModel.Funcionario funcionario, bool alterar)
        {
            var endereco = funcionario.Endereco;
            funcionario.Endereco = null;
            var enderecoModel = Mapper.Map<ViewModel.Endereco, Endereco>(endereco);

            funcionario.Gestor = null;

            var cargo = funcionario.Cargo;
            var area = funcionario.Cargo.Area;
            funcionario.Cargo = null;
            var cargoModel = Mapper.Map<ViewModel.Cargo, Cargo>(cargo);

            var areaModel = Mapper.Map<ViewModel.Area, Area>(area);
            var areaId = ComparaArea(areaModel);
            cargoModel.AreaId = areaId;
            funcionario.CargoId = ComparaCargo(cargoModel);

            var funcionarioModel = Mapper.Map<ViewModel.Funcionario, Funcionario>(funcionario);

            if (!alterar)
            {
                db.Enderecos.Add(enderecoModel);
                db.SaveChanges();
                funcionarioModel.EnderecoId = enderecoModel.Id;
                db.Funcionarios.Add(funcionarioModel);
                db.SaveChanges();
            }
            else
            {
                var enderecoAtualizar = db.Enderecos.SingleOrDefault(e => e.Id == enderecoModel.Id);
                if (enderecoAtualizar != null)
                {
                    db.Entry(enderecoAtualizar).CurrentValues.SetValues(enderecoModel);
                    db.SaveChanges();
                }
                funcionarioModel.EnderecoId = enderecoModel.Id;
                var funcionarioAtualizar = db.Funcionarios.SingleOrDefault(f => f.Id == funcionarioModel.Id);
                if (funcionarioAtualizar != null)
                {
                    db.Entry(funcionarioAtualizar).CurrentValues.SetValues(funcionarioModel);
                    db.SaveChanges();
                }

            }
        }

        //metodo ListaCargos

        public void ListaCargos()
        {
            var cargoList = db.Cargos.Select(a => a.NomeCargo).ToList();
            var selectListCargos = new SelectList(cargoList, "Id", "NomeCargo");
            ViewBag.CargosSelectList = selectListCargos;

            }

        public void ListaCargosCompleto()
        {
            var cargoList = db.Cargos.ToList();
            ViewBag.CargoList = cargoList;
        }


        // POST: CadastroFuncionario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var comparaFuncionario = db.Funcionarios.SingleOrDefault(f => f.Id == id);

            if (comparaFuncionario != null)
            {
                db.Funcionarios.Remove(comparaFuncionario);
            }

            var comparaEndereco = db.Enderecos.SingleOrDefault(e => e.Id == id);

            if (comparaEndereco != null)
            {
                db.Enderecos.Remove(comparaEndereco);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
