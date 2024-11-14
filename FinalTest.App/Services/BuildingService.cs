using AutoMapper;
using FinalTest.App.Dtos.Building;
using FinalTest.App.Interfaces.Repositories;
using FinalTest.Domain.Entities;
using System.Linq.Expressions;

namespace FinalTest.App.Services
{
    public class BuildingService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Building> _buildingRepository;

        public BuildingService(IRepository<Building> buildingRepository, IMapper mapper)
        {
            _buildingRepository = buildingRepository;
            _mapper = mapper;
        }

        public async Task<BuildingResponse> AddBuildingAsync(CreateBuildingRequest request, CancellationToken cancellationToken)
        {
            var existingBuilding = await _buildingRepository.GetAsync(b => b.Name == request.Name && b.Address == request.Addres, null, null, cancellationToken);
            if (existingBuilding.Any())
            {
                throw new ArgumentException("Здание с таким названием и адресом уже существует.");
            }

            var building = new Building(request.Name, request.Addres, request.UserId);
            await _buildingRepository.AddAsync(building, cancellationToken);

            return _mapper.Map<BuildingResponse>(building);
        }

        public async Task<BuildingResponse> UpdateBuildingAsync(UpdateBuildingRequest request, CancellationToken cancellationToken)
        {
            var existingBuilding = await _buildingRepository.GetByIdAsync(request.Id, cancellationToken);
            if (existingBuilding == null)
            {
                throw new KeyNotFoundException("Здание не найдено.");
            }

            existingBuilding.Update(request.Name, request.Addres);
            await _buildingRepository.UpdateAsync(existingBuilding, cancellationToken);

            return _mapper.Map<BuildingResponse>(existingBuilding);
        }

        public async Task<BuildingResponse> GetBuildingByIdAsync(Guid buildingId, CancellationToken cancellationToken)
        {
            var building = await _buildingRepository.GetByIdAsync(buildingId, cancellationToken);
            if (building == null)
            {
                throw new KeyNotFoundException("Здание не найдено.");
            }

            return _mapper.Map<BuildingResponse>(building);
        }

        public async Task<ICollection<BuildingResponse>> GetBuildingsAsync(PagedBuildingRequest request, CancellationToken cancellationToken)
        {
            var filter = _mapper.Map<Expression<Func<Building, bool>>>(request);
            var buildingList = await _buildingRepository.GetAsync(filter, request.PageNumber, request.PageSize, cancellationToken);
            return _mapper.Map<ICollection<BuildingResponse>>(buildingList);
        }

        public async Task DeleteBuildingAsync(Guid buildingId, CancellationToken cancellationToken)
        {
            var building = await _buildingRepository.GetByIdAsync(buildingId, cancellationToken);
            if (building == null)
            {
                throw new KeyNotFoundException("Здание не найдено.");
            }

            await _buildingRepository.DeleteAsync(building, cancellationToken);
        }
    }
}
