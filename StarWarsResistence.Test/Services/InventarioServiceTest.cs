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
    public class InventarioServiceTest
    {
        private StarWarsContexto _contexto;
        private FakeContext _fakeContext;

        private InventarioService _InventarioService;

        public InventarioServiceTest()
        {
            _fakeContext = new FakeContext("InventarioTestes");
            _fakeContext.FillWithAll();

            _contexto = new StarWarsContexto(_fakeContext.FakeOptions);
            _InventarioService = new InventarioService(_contexto);
        }

        [Fact]
        public async Task Should_Add_New_Inventario_When_SaveAsync()
        {
            var fakeInventario = _fakeContext.GetFakeData<Inventario>().First();

            var current = new Inventario();

            var service = new InventarioService(_contexto);
            current = await service.SaveOrUpdate(fakeInventario);

            Assert.NotEqual(0, fakeInventario.Id);
        }
    }
}
