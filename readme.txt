Solução criada utilizando o Framework .NET Core 2.0

Os projetos forem divididos de acordo com a sua responsabilidade conforme segue:
	* ProcessoSeletivoModel - Modelo de dados
		Utilizado DataAnnotation para validação de campos obrigatórios		
    
	* ProcessoSeletivoDataContext - Repositório de dados
		Utilização de IoC através de StructureMap para obter instâncias do respositório.
    Utilização de InMemoryDatabase para guardar os dados sem a necessidade de bancos físicos.
		Criada uma forma de passar o Contexto via contrutor para possibilitar transações futuras, onde haverá necessidade de Commit/Rollback.
    
	* ProcessoSeletivoDataService - Camada de interação com o repositório, onde são aplicadas regras de negócio quando necessário
  
	* ProcessoSeletivoAPI - Camada API REST com os endpoints: 
		Cadastro de vagas
		Cadastro de pessoas
		Captura de ranking por vaga

O deploy foi feito utilizando Docker, e é possível capturar através do comando:
	docker pull luciorogeriosp/processoseletivoapi

Para rodar a aplicação basta definir o projeto ProcessoSeletivoAPI como padrão, e acionar os endpoints através de um programa externo como SoapUI/Postman

