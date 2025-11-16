using Citify.Application.Dtos.Country.Requests;
using Citify.Application.Dtos.Country.Responses;
using Citify.Application.Mappers.Contracts;
using Citify.Application.Services.Contracts;
using Citify.Domain.Exceptions;
using Citify.Persistence.Repositories.Contracts;

namespace Citify.Application.Services;

public class CountryService : ICountryService
{
    private readonly ICountryRepository _countryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICountryMapper _mapper;

    public CountryService(
        ICountryRepository countryRepository,
        IUnitOfWork unitOfWork,
        ICountryMapper mapper)
    {
        _countryRepository = countryRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CountryDto> CreateAsync(CountryCreateRequest request)
    {
        if (await _countryRepository.ExistsByNameAsync(request.Name))
        {
            throw new DuplicateNameException(request.Name, "Country");
        }

        var entity = _mapper.ToEntity(request);

        await _countryRepository.AddAsync(entity);

        await _unitOfWork.SaveChangesAsync();

        return _mapper.ToDto(entity);
    }

    public async Task<CountryDto> UpdateAsync(CountryUpdateRequest request)
    {
        var entity = await _countryRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException("Country", request.Id);

        if (entity.Name != request.Name && await _countryRepository.ExistsByNameAsync(request.Name))
        {
            throw new DuplicateNameException(request.Name, "Country");
        }

        _mapper.MapUpdate(request, entity);

        await _unitOfWork.SaveChangesAsync();

        return _mapper.ToDto(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _countryRepository.GetByIdAsync(id)
            ?? throw new NotFoundException("Country", id);

        await _countryRepository.DeleteAsync(entity);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<CountryDto> GetByIdAsync(Guid id)
    {
        var entity = await _countryRepository.GetByIdAsync(id)
            ?? throw new NotFoundException("Country", id);

        return _mapper.ToDto(entity);
    }

    public async Task<CountryPagedResponse> GetPagedAsync(int pageNumber, int pageSize)
    {
        var items = await _countryRepository.GetPagedAsync(pageNumber, pageSize);

        var count = await _countryRepository.CountAsync();

        return new CountryPagedResponse(
            items.Select(_mapper.ToDto),
            count
        );
    }
}