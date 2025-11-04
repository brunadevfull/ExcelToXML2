# Fluxo do conversor Excel → XML (versão desktop) e implicações para a versão web

## 1. Layout das planilhas de entrada
Os modelos `exemplo1.xlsx` e `exemplo2.xlsx` possuem apenas uma aba chamada `sheet1` com linha de cabeçalho e linhas vazias para preenchimento manual. Não há regras de validação embarcadas (listas suspensas ou restrições de célula) — todos os campos ficam em branco aguardando digitação do usuário.【014d6f†L1-L12】

### Campos comuns (`exemplo1.xlsx`)
| Coluna | Tipo esperado | Observações |
| --- | --- | --- |
| `identificador` | Inteiro sequencial | Referenciado como `<identificador>` no XML de saída para numerar cada comando.【014d6f†L1-L5】【1c3fc8†L16-L84】 |
| `matricula` | Cadeia numérica | Código de matrícula usado em `<matricula>`. Mantém zeros à esquerda, portanto tratar como texto numérico.【014d6f†L1-L5】【1c3fc8†L16-L84】 |
| `alterador` | Texto curto (1 caractere) | Indica a ação (`I` na amostra).【014d6f†L1-L5】【1c3fc8†L16-L84】 |
| `rubrica` | Cadeia numérica | Código de rubrica de pagamento/desconto.【014d6f†L1-L5】【1c3fc8†L16-L84】 |
| `tpRubrica` | Texto curto (2 caracteres) | Classifica a rubrica (`NO`, `DE`, etc.).【014d6f†L1-L5】【1c3fc8†L16-L84】 |
| `formPagto` | Texto curto (2 caracteres) | Forma de pagamento (`AV` nos exemplos).【014d6f†L1-L5】【1c3fc8†L16-L84】 |
| `valComando` | Decimal com duas casas | Valor monetário exportado como `<valComando>` usando ponto como separador decimal.【014d6f†L1-L5】【1c3fc8†L16-L84】 |

### Campos adicionais (`exemplo2.xlsx`)
O segundo modelo replica as colunas acima e acrescenta:

| Coluna | Tipo esperado | Observações |
| --- | --- | --- |
| `frequencia` | Texto curto | Indica periodicidade do comando; o arquivo de exemplo está vazio, sugerindo preenchimento opcional.【014d6f†L7-L12】 |
| `parcelas` | Inteiro | Número de parcelas associadas; igualmente vazio no modelo-base.【014d6f†L7-L12】 |

Esses campos extras não aparecem na amostra de XML fornecida, indicando lógica condicional no aplicativo (incluir apenas quando preenchidos).

## 2. Recursos e mapeamentos embutidos no instalador ClickOnce
O pacote ClickOnce distribui apenas o executável `ExcelXML.exe.deploy`, o manifesto e o arquivo de configuração mínimo. A inspeção por *strings* Unicode revela:

- Campos de cabeçalho do XML e controles da interface: `sistema`, `dtGeracao`, `dtRemessa`, `nome`, `perfil`, `tipoPerfilOM`, `codPapem`, `qtdeTotal`, `folha`, `txtCodPapem`, `txtSistema`, `txtFolha`, `txtPerfil`, `txtPerfilOM`, `txtTrigrama`, `txtCPF`, `txtNomeResponsavel`. Esses nomes apontam para entradas de formulário que alimentam os nós superiores do XML.【973116†L6-L29】【d39286†L1-L10】【26ff5a†L1-L2】【db43bd†L1-L4】【f67618†L1-L4】
- Elementos hierárquicos da saída XML já codificados dentro do binário: `ArquivoComandosPagamento`, `listaTrigrama`, `ComandoPagamento`. Isso indica que a estrutura do documento é fixa no código da aplicação.【0a4a3c†L1-L3】
- Strings de interface orientando o usuário: “Selecione o arquivo Excel”, “Selecione arquivo Excel:”.【935197†L1-L2】
- Uso explícito de `GetOleDbSchemaTable`, sugerindo leitura via OLE DB/ACE e validação do layout das colunas na planilha.【948d4e†L1-L3】
- Função `ValidaCPF`, evidenciando checagem de CPF antes da geração do XML.【266802†L1-L4】
- Indicação de que o arquivo resultante é gravado em `ISO-8859-1` (string literal presente no executável).【fee9da†L6-L12】

Nenhum arquivo de configuração separado lista os mapeamentos; eles estão embutidos na própria aplicação .NET (assemblies `ExcelXML` e `ExcelXML.frmPrincipal` presentes como *resources* dentro do executável).【5cd15c†L1-L10】

## 3. Fluxo funcional atual (desktop) → referência para a versão web
1. **Seleção de planilha** – o usuário escolhe manualmente o arquivo Excel por meio da interface (“Selecione o arquivo Excel”). O aplicativo usa OLE DB para ler o schema e garantir que os cabeçalhos esperados estejam presentes.【935197†L1-L2】【948d4e†L1-L3】【014d6f†L1-L12】
2. **Preenchimento de metadados** – campos de topo do XML (sistema, datas, responsável, CPF, perfil, tipo de OM, NIP, código PAPEM, folha, qtde total, trigramas) são digitados ou selecionados nos controles identificados (`txtSistema`, `txtCPF`, `cmbNomeResp`, etc.).【973116†L6-L29】【d39286†L1-L10】【db43bd†L1-L4】【f67618†L1-L4】
3. **Validação preliminar** – antes da conversão, a aplicação executa validações básicas: formato do CPF (`ValidaCPF`) e, implicitamente, checagem de schema/colunas por meio da consulta OLE DB. Eventuais campos vazios permanecem para tratamento manual, pois não há validação nas planilhas de origem.【266802†L1-L4】【948d4e†L1-L3】【014d6f†L1-L12】
4. **Montagem dos comandos** – cada linha preenchida no Excel vira um `<ComandoPagamento>` dentro de `<listaComandosPagamento>`, replicando exatamente os cabeçalhos da planilha (e, no layout estendido, adicionando frequência/parcelas quando disponíveis).【0a4a3c†L1-L3】【1c3fc8†L16-L84】
5. **Composição do cabeçalho** – os metadados digitados populam os nós superiores (`<ArquivoComandosPagamento>` com sistema, datas, nome, CPF, perfil, tipoPerfilOM, NIP, codPapem, qtdeTotal, folha e agrupamento por `<listaTrigrama>`).【1c3fc8†L1-L15】【f67618†L1-L4】
6. **Geração e salvamento** – o XML é serializado em ISO-8859-1 e gravado com o nome informado (`txtNomeArquivoXML`). A contagem de registros (`qtdeTotal`) deve refletir o número de comandos exportados.【fee9da†L6-L12】【1c3fc8†L1-L84】

### Implicações para a versão web
- **Front-end**: deve reproduzir os mesmos campos de entrada (metadados + upload da planilha) e aplicar validações equivalentes (CPF, obrigatoriedade dos metadados, consistência dos cabeçalhos).
- **Back-end**: precisa ler planilhas XLS/XLSX, verificar cabeçalhos, construir a lista de comandos, preencher trigramas e metadados, e serializar o XML exatamente na estrutura identificada.
- **Compatibilidade**: manter codificação ISO-8859-1 para aderir ao padrão existente, a menos que o consumidor aceite UTF-8.
- **Extensibilidade**: suportar o layout estendido com `frequencia` e `parcelas`, omitindo os nós correspondentes quando vazios (comportamento inferido pelos modelos).
