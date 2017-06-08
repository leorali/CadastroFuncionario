using System.Web.Mvc;
using AcessoDados.Mappers;
using AutoMapper;

namespace Web.Controllers
{
    public class BaseController : Controller
    {
        public IMapper Mapper;

        public BaseController()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<DomainToViewModelMappingProfile>();
                cfg.AddProfile<ViewModelToDomainMappingProfile>();
            });
            Mapper = config.CreateMapper();
        }
    }
}