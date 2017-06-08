using AutoMapper;

namespace AcessoDados.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName => "DomainToViewModelMappings";
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Negocio.Funcionario, ViewModel.Funcionario>().PreserveReferences();
            CreateMap<Negocio.Endereco, ViewModel.Endereco>();
            CreateMap<Negocio.Area, ViewModel.Area>().PreserveReferences();
            CreateMap<Negocio.Cargo, ViewModel.Cargo>().PreserveReferences();
            CreateMap<Negocio.Beneficio, ViewModel.Beneficio>().PreserveReferences();
        }
    }
}
