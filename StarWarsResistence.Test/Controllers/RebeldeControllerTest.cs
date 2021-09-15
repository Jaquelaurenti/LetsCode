using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StarWarsResistence.Controllers;
using StarWarsResistence.DTO;
using StarWarsResistence.Models;
using StarWarsResistence.Test.Comparers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace StarWarsResistence.Test.Controllers
{
    public class RebeldeControllerTest
    {
        [Fact]
        public void Should_Be_Ok_When_Find_All_Rebeldes()
        {
            var fakes = new FakeContext("RebeldeControllerTest");
            
            var fakeRebeldeService = fakes.FakeRebeldeService().Object;
            var fakeLocalizacaoService = fakes.FakeLocalizacaoService().Object;
            var fakeInventarioService = fakes.FakeInventarioService().Object;

            var expected = fakes.Mapper.Map<List<Rebelde>>(fakeRebeldeService.FindAllRebeldesAsync());
            
            var contexto = new StarWarsContexto(fakes.FakeOptions);

            var controller = new RebeldeController(fakeRebeldeService,  
                fakes.Mapper, fakeLocalizacaoService, contexto);

            var result = controller.GetAsync();

            Assert.IsType<OkObjectResult>(result.Result);
            var actual = (result.Result as OkObjectResult).Value as List<Rebelde>;

            Assert.NotNull(actual);
            Assert.Equal(expected, actual, new RebeldeIdComparer());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Should_Be_Ok_When_Delete(int id)
        {
            var fakes = new FakeContext("RebeldeTest");

            var fakeRebeldeService = fakes.FakeRebeldeService().Object;
            var fakeLocalizacaoService = fakes.FakeLocalizacaoService().Object;

            var expected = fakes.Mapper.Map<Rebelde>(fakeRebeldeService.FindByIdRebelde(id));

            var contexto = new StarWarsContexto(fakes.FakeOptions);

            var controller = new RebeldeController(fakeRebeldeService,
                 fakes.Mapper, fakeLocalizacaoService, contexto);

            var result = controller.Delete(id);

            Assert.IsType<OkObjectResult>(result.Result);
            var actual = (result.Result as OkObjectResult).Value as Rebelde;

            Assert.NotNull(actual);
            Assert.Equal(expected, actual, new RebeldeIdComparer());
        }
    }
}
