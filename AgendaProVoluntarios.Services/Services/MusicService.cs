using AgendaProVoluntarios.Data.Entities;
using AgendaProVoluntarios.DTO.InputModels;
using AgendaProVoluntarios.DTO.ViewModels;
using AgendaProVoluntarios.Repositories.Interfaces;
using AgendaProVoluntarios.Repositories.Repositories;
using AgendaProVoluntarios.Services.Interfaces;

namespace AgendaProVoluntarios.Services.Services
{
    public class MusicService : IMusicService
    {
        private readonly IMusicRepository _musicRepository;

        public MusicService(IMusicRepository musicRepository)
        {
            _musicRepository = musicRepository;
        }

        public async Task<List<MusicViewModel>> GetAllAsync()
        {
            var musics = await _musicRepository.GetAllAsync();

            return musics.Select(m => new MusicViewModel(m.Id, m.Name, m.Key)).ToList();
        }
        public async Task<MusicViewModel> GetByIdAsync(Guid id) 
        {
            var music = await _musicRepository.GetByIdAsync(id);
            if (music == null)
            {
                return null;
            }
            return new MusicViewModel(music.Id, music.Name, music.Key);
        }

        public async Task AddAsync(NewMusicInputModel inputModel)
        {
            var music = new Music(inputModel.Name, inputModel.Key);

            await _musicRepository.AddAsync(music);
        }
    }
}
