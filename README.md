# EcommerceCheckout

## Propósito do sistema

O EcommerceCheckout reúne regras de negócio da etapa de checkout de uma loja virtual. A classe `PedidoService` (projeto `EcommerceCheckout.App`) oferece três funcionalidades:

- **Geração de código de rastreio** (`GerarCodigoRastreio`): monta o código no formato `REGIAO-NNNN`, com o número do pedido preenchido com zeros à esquerda até quatro dígitos. Exemplo: `SUDESTE-0042`.
- **Cálculo de pontos de fidelidade** (`CalcularPontosFidelidade`): a cada 10 unidades de valor gastas, o cliente ganha 2 pontos. Valores abaixo de 10 não geram pontos. Exemplo: compra de 150 gera 30 pontos.
- **Verificação de frete grátis** (`TemDireitoAFreteGratis`): o frete é gratuito quando o valor total é maior ou igual a 200 ou quando o cliente é VIP.

## Testes unitários

Os testes ficam no projeto `EcommerceCheckout.Tests`, escritos com xUnit e seguindo o padrão Arrange/Act/Assert. Foram implementados três tipos de teste:

### 1. Teste simples com `[Fact]`

Verifica um único cenário com entrada e saída fixas. Usado em:

- `GerarCodigoRastreio_DeveRetornarMarcara_AoReceberValores`: confirma que `("SUDESTE", 42)` retorna `SUDESTE-0042`.
- `CalcularPontosFidelidade_DeveCalcular_OsPontosGeradosNaCompra`: confirma que o valor 150 retorna 30 pontos.

### 2. Teste parametrizado com `[Theory]` e `[InlineData]` (cenário positivo)

Executa o mesmo teste com vários conjuntos de dados em que o resultado esperado é verdadeiro. Usado em:

- `TemDireitoAFreteGratis_DeveValidar_DisponibilidadeDeFreteGratis`: valida o frete grátis para um pedido de 210 (acima do mínimo) e para um cliente VIP com pedido de 100.

### 3. Teste parametrizado com `[Theory]` e `[InlineData]` (cenário negativo)

Garante que a regra também recusa o benefício quando as condições não são atendidas. Usado em:

- `TemDireitoAFreteGratis_DeveInvalidar_DisponibilidadeDeFreteGratis`: valida que um pedido de 150 de cliente não VIP não tem direito a frete grátis.

## Como executar os testes

Pré-requisito: [.NET SDK](https://dotnet.microsoft.com/download) instalado. Para conferir:

```bash
dotnet --version
```

Na raiz da solução (pasta que contém os projetos `EcommerceCheckout.App` e `EcommerceCheckout.Tests`), execute:

```bash
dotnet test
```

Para rodar apenas o projeto de testes:

```bash
dotnet test EcommerceCheckout.Tests
```

Para ver o nome de cada teste executado:

```bash
dotnet test --logger "console;verbosity=detailed"
```

Ao final, o terminal exibe o resumo com o total de testes aprovados, falhos e ignorados.
