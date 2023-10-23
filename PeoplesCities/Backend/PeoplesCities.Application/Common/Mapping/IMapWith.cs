using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeoplesCities.Application.Common.Mapping
{
    public interface IMapWith<T>
    {
        /// <summary>
        /// Создает конфигурацию из исходного типа Т и к назнначению.
        /// </summary>
        /// <param name="profile"></param>
        void Mapping(Profile profile) =>
            profile.CreateMap(typeof(T), GetType());
    }
}
