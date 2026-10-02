using EcommerceCheckout.App;
namespace EcommerceCheckout.Tests;

public class PedidoServiceTest
{
    [Fact]
    public void GerarCodigoRastreio_DeveRetornarMarcara_AoReceberValores()
    {
        // Arrange
        var service = new PedidoService();
        // Act
        var resultado = service.GerarCodigoRastreio("SUDESTE", 0042);
        // Assert
        Assert.Equal("SUDESTE-0042", resultado);
    }
    [Fact]
    public void CalcularPontosFidelidade_DeveCalcular_OsPontosGeradosNaCompra()
    {
        // Arrange
        var service = new PedidoService();
        // Act
        var resultado = service.CalcularPontosFidelidade(150);
        // Assert
        Assert.Equal(30, resultado);
    }    
    [Theory]
    [InlineData(210, true)]    
    [InlineData(100, true)]    
    public void TemDireitoAFreteGratis_DeveValidar_DisponibilidadeDeFreteGratis(int valorTotal, bool isClienteVIP)
    {
        // Arrange
        var service = new PedidoService();
        // Act
        var resultado = service.TemDireitoAFreteGratis(valorTotal, isClienteVIP);
        // Assert
        Assert.True(resultado);
    }
    [Theory]
    [InlineData(150, false)]    
    public void TemDireitoAFreteGratis_DeveInvalidar_DisponibilidadeDeFreteGratis(int valorTotal, bool isClienteVIP)
    {
        // Arrange
        var service = new PedidoService();
        // Act
        var resultado = service.TemDireitoAFreteGratis(valorTotal, isClienteVIP);
        // Assert
        Assert.False(resultado);
    }
}
