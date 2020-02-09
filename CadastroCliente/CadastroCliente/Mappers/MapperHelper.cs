using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadastroCliente.Mappers
{
    public static class MapperHelper
    {
        public static IEnumerable<TDestination> Map<TSource, TDestination>(IEnumerable<TSource> sourceList)
        {
            var destinationList = new List<TDestination>();
            if (sourceList == null)
            {
                return destinationList;
            }

            destinationList.AddRange(sourceList.Select(origin => (TDestination)Mapper.Map(origin, typeof(TSource), typeof(TDestination))));
            return destinationList;
        }
    }
}