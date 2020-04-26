using AutoMapper;

namespace AutoDealer.Business.Interfaces.Factories
{
    public interface IMapperFactory
    {
        IMapper GetMapper(string mapperName);
    }
}
