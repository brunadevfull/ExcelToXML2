# ExcelToXML2

## Visão geral
Este repositório contém um conversor desktop que transforma planilhas Excel padronizadas em arquivos XML de comandos de pagamento. O aplicativo foi criado para ambiente Windows e distribuído via instalador **ClickOnce**, permitindo que os usuários selecionem uma planilha de entrada, validem dados básicos e gerem o XML no formato esperado pelo sistema de destino.

## Conteúdo do repositório
- `Aplicação BB/ExcelParaXml/`: distribuição do aplicativo Windows (instalador `setup.exe` e pasta `Application Files`).
- `Aplicação BB/LEIAME.txt`: instruções originais fornecidas com o instalador, incluindo dicas de uso e organização de pastas.
- `dados/xls/`: exemplos de planilhas de entrada (`exemplo1.xlsx`, `exemplo2.xlsx`, `planilha dados.xlsx`) e um XML de referência (`resultado.txt`).

## Pré-requisitos
- Sistema operacional Windows com suporte a aplicativos ClickOnce (.NET Framework).
- Microsoft Excel (ou editor compatível) para editar as planilhas de entrada no layout fornecido.
- Permissão para gravar arquivos XML no diretório escolhido pelo usuário.

## Preparação do ambiente
1. Copie a pasta `dados` para um diretório de sua preferência (por exemplo, `C:\dados`). O aplicativo aceita qualquer caminho; a sugestão é apenas organizacional.【F:Aplicação BB/LEIAME.txt†L3-L4】
2. Utilize um dos modelos em `dados/xls/` como base para montar as informações que serão convertidas. O programa espera exatamente esse layout; alterações de estrutura provocarão erros de importação.【F:Aplicação BB/LEIAME.txt†L8-L8】【e85736†L1-L29】

## Estrutura da planilha de entrada
A planilha deve possuir, na primeira linha, os seguintes cabeçalhos (uma coluna para cada campo):

| Coluna        | Descrição                                                                 |
|---------------|----------------------------------------------------------------------------|
| `identificador` | Código sequencial do comando de pagamento.                                |
| `matricula`      | Matrícula do colaborador associado ao comando.                            |
| `alterador`      | Indicador de inclusão/alteração (por exemplo, `I` para inclusão).         |
| `rubrica`        | Código da rubrica que receberá o pagamento.                               |
| `tpRubrica`      | Tipo de rubrica (ex.: `NO` para proventos, `DE` para descontos).          |
| `formPagto`      | Forma de pagamento (`AV`, `CC`, etc.), conforme aceito pelo sistema alvo. |
| `valComando`     | Valor monetário enviado para a rubrica.                                   |

Cada linha abaixo dos cabeçalhos representa um comando individual. Evite linhas em branco no meio dos dados para prevenir mensagens de validação.

## Instalação do aplicativo
1. Navegue até `Aplicação BB/ExcelParaXml/`.
2. Execute `setup.exe` e avance com o assistente de instalação (`Next` → `Next` → `Finish`).【F:Aplicação BB/LEIAME.txt†L6-L6】
3. Após a instalação, abra o atalho criado no menu Iniciar para iniciar o conversor.

## Uso do conversor
1. Inicie o aplicativo e selecione a planilha Excel a ser convertida. Utilize sempre o modelo fornecido para evitar incompatibilidades.【F:Aplicação BB/LEIAME.txt†L8-L8】
2. Informe o nome do arquivo XML de saída (por exemplo, `comandos.xml`).【F:Aplicação BB/LEIAME.txt†L9-L9】
3. Escolha o responsável apropriado na lista. Responsáveis previamente cadastrados têm seus dados preenchidos automaticamente.【F:Aplicação BB/LEIAME.txt†L10-L10】
4. Revise o processo de pagamento exibido na tela, garantindo que rubricas, tipos e valores estejam corretos.【F:Aplicação BB/LEIAME.txt†L11-L11】
5. Clique em **Converter** para gerar o arquivo XML no diretório selecionado.【F:Aplicação BB/LEIAME.txt†L12-L12】

## Resultado da conversão
O arquivo gerado segue a estrutura `<ArquivoComandosPagamento>` com uma lista de `<ComandoPagamento>` contendo os elementos apresentados na planilha (identificador, matrícula, rubrica, tipo, forma de pagamento e valor). Consulte `dados/xls/resultado.txt` para visualizar um exemplo de saída contendo dezenas de comandos exportados.【b679d8†L1-L108】

## Boas práticas
- Salve uma cópia da planilha antes da conversão para manter um histórico das alterações.
- Utilize validação no Excel (listas suspensas, formatação de números) para reduzir erros de digitação.
- Após gerar o XML, abra-o em um editor de texto para conferir se a acentuação e os valores foram mantidos conforme esperado.

## Solução de problemas
- **Erro de layout ao carregar a planilha:** confirme se os cabeçalhos não foram renomeados nem reordenados.
- **Dados de responsável não preenchidos automaticamente:** verifique se o responsável está cadastrado no aplicativo; caso contrário, preencha manualmente as informações exigidas.
- **Problemas para executar o instalador:** confirme se o .NET Framework necessário está habilitado no Windows e se você possui permissões administrativas para instalação.

Com estas instruções, é possível preparar as planilhas, instalar o aplicativo e gerar arquivos XML compatíveis com o sistema de destino de forma confiável.
