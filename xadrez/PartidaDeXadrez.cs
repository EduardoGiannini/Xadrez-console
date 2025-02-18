using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;
namespace xadrez
{
    internal class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas; 

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
        }

        public void executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQteMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
            if(pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }
        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            executaMovimento(origem, destino);
            turno ++;
            mudaJogador();
        }

        public void validarPosicaoDeOrigem(Posicao pos)
        {
            if(tab.peca(pos)  == null)
            {
                throw new TabuleiroExeption("Nao existe peça na posisão de origem escolhida!");
            }
            if(jogadorAtual != tab.peca(pos).Cor)
            {
                throw new TabuleiroExeption("A peça de origem escolhida não é sua!");
            }
            if (!tab.peca(pos).existeMovimentosPossiveis())
            {
                throw new TabuleiroExeption("Não há movimentos possiveis para a peça de origem escolhida!");
            }
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if(!tab.peca(origem).podeMoverPara(destino))
            {
                throw new TabuleiroExeption("Posição de destino invalida!");
            }
        }

        private void mudaJogador()
        {
            if (jogadorAtual == Cor.Branca)
            {
                if(jogadorAtual == Cor.Branca)
                {
                    jogadorAtual = Cor.Preta;
                }
                else
                {
                    jogadorAtual = Cor.Branca;
                }
            }
        }

        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas)
            {
                if(x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }

        public void colocarnovaPeca(char coluna, int linha, Peca peca)
        {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);
        }
        
        private void colocarPecas()
        {
            colocarnovaPeca('c', 1, new Torre(tab, Cor.Branca));
            colocarnovaPeca('c', 2, new Torre(tab, Cor.Branca));
            colocarnovaPeca('d', 2, new Torre(tab, Cor.Branca));
            colocarnovaPeca('e', 2, new Torre(tab, Cor.Branca));
            colocarnovaPeca('e', 1, new Torre(tab, Cor.Branca));
            colocarnovaPeca('d', 1, new Rei(tab, Cor.Branca));

            colocarnovaPeca('c', 7, new Torre(tab, Cor.Preta));
            colocarnovaPeca('c', 8, new Torre(tab, Cor.Preta));
            colocarnovaPeca('d', 7, new Torre(tab, Cor.Preta));
            colocarnovaPeca('e', 7, new Torre(tab, Cor.Preta));
            colocarnovaPeca('e', 8, new Torre(tab, Cor.Preta));
            colocarnovaPeca('d', 8, new Rei(tab, Cor.Preta));
        }
    }
}
