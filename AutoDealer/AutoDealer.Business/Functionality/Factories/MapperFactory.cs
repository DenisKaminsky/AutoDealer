using System.Collections.Generic;
using AutoDealer.Business.Interfaces.Factories;
using AutoMapper;

namespace AutoDealer.Business.Functionality.Factories
{
    public class MapperFactory : IMapperFactory
    {
        private readonly Dictionary<string, IMapper> _mappers;

        public MapperFactory(params KeyValuePair<string, IMapper>[] mappers)
        {
            _mappers = new Dictionary<string, IMapper>(mappers);
        }

        public IMapper GetMapper(string mapperName)
        {
            return _mappers[mapperName];
        }
    }
}
