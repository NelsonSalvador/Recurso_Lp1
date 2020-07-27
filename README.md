# Projeto de Recurso da Disciplina de Linguagens de Programação 1

# Simulação de Pandemia

## Autoria

Nelson Salvador (21904295)  
Pedro Bezerra (21900974)  
Vasco Duarte (21905658)  

## [Repositório GitHub](https://github.com/NelsonSalvador/Recurso_Lp1)

## Contribuição

### Nelson Salvador

#### Class `Program`

Leitura dos argumentos da linha de comando, que foi movido para a classe 
`Properties` posteriormente

#### Class `Simulator`

Interação com a classe `UI` no `CoreLoop()`. Limpeza de código morto.

#### Class `World`

Criação inicial da classe.

#### Class `UI`

Autor da classe com ajuda do Vasco.

#### Struct `Id` (que depois vai ser classe `Agent`)

Criação da struct `Id`, que depois foi substituia pela classe `Agent`.

#### Struct `Coord`

Criação da struct.

### Pedro Bezerra

#### Class `Agent`

Responsável por toda a classe.

#### Class `Simulator`

Escrita do `CoreLoop()`

#### Class `World`

Edição e refinamento da classe e seus métodos após sua criação por Nelson.

#### Class `Properties`

Organização do código.

#### Struct `Stats`

Criação e métodos da struct, que armazenaria as estatísticas de cada turno, 
para serem usados por `UI` e `FileUpdate`. Foi removida do programa por não ser 
usada.

#### Struct `Coord`

Responsável por toda a struct.

#### Enum `Status`

Responsável por todo o Enum.

#### Enum `Direction`

Responsável por todo o Enum.

#### XML e comentários

Escrita de quase toda a documentação XML.

#### UML 

Ajuda na organização do UML.

#### Relatório

Revisão do relatório após a versão inicial pelo Vasco

### Vasco Duarte

#### Class `Simulator`

Escrita da primeira versão do `CoreLoop()`

#### Class `World`

Escrita do método de movimento, que foi substituído e colocado na classe
`Agent`.

#### Class `UI`

Participação na escrita da classe, e controle de tempo com `Thread`.

#### Class `FileUpdate`

Responsável por toda a classe.

#### Comentários

Revisão dos comentários em todo o programa.

#### Relatório

Criação da primeira versão do relatório.

## Arquitetura da Solução

### Iniciação da Simulação

Quando o programa é iniciado, a classe `Properties` é criada utilizando uma 
abordagem de _simple factory_, com o método `ReadArgs()`, para leitura dos 
argumentos da linha de comando. O programa termina nesse ponto se faltar algum 
argumento obrigatório.  
Depois disso, é criada uma instância de `Simulator`, e inicia-se o `CoreLoop()`.

### Durante a Simulação

A classe `Simulator` possui 4 listas de `Agents`, que armazenam os agentes 
saudáveis, infectados, mortos, e mortos recentemente. Cada vez que um agente 
muda de estado, este é removido da lista em que se encontra, e adicionado em 
outra.

O mundo de simulação é representado por um dicionário cujas chaves são 
`Coord`, e valores são listas de `Agent`.

O `CoreLoop()` consiste de um _loop_ que é executado enquanto ainda existem 
agentes vivos, ou não se cheogu no limite de turnos.  
  
Para cada turno executado, o método primeiro limpa a lista de mortos recentes, 
então verifica se é o turno `Tinf`, e se sim, infecta um agente aleatório.  
  
Os agentes vivos (nas listas de saudáveis e infectados) se movem no mundo de 
simulação. Durante este movimento, todas as posições que ficaram com um agente 
infectado são armazenados, em uma lista sem repetições.  
  
A seguir, o método `InfectPos(Coord)` é invocado para cada posição com 
infectados, espalhando a infecção por todos os agentes presentes nestas 
coordenadas.  
  
O programa então reduz em 1 o cotnador de vida de todos os infectados, 
alterando o estado daqueles que chegam a 0 para mortos, movendo-os para a lista 
correta, e adicionando-os na lista de mortos recentes, para serem mostrados na 
visualização, se a opcão `-v` tiver sido usada.  
  
Por fim, o programa escreve no console, com a classe `UI` e armazena os dados 
do turno, com a classe `FileUpdate`, para escrita futura no ficheiro, se 
necessário.

### Fim de simulação

Se todos os agentes estiverem mortos, ou for alcançado o último turno, 
indicado pela opção `-T`, a simulação termina. Em seguida, se a opção `-o` 
tiver sido usada, os dados da simulação são escritos no ficheiro `.tsv` 
indicado.

## UML

![Diagrama de classes](UML.png)

## Referencias

- [Zombies vs Humanos](https://github.com/VideojogosLusofona/lp1_2018_p2_solucao)
- [StreamWriter Class](https://docs.microsoft.com/en-us/dotnet/api/system.io.streamwriter?view=netcore-3.1)
- [Design Patterns: The Simple Factory Pattern](https://code.tutsplus.com/tutorials/design-patterns-the-simple-factory-pattern--cms-22345)