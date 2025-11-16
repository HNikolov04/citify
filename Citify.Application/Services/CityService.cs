using Citify.Application.Dtos.City.Requests;
using Citify.Application.Dtos.City.Responses;
using Citify.Application.Mappers.Contracts;
using Citify.Application.Services.Contracts;
using Citify.Domain.Exceptions;
using Citify.Persistence.Repositories.Contracts;

namespace Citify.Application.Services;

public class CityService : ICityService
{
    private readonly ICityRepository _cityRepository;
    private readonly ICountryRepository _countryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICityMapper _mapper;

    public CityService(
        ICityRepository cityRepository,
        ICountryRepository countryRepository,
        IUnitOfWork unitOfWork,
        ICityMapper mapper)
    {
        _cityRepository = cityRepository;
        _countryRepository = countryRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CityDto> CreateAsync(CityCreateRequest request)
    {
        if (await _cityRepository.ExistsByNameAsync(request.Name))
        {
            throw new DuplicateNameException(request.Name, "City");
        }

        if (await _countryRepository.GetByIdAsync(request.CountryId) == null)
        {
            throw new NotFoundException("Country", request.CountryId);
        }

        var entity = _mapper.ToEntity(request);

        await _cityRepository.AddAsync(entity);

        await _unitOfWork.SaveChangesAsync();

        return _mapper.ToDto(entity);
    }

    public async Task<CityDto> UpdateAsync(CityUpdateRequest request)
    {
        var entity = await _cityRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException("City", request.Id);

        if (entity.Name != request.Name && await _cityRepository.ExistsByNameAsync(request.Name))
        {
            throw new DuplicateNameException(request.Name, "City");
        }

        if (await _countryRepository.GetByIdAsync(request.CountryId) == null)
        {
            throw new NotFoundException("Country", request.CountryId);
        }

        _mapper.MapUpdate(request, entity);

        await _unitOfWork.SaveChangesAsync();

        return _mapper.ToDto(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _cityRepository.GetByIdAsync(id)
            ?? throw new NotFoundException("City", id);

        await _cityRepository.DeleteAsync(entity);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<CityDto> GetByIdAsync(Guid id)
    {
        var entity = await _cityRepository.GetByIdAsync(id)
            ?? throw new NotFoundException("City", id);

        return _mapper.ToDto(entity);
    }

    public async Task<CityPagedResponse> GetPagedAsync(int pageNumber, int pageSize)
    {
        var items = await _cityRepository.GetPagedAsync(pageNumber, pageSize);

        var count = await _cityRepository.CountAsync();

        return new CityPagedResponse(
            items.Select(_mapper.ToDto),
            count
        );
    }
}
