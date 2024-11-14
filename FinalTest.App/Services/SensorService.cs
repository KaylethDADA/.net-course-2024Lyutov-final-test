using AutoMapper;
using FinalTest.App.Dtos.Sensors;
using FinalTest.App.Interfaces.Repositories;
using FinalTest.Domain.Entities;

namespace FinalTest.App.Services
{
    public class SensorService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Sensor> _sensorRepository;
        private readonly IRepository<Notification> _notificationRepository;

        public SensorService(IRepository<Sensor> sensorRepository, IRepository<Notification> notificationRepository, IMapper mapper)
        {
            _sensorRepository = sensorRepository;
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }

        public async Task<SensorResponse> CreateSensorAsync(CreateSensorRequest request, CancellationToken cancellationToken)
        {

            var existingSensor = await _sensorRepository.GetAsync(s => s.Name == request.Name && s.BuildingId == request.BuildingId, null, null, cancellationToken);
            if (existingSensor.FirstOrDefault() != null)
            {
                throw new ArgumentException("Датчик с таким именем уже существует в этом здании.");
            }

            var sensor = _mapper.Map<Sensor>(request);
            await _sensorRepository.AddAsync(sensor, cancellationToken);

            return _mapper.Map<SensorResponse>(sensor);
        }

        public async Task<SensorResponse> UpdateSensorAsync(UpdateSensorRequest request, CancellationToken cancellationToken)
        {
            var existingSensor = await _sensorRepository.GetByIdAsync(request.SensorId, cancellationToken);
            if (existingSensor == null)
            {
                throw new KeyNotFoundException("Датчик не найден.");
            }

            existingSensor = _mapper.Map(request, existingSensor);
            await _sensorRepository.UpdateAsync(existingSensor, cancellationToken);

            return _mapper.Map<SensorResponse>(existingSensor);
        }

        public async Task<SensorResponse> GetSensorByIdAsync(Guid sensorId, CancellationToken cancellationToken)
        {
            var sensor = await _sensorRepository.GetByIdAsync(sensorId, cancellationToken);
            if (sensor == null)
            {
                throw new KeyNotFoundException("Датчик не найден.");
            }

            return _mapper.Map<SensorResponse>(sensor);
        }

        public async Task NotifySensorThresholdExceededAsync(Guid sensorId, float sensorValue, CancellationToken cancellationToken)
        {
            var sensor = await _sensorRepository.GetByIdAsync(sensorId, cancellationToken);
            if (sensor == null)
            {
                throw new KeyNotFoundException("Датчик не найден.");
            }

            if (sensorValue < sensor.MinThreshold || sensorValue > sensor.MaxThreshold)
            {
                var notification = new Notification
                {
                    Date = DateTime.UtcNow,
                    Recipient = "User",
                    Message = $"Датчик {sensor.Name} в здании {sensor.BuildingId} зафиксировал значение {sensorValue}, которое выходит за пределы установленных порогов."
                };

                await _notificationRepository.AddAsync(notification, cancellationToken);
            }
        }

        public async Task NotifyLowBatteryAsync(Guid sensorId, float batteryLevel, CancellationToken cancellationToken)
        {
            if (batteryLevel < 10)
            {
                var notification = new Notification
                {
                    Date = DateTime.UtcNow,
                    Recipient = "User",
                    Message = $"Уровень заряда аккумулятора датчика {sensorId} ниже 10%."
                };

                await _notificationRepository.AddAsync(notification, cancellationToken);
            }
        }
    }
}
