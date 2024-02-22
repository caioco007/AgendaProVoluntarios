using AgendaProVoluntarios.DTO.ViewModels;
using AgendaProVoluntarios.Repositories.Interfaces;
using AgendaProVoluntarios.Repositories.Repositories;
using AgendaProVoluntarios.Services.Interfaces;

namespace AgendaProVoluntarios.Services.Services
{
    public class FunctionService : IFunctionService
    {
        private readonly IFunctionRepository _functionRepository;

        public FunctionService(IFunctionRepository functionRepository)
        {
            _functionRepository = functionRepository;
        }

        public async Task<List<FunctionViewModel>> GetAllAsync() {

            var functions = await _functionRepository.GetAllAsync();

            return functions.Select(f => new FunctionViewModel(f.TypeId, f.ActivityId)).ToList();
        }
    }
}
