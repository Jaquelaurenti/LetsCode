using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using StarWarsResistence.Models;
using StarWarsResistence.Services;
using StarWarsResistence.Test.Comparers;
using Xunit;

namespace StarWarsResistence.Test.Services
{
    public class RebeldeServiceTest
    {
        private StarWarsContexto _contexto;
        private FakeContext _fakeContext;

        private RebeldeService _RebeldeService;

        public RebeldeServiceTest()
        {
            _fakeContext = new FakeContext("RebeldeTestes");
            _fakeContext.FillWithAll();

            _contexto = new StarWarsContexto(_fakeContext.FakeOptions);
            _RebeldeService = new RebeldeService(_contexto);
        }

        [Fact]
        public void Should_Add_New_Rebelde_When_Save()
        {
            var fakeRebelde = _fakeContext.GetFakeData<Rebelde>().First();

            var current = new Rebelde();

            var service = new RebeldeService(_contexto);
            current = service.SaveOrUpdate(fakeRebelde);

            Assert.NotEqual(0, fakeRebelde.Id);
        }
        
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Should_Return_Right_Rebelde_When_Find_By_Id(int id)
        {
            var Rebelde = _fakeContext.GetFakeData<Rebelde>().Find(x => x.Id== id);

            var service = new RebeldeService(_contexto);
            var atual = service.FindByIdRebelde(Rebelde.Id);

            Assert.Equal(Rebelde, atual, new RebeldeIdComparer());
        }

        [Fact]
        public void Should_Return_Ok_When_Find_All_Rebeldes()
        {
            var Rebelde = _fakeContext.GetFakeData<Rebelde>().ToList();

            var service = new RebeldeService(_contexto);
            var atual = service.FindAllRebeldes();

            Assert.Equal(Rebelde, atual, new RebeldeIdComparer());
        }
    }
}
