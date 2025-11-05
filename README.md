# ExcelToXML2

## Visão geral
Este repositório contém um conversor desktop que transforma planilhas Excel padronizadas em arquivos XML de comandos de pagamento. O aplicativo foi criado para ambiente Windows e distribuído via instalador **ClickOnce**, permitindo que os usuários selecionem uma planilha de entrada, validem dados básicos e gerem o XML no formato esperado pelo sistema de destino.

## Conteúdo do repositório
- `src/ExcelToXml.sln`: solução Visual Studio reorganizada contendo o projeto WinForms recomposto a partir do executável distribuído.
- `src/ExcelXML/`: código-fonte completo da aplicação WinForms convertida para C#.
- `Aplicação BB/ExcelParaXml/`: distribuição do aplicativo Windows (instalador `setup.exe` e pasta `Application Files`).
- `Aplicação BB/LEIAME.txt`: instruções originais fornecidas com o instalador, incluindo dicas de uso e organização de pastas.
- `dados/xls/`: exemplos de planilhas de entrada (`exemplo1.xlsx`, `exemplo2.xlsx`, `planilha dados.xlsx`) e um XML de referência (`resultado.txt`).

## Solução Visual Studio reconstruída
A pasta `src/` reúne a nova solução WinForms (`ExcelToXml.sln`) criada após a engenharia reversa do executável ClickOnce. O formulário principal (`frmPrincipal`) foi redesenhado com os campos de metadados (`Sistema`, `Trigrama`, `Perfil`, `CPF`, datas de geração/remessa) e com a contagem dinâmica de registros carregados, seguindo o comportamento observado no binário distribuído. Os recursos incorporados (ícone, strings e configurações) foram extraídos dos binários distribuídos e convertidos para arquivos `.resx` compatíveis com o Visual Studio.【F:src/ExcelXML/frmPrincipal.Designer.cs†L1-L248】【F:src/ExcelXML/Properties/Resources.resx†L1-L77】

### Estrutura do projeto
- `Program.cs`: inicializa a aplicação com `Application.Run(new frmPrincipal())`.
- `frmPrincipal.*`: contém a lógica da interface e o layout que permite selecionar planilhas, configurar metadados e acionar a conversão, além de validar CPF e exibir a quantidade de comandos carregados.【F:src/ExcelXML/frmPrincipal.cs†L1-L160】【F:src/ExcelXML/frmPrincipal.Designer.cs†L1-L248】
- `Models/ComandoPagamento.cs`: modelo imutável que representa cada linha válida extraída da planilha.【F:src/ExcelXML/Models/ComandoPagamento.cs†L1-L63】
- `Services/ExcelWorksheetLoader.cs`: provê leitura via OLE DB da primeira planilha disponível.【F:src/ExcelXML/Services/ExcelWorksheetLoader.cs†L1-L77】
- `Services/ComandoPagamentoParser.cs`: valida a presença dos cabeçalhos obrigatórios e converte linhas em objetos `ComandoPagamento`.【F:src/ExcelXML/Services/ComandoPagamentoParser.cs†L1-L92】
- `Services/XmlExportService.cs`: gera o XML `ArquivoComandosPagamento` com metadados, agrupamento por trigrama e contagem total de registros.【F:src/ExcelXML/Services/XmlExportService.cs†L1-L103】
- `Utilities/CpfValidator.cs`: implementa a validação de dígitos verificadores do CPF antes da exportação.【F:src/ExcelXML/Utilities/CpfValidator.cs†L1-L39】
- `Properties/`: metadados de assembly e configurações prontas para uso no Visual Studio.【F:src/ExcelXML/Properties/AssemblyInfo.cs†L1-L36】【F:src/ExcelXML/Properties/Settings.settings†L1-L7】

### Como compilar
1. Abra `src/ExcelToXml.sln` no Visual Studio 2022 ou superior.
2. Restaure as referências padrão do .NET Framework 4.7.2 (não há pacotes NuGet externos).
3. Compile em `Debug|Any CPU` para gerar `ExcelXML.exe` em `bin/Debug`.
4. Opcionalmente, execute o aplicativo e valide os formulários comparando com a versão instalada a partir de `Aplicação BB/ExcelParaXml/`.

### Validação manual
A interface recomposta mantém os campos exigidos pelo fluxo original (identificação do responsável, códigos de perfil, NIP, folha, PAPEM e datas de geração/remessa) e apresenta a contagem de registros válidos logo abaixo dos metadados. Recomenda-se comparar o layout gerado no Visual Studio com a aplicação instalada para ajustar espaçamentos ou textos que dependam de métricas do Windows original.【F:src/ExcelXML/frmPrincipal.Designer.cs†L35-L248】

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
3. Preencha manualmente os metadados exigidos (responsável, CPF, códigos de perfil, NIP, folha e PAPEM) e confirme as datas de geração/remessa sugeridas automaticamente.【F:src/ExcelXML/frmPrincipal.Designer.cs†L107-L205】
4. Revise o processo de pagamento exibido na tela, garantindo que rubricas, tipos e valores estejam corretos na planilha carregada.【F:Aplicação BB/LEIAME.txt†L11-L11】
5. Clique em **Gerar XML** para produzir o arquivo no diretório selecionado; o aplicativo valida o CPF antes da exportação e exibe mensagem de sucesso ao concluir.【F:src/ExcelXML/frmPrincipal.cs†L70-L123】

## Resultado da conversão
O arquivo gerado segue a estrutura `<ArquivoComandosPagamento>` com uma lista de `<ComandoPagamento>` contendo os elementos apresentados na planilha (identificador, matrícula, rubrica, tipo, forma de pagamento e valor). Consulte `dados/xls/resultado.txt` para visualizar um exemplo de saída contendo dezenas de comandos exportados.【b679d8†L1-L108】

## Boas práticas
- Salve uma cópia da planilha antes da conversão para manter um histórico das alterações.
- Utilize validação no Excel (listas suspensas, formatação de números) para reduzir erros de digitação.
- Após gerar o XML, abra-o em um editor de texto para conferir se a acentuação e os valores foram mantidos conforme esperado.

## Solução de problemas
- **Erro de layout ao carregar a planilha:** confirme se os cabeçalhos não foram renomeados nem reordenados.
- **CPF inválido:** confirme se o número informado possui 11 dígitos e passa na validação interna antes de tentar gerar o XML novamente.【F:src/ExcelXML/Utilities/CpfValidator.cs†L5-L39】
- **Problemas para executar o instalador:** confirme se o .NET Framework necessário está habilitado no Windows e se você possui permissões administrativas para instalação.

Com estas instruções, é possível preparar as planilhas, instalar o aplicativo e gerar arquivos XML compatíveis com o sistema de destino de forma confiável.
