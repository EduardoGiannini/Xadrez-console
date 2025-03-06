Xadrez-Console Game

Este é um jogo de xadrez desenvolvido em C# que roda no console. O projeto implementa as regras oficiais do xadrez e permite que dois jogadores joguem entre si de forma interativa.

Tecnologias Utilizadas

Linguagem: C#

Ambiente: Console

Paradigma: Programação Orientada a Objetos (POO)

Funcionalidades

Tabuleiro exibido no console.

Movimentação válida das peças seguindo as regras oficiais do xadrez.

Detecção de xeque e xeque-mate.

Troca de turnos entre os jogadores.

Indicação de jogadas inválidas.

Sistema de captura de peças.

Como Executar

Certifique-se de ter o .NET SDK instalado na sua máquina.

Clone este repositório:

git clone https://github.com/EduardoGiannini/Xadrez-console.git

Acesse a pasta do projeto:

cd Xadres-console

Compile e execute o programa:

dotnet run

Controles do Jogo

O jogo solicitará a entrada do jogador informando a peça e o destino no formato colunaLinha -> colunaLinha (exemplo: e2 -> e4).

Caso a jogada seja inválida, o sistema informará e pedirá uma nova entrada.

O jogo continuará até que haja um xeque-mate ou empate.

Licença

Este projeto está licenciado sob a MIT License.

Desenvolvido por Eduardo Giannini.