using System;
using StarWarsResistence.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using StarWarsResistence.DTO;
using Moq;
using StarWarsResistence.Services;
using StarWarsResistence.Interfaces;
using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions.Interfaces;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore.Internal;

namespace StarWarsResistence.Test
{
    public class FakeContext
    {
        public DbContextOptions<StarWarsContexto> FakeOptions { get; }
        public readonly IMapper Mapper;

        private Dictionary<Type, string> DataFileNames { get; } =
            new Dictionary<Type, string>();

        private string FileName<T>()
        {
            return DataFileNames[typeof(T)];
        }

        public FakeContext(string testName)
        {
            FakeOptions = new DbContextOptionsBuilder<StarWarsContexto>()
                .UseInMemoryDatabase(databaseName: $"StarWars_{testName}")
                .Options;
            DataFileNames.Add(typeof(Rebelde), $"FakeData{Path.DirectorySeparatorChar}Rebelde.json");
            DataFileNames.Add(typeof(RebeldeDTO), $"FakeData{Path.DirectorySeparatorChar}Rebelde.json");
            DataFileNames.Add(typeof(Localizacao), $"FakeData{Path.DirectorySeparatorChar}localizacao.json");
            DataFileNames.Add(typeof(LocalizacaoDTO), $"FakeData{Path.DirectorySeparatorChar}localizacao.json");
            DataFileNames.Add(typeof(Inventario), $"FakeData{Path.DirectorySeparatorChar}inventario.json");
            DataFileNames.Add(typeof(InventarioDTO), $"FakeData{Path.DirectorySeparatorChar}inventario.json");


            var configuration = new MapperConfiguration(cfg =>
            {
             
                cfg.CreateMap<Rebelde, RebeldeDTO>().ReverseMap();
                cfg.CreateMap<Localizacao, LocalizacaoDTO>().ReverseMap();
                cfg.CreateMap<Inventario, InventarioDTO>().ReverseMap();

            });

            this.Mapper = configuration.CreateMapper();
        }

        public Mock<ILocalizacaoService> FakeLocalizacaoService()
        {
            var service = new Mock<ILocalizacaoService>();

            service.Setup(x => x.FindByIdRebelde(It.IsAny<int>()))
                .Returns((int id) => GetFakeData<Localizacao>()
                .FirstOrDefault(x => x.Id == id));

            service.Setup(x => x.FindByIdRebelde(1))
                .Returns(() => GetFakeData<Localizacao>().FirstOrDefault());

            service.Setup(x => x.SaveOrUpdate(It.IsAny<Localizacao>()))
                .Returns((Localizacao localizacao) =>
                {
                    if (localizacao.Id == 0)
                        localizacao.Id = 999;
                    return localizacao;
                });

            return service;
        }

        public void FillWithAll()
        {
            FillWith<Rebelde>();
            FillWith<Localizacao>();
            FillWith<Inventario>();
        }
        public IList<T> GetFakeData<T>()
        {
            string content = File.ReadAllText(FileName<T>());
            return JsonConvert.DeserializeObject<IList<T>>(content);
        }

        public void FillWith<T>() where T : class
        {
            using (var context = new StarWarsContexto(this.FakeOptions))
            {
                if (context.Set<T>().Count() == 0)
                {
                    foreach (T item in GetFakeData<T>())
                        context.Set<T>().Add(item);
                    context.SaveChanges();
                }
            }
        }

        public Mock<IRebeldeService> FakeRebeldeService()
        {
            var service = new Mock<IRebeldeService>();

            service.Setup(x => x.FindByIdRebelde(It.IsAny<int>()))
                .Returns((int id) => GetFakeData<Rebelde>()
                .FirstOrDefault(x => x.Id == id));

            service.Setup(x => x.FindAllRebeldesAsync())
                .Returns(() => GetFakeData<Rebelde>().ToList());

            service.Setup(x => x.SaveOrUpdate(It.IsAny<Rebelde>()))
                .Returns((Rebelde Rebelde) =>
                {
                    if (Rebelde.Id == 0)
                        Rebelde.Id = 999;
                    return Rebelde;
                });

            return service;
        }


    }
}
