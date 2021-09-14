using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using StarWarsResistence.Models;
using StarWarsResistence.Services;
using StarWarsResistence.Test.Comparers;
using Xunit;

namespace StarWarsResistence.Test.Services
{
    public class LocalizacaoServiceTest
    {
        private StarWarsContexto _contexto;
        private FakeContext _fakeContext;

        private LocalizacaoService _localizacaoService;

        public LocalizacaoServiceTest()
        {
            _fakeContext = new FakeContext("LocalizacaoTestes");
            _fakeContext.FillWithAll();

            _contexto = new StarWarsContexto(_fakeContext.FakeOptions);
            _localizacaoService = new LocalizacaoService(_contexto);
        }

        [Fact]
        public async Task Should_Add_New_Localizacao_When_SaveAsync()
        {
            var fakeLocalizacao = _fakeContext.GetFakeData<Localizacao>().First();

            var current = new Localizacao();

            var service = new LocalizacaoService(_contexto);
            current = await service.SaveOrUpdate(fakeLocalizacao);

            Assert.NotEqual(0, fakeLocalizacao.Id);
        }
        
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Should_Return_Right_Localizacao_When_Find_By_Id(int id)
        {
            var Localizacao = _fakeContext.GetFakeData<Localizacao>().Find(x => x.Id== id);

            var service = new LocalizacaoService(_contexto);
            var atual = service.FindByIdRebelde(Localizacao.Id);

            Assert.Equal(Localizacao, atual, new LocalizacaoIdComparer());
        }

        [Fact]
        public void Should_Return_Ok_When_Find_All_Localizacaos()
        {
            var Localizacao = _fakeContext.GetFakeData<Localizacao>().ToList();
            var list = new List<Localizacao>();
            foreach(var item in Localizacao)
            {
                var service = new LocalizacaoService(_contexto);
                var atual = service.FindByNome(item.Nome);

                list.Add(atual);
            }

            Assert.Equal(Localizacao, list, new LocalizacaoIdComparer());

        }
    }
}
