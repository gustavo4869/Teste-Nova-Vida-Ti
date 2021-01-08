# Teste-Nova-Vida-Ti

Itens Propostos
- A página inicial deve exibir a lista de professores da instituição; OK
- Na lista de professores, disponibilizar opção para visualização da "lista de alunos" associadas ao professor (a lista deve ser uma página diferente); OK
- A página inicial deve exibir uma opção para cadastrar, somente inclusão, professores (essa operação deverá ser realizada em outra página); OK
- As páginas de cadastro de professores e lista de alunos deverão ter opção para que o usuário retorne à página inicial; OK
- A página da "lista de alunos" deverá permitir que novos alunos sejam cadastrados a partir da importação de um arquivo texto no padrão: OK
    NomeAluno||ValorMensalidade||DataVencimento   
- A página da "lista de alunos" deverá permitir a exlusão de alunos cadastrados, porém, o sistema não deverá recarregar a página ao realizar a exclusão do aluno, ou seja, o registro do aluno deverá sumir da tela após emissão do comando; OK
- A página da "lista de alunos" deverá exibir os alunos cadastrados - campos: "Nome", "Mensalidade" (formato R$ 0,00) e "Data de Vencimento" (formato DD/MM/AAAA) - e o nome do professor; OK

- Ao importar a lista de alunos, para um professor específico, o sistema deverá bloquear a importação por um período de tempo definido no arquivo de configuração appsettings.json (a configuração do banco de dados também deverá estar configurada neste arquivo); -NOK
