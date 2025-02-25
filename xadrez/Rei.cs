using tabuleiro;

namespace xadrez
{
    internal class Rei : Peca
    {

        private PartidaDeXadrez partida;

        public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            this.partida = partida;
        }

        public override string ToString()
        {
            return "R";
        }

        private bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.Cor != Cor;
        }

        private bool testeTorreParaRoque(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p is Torre && p.Cor == Cor && p.qteMovimentos == 0;
        }

        public override bool[,] movimentoPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];


            Posicao pos = new Posicao(0, 0);

            // acima 
            pos.definirValores(Posicao.linha - 1, Posicao.coluna);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // ne
            pos.definirValores(Posicao.linha - 1, Posicao.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }


            // direita
            pos.definirValores(Posicao.linha, Posicao.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }


            // se
            pos.definirValores(Posicao.linha + 1, Posicao.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // abaixo
            pos.definirValores(Posicao.linha + 1, Posicao.coluna);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // so
            pos.definirValores(Posicao.linha + 1, Posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // esquerda
            pos.definirValores(Posicao.linha, Posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // no
            pos.definirValores(Posicao.linha - 1, Posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //#jogadaespecial roque 

            if (qteMovimentos == 0 && !partida.xeque)
            {
                //#jogadaespecial roqe pequeno
                Posicao posT1 = new Posicao(Posicao.linha, Posicao.coluna + 3);
                if (testeTorreParaRoque(posT1))
                {
                    Posicao p1 = new Posicao(Posicao.linha, Posicao.coluna + 1);
                    Posicao p2 = new Posicao(Posicao.linha, Posicao.coluna + 2);
                    if (tab.peca(p1) == null && tab.peca(p2) == null)
                    {
                        mat[Posicao.linha, Posicao.coluna + 2] = true;
                    }
                }

                //#jogadaespecial roqe grande
                Posicao posT2 = new Posicao(Posicao.linha, Posicao.coluna - 4);
                if (testeTorreParaRoque(posT2))
                {
                    Posicao p1 = new Posicao(Posicao.linha, Posicao.coluna - 1);
                    Posicao p2 = new Posicao(Posicao.linha, Posicao.coluna - 2);
                    Posicao p3 = new Posicao(Posicao.linha, Posicao.coluna - 3);
                    if (tab.peca(p1) == null && tab.peca(p2) == null && tab.peca(p3)==null)
                    {
                        mat[Posicao.linha, Posicao.coluna - 2] = true;
                    }
                }
            }
            return mat;
        }
    }
}