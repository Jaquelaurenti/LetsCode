using System;
using System.Collections.Generic;
using System.Text;
using StarWarsResistence.Models;
using Xunit;

namespace StarWarsResistence.Test.Models
{
    public class RebeldeModelTest : ModelBaseTest
    {
        public RebeldeModelTest() : base(new CentralErroContexto())
        {
            base.Table = "Rebelde";
            base.Model = "StarWarsResistence.Models.Rebelde";
        }

        [Fact]
        public void Should_Have_Table()
        {
            AssertTable();
        }

        [Fact]
        public void Should_Have_Primary_Key()
        {
            ComparePrimaryKeys("ID");
        }

        [Theory]
        [InlineData("ID", false, typeof(int))]
        [InlineData("Rebelde", false, typeof(string))]
        public void Should_Have_Fields(string campoNome, bool ehNulo,
            Type campoTipo)
        {
            CompareFields(campoNome, ehNulo, campoTipo);
        }
    }
}
