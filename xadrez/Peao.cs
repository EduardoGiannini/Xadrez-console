using System.ComponentModel.Design;
using tabuleiro;

namespace xadrez
{
    internal class Peao : Peca
    {
        private PartidaDeXadrez partida;
        public Peao(Tabuleiro tab, Cor cor,PartidaDeXadrez partida) : base(tab, cor) {
            this.partida = partida;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool existeInimigo(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p.Cor != Cor;
        }

        private bool livre(Posicao pos)
        {
            return tab.peca(pos) == null;
        }

        public override bool[,] movimentoPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];


            Posicao pos = new Posicao(0, 0);


            if (Cor == Cor.Branca)
            {
                pos.definirValores(Posicao.linha - 1, Posicao.coluna);
                if (tab.posicaoValida(pos) && livre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
            }
            pos.definirValores(Posicao.linha - 2, Posicao.coluna);
            Posicao p2 = new Posicao(Posicao.linha - 1, Posicao.coluna);
            if (tab.posicaoValida(p2) && livre(p2) && tab.posicaoValida(pos) && livre(pos) && qteMovimentos == 0)
            {
                mat[pos.linha, pos.coluna] = true;
            }
            pos.definirValores(Posicao.linha - 1, Posicao.coluna - 1);
            if (tab.posicaoValida(pos) && existeInimigo(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            pos.definirValores(Posicao.linha - 1, Posicao.coluna + 1);
            if (tab.posicaoValida(pos) && existeInimigo(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            else
            {
                pos.definirValores(Posicao.linha + 1, Posicao.coluna);
                if (tab.posicaoValida(pos) && livre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(Posicao.linha + 2, Posicao.coluna);
                Posicao p2 = new Posicao(Posicao.linha + 1, Posicao.coluna);
                if (tab.posicaoValida(p2) && livre(p2) && tab.posicaoValida(pos) && livre(pos) && qteMovimentos == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(Posicao.linha + 1, Posicao.coluna - 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(Posicao.linha + 1, Posicao.coluna + 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
            }
            return mat;
        }
    }
}