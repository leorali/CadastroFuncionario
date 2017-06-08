using AutoMapper;

namespace AcessoDados.Mappers
{
    public class ViewModelToDomainMappingProfile: Profile
    {
        public override string ProfileName => "ViewModelToDomainMappings";
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ViewModel.Funcionario, Negocio.Funcionario>();
            CreateMap<ViewModel.Area, Negocio.Area>();
            CreateMap<ViewModel.Beneficio, Negocio.Beneficio>();
            CreateMap<ViewModel.Cargo, Negocio.Cargo>();
            CreateMap<ViewModel.Endereco, Negocio.Endereco>();
        }
    }
}
