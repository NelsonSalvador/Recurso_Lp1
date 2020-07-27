# Projeto de Recurso da Disciplina de Linguagens de Programação 1

# Simulação de Pandemia

## Autoria

### Nelson Salvador (21904295)

#### Class `Program`

Criador da class. Fez que os argumentos do utilizador sejam lidos nessa parte 
do programa.

#### Class `Simulator`

Criador da class. Preparo o tereno para ter o `UI` ao fin do `CoreLoop()`.
Também limpo o código antigo criado pelo o Vasco.

#### Class `World`

Criador da class. Ele fez a ideia inicial do World, que depois fui modificada
pelo o Pedro.

#### Class `UI`

Criador da class. Fez tudo no UI com um pouco de ajuda do Vasco.

#### Struct `Id` (que depois vai ser Class `Agent`)

Criador da struct. Fez tudo no `Id`, mas depois vai ser trocado pelo a class
`Agent` do Pedro.

#### Struct `Coords`

Criador da struct. Fez tudo no Coords mas depois é trocado pelo a struct
`Coord` do Pedro.

### Pedro Bezerra (21900974)

#### Class `Agent`

Criador e fez tudo.

#### Class `Simulator`

Modifica o `CoreLoop()` da simulação.

#### Class `World`

Modifico o World todo depois da sua criação, removendo métodos `Movimento()`
e metendo todas a novos métodos.

#### Class `Properties`

Criador e se baseo muito no codico no Program do Nelson (que depuis fui removido
do Program).

#### Struct `Stats`

Criador da struct. Fez tudo nessa struct mas depois fui removida pelo Nelson
porque não era utilizada no programa.

#### Struct `Coord`

Criador e fez tudo.

#### Enum `Status`

Criador e fez tudo.

#### Enum `Direction`

Criador e fez tudo.

#### XML e comentários

Documento o código e meteu alguns comentários no seu código.

#### UML 

Ajodo o Vasco na organização do UML.

### Vasco Duarte (21905658)

#### Class `Simulator`

Trabalho originalmente no simulador para o `CoreLoop()`.
Fui modificado mais tarde pelo o Pedro.

#### Class `World`

Crio o methodo `Movimento()` para o movimento dos personagens.
Fui removido pelo o Pedro.

#### Class `UI`

Ajudo o Nelson em algumas partes e meteu o timing com o `Thread`.

#### Class `FileUpdate`

Criador e fez tudo.

#### Comentarios

Completo a comentação do código.

#### Relatório

Escreveu o relatório tudo.

### [Repositório GitHub](https://github.com/NelsonSalvador/Recurso_Lp1)

## Arquitetura da Solução

### Iniciação da Simulação

Quando o programa é iniciado, a classe `Properties` é iniciado com o metodo
`ReadArgs()`, que vai ler os argumentos do utilizador. O programa para com uma
massagem de erro se não tiver pelo o menos os argumentos obrigatórios.

Depois disso, o simulador é criado com os argumentos do utilizador e começa com
o método `CoreLoop()`.

### Durante a Simulação

Agora a simulação começa, vendo sempre em primeiro se o programa para ou nao o 
começo de cada turno. 

Se a simulação continua, em primeiro, o programa vai tirar os mortos recentes
mete-los na lista de mortos e  vê se é preciso infetar alguém neste turno 
aleatoriamente com o `InfectPos()`. 

Cada agente, infetado ou não, se move a seguir no espaço criado com um dicionário 
no world de um espaço. Depois disso, os infetados vão infetar os agentes 
não-infetados com o método `InfectPos()`, que modifica o status para infetado de 
cada agente nessa posição. 

Depois do movimento e da infeção, o programa vai reduzir o tempo de vida de cada
infetado de um, metendo na lista de mortes recentes aqueles que passaram a 0.

Au final, agora com todo feito, o código guarda os dados atualizados e os guarda
para meter no ficheiro se a opção fui escolhido.

### UI

Com o turno terminado, o programa vai presentar a estáticas deste turno o utilizador.
Se o utilizador escolheu a opção de ter uma apresentação visual da simulação, então
o world vai ser desenhado, revelando a posição dos recentes mortos, infetados e
não-infetados.

### Fim de simulação

Se todos os agentes morrem ou então fui o ultimo turno, a simulação se termina.
Se a opção de ter o ficheiro fui escolhida, então o utilizador vai ter os dados
da simulação num ficheiro .tsv .

### UML

![](https://cdn.discordapp.com/attachments/408661070975074304/737090790328893480/UML_LP1_Recurso.png)

## Referencias

Muito da inspiração do código vem das aulas de LP1 e dos projeto 3 dos nossos antigos 
grupos. Tambem, para a criação do ficheiro com `StreamWriter`, utilizamos o site da 
Microsoft .NET API neste [link][link1].

[link1]:https://docs.microsoft.com/en-us/dotnet/api/system.io.streamwriter?view=netcore-3.1
