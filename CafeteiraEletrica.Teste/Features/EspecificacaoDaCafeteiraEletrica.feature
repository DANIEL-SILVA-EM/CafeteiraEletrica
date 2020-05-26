# language: pt-BR

Funcionalidade: Especificação da cafeteira eletrica

Cenário: O preparo de café e iniciado com falha
	Dado uma fonte de água quente
	E que a fonte não contém água
	Dado um recipiente de contenção
	E que o recipiente não esteja acoplado
	Dada um interface de usuario 
	E precionado o botão de inicio 
	Quando iniciado o preparo do café
	Então o preparo do café não e iniciado

Cenário: O preparo do café e iniciado
	Dado uma fonte de água quente
	E que a fonte contém água
	Dado um recipiente de contenção
	E que o recipiente esteja acoplado
	Dada um interface de usuario 
	E precionado o botão de inicio 
	Quando iniciado o preparo do café
	Então o preparo do café e iniciado

Cenário: Extração do recipiente de conteção
	Dado que o preparo do café foi iniciado
	Quando o recipiente de conteção e extraido
	Então o preparo do café e interrompido

Cenário: Devolução do recipiente de conteção
	Dado o preparo do café e interrompido
	Quando o recipiente de conteção e devolvido
	Então o preparo do café e retomado

Cenário: Preparado e pronto para consumo
	Dado que o preparo do café foi iniciado
	Quando comcluido o preparo do café
	Então o café está pronto para o consumo
	E mantido aquecido até ser consumo por completo

Cenário: O café é consumido por completo
	Dado o café pronto para consumo
	Quando identificado o consumido completo
	Então o ciclo de preparo e finalizado

Cenário: Enquanto não consumido por completo
	Dado o café pronto para consumo
	Quando identificado que ainda não foi consumido por completo
	Então mantido aquecido até ser consumo por completo