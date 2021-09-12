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
using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions.Interfaces;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore.Internal;

namespace StarWarsResistence.Test
{
    public class FakeContext
    {
        public DbContextOptions<CentralErroContexto> FakeOptions { get; }
        public readonly IMapper Mapper;

        private Dictionary<Type, string> DataFileNames { get; } =
            new Dictionary<Type, string>();

        private string FileName<T>()
        {
            return DataFileNames[typeof(T)];
        }

        public FakeContext(string testName)
        {
            FakeOptions = new DbContextOptionsBuilder<CentralErroContexto>()
                .UseInMemoryDatabase(databaseName: $"CentralErrors_{testName}")
                .Options;
            DataFileNames.Add(typeof(Rebelde), $"FakeData{Path.DirectorySeparatorChar}Rebelde.json");
            DataFileNames.Add(typeof(RebeldeDTO), $"FakeData{Path.DirectorySeparatorChar}Rebelde.json");
           
            var configuration = new MapperConfiguration(cfg =>
            {
             
                cfg.CreateMap<Rebelde, RebeldeDTO>().ReverseMap();

            });

            this.Mapper = configuration.CreateMapper();
        }

        public void FillWithAll()
        {
            FillWith<Rebelde>();
        }
        public List<T> GetFakeData<T>()
        {
            string content = File.ReadAllText(FileName<T>());
            return JsonConvert.DeserializeObject<List<T>>(content);
        }

        public void FillWith<T>() where T : class
        {
            using (var context = new CentralErroContexto(this.FakeOptions))
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
                .FirstOrDefault(x => x.IdRebelde == id));

            service.Setup(x => x.FindAllRebeldes())
                .Returns(() => GetFakeData<Rebelde>().ToList());

            service.Setup(x => x.SaveOrUpdate(It.IsAny<Rebelde>()))
                .Returns((Rebelde Rebelde) =>
                {
                    if (Rebelde.IdRebelde == 0)
                        Rebelde.IdRebelde = 999;
                    return Rebelde;
                });

            return service;
        }

        
    }
}
