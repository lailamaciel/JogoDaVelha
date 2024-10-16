using System.Diagnostics;

class JogoDaVelha
{

    //Váriaveis do tabuleiro
    static char p1 = '1', p2 = '2', p3 = '3', p4 = '4', p5 = '5',
                p6 = '6', p7 = '7', p8 = '8', p9 = '9';
    static void Main()
    {
        // Recebe os nomes dos jogadores:
        Console.Write("Insira o nome do jogador 1 (X): ");//Saída de dados
        string jogador1 = Console.ReadLine();//Entrada de dados

        Console.Write("Insira o nome do jogador 2 (O): ");
        string jogador2 = Console.ReadLine();

        //Váriaveis de controle:
        Boolean fimDeJogo = false; //Váriavel para o laço de repetição
        int jogadas = 1;
        char jogadorAtual = 'X'; //Váriavel para ajudar o laço de operador ternário (?:)

        //Operador de negação (!) porque só entra True no laço
        while (!fimDeJogo && jogadas <= 9)
        {

            Console.Clear(); //Limpa o tabuleiro
            Tabuleiro(); //Chama a função e imprime o tabuleiro

            //Operador ternário ?: (Ex.: se tal coisa for verdadeira ? essa opção : senão essa)
            Console.WriteLine($"{(jogadorAtual == 'X' ? jogador1 : jogador2)}, escolha sua posição: ");
            string jogada = Console.ReadLine();

            // Atualiza a posição escolhida
            if (!AtualizaTabuleiro(jogada, jogadorAtual))
            {
                Console.WriteLine("Posição inválida! Pressione Enter para tentar novamente.");
                Console.ReadLine();
                continue; // Repete o loop caso a posição seja inválida
            }

            //Verifica se houve vencedor e encerra o jogo
            if (VerificarVencedor())
            {
                fimDeJogo = true;
                Console.Clear();
                Tabuleiro();
                Console.WriteLine($"{(jogadorAtual == 'X' ? jogador1 : jogador2)} venceu o jogo!");//Mostra quem é o vencedor
            }
            //Verifica o número de jogadas e encerra o jogo
            else if (jogadas == 9)
            {
                fimDeJogo = true;
                Console.Clear();
                Tabuleiro();
                Console.WriteLine("O jogo terminou em empate!");
            }

            //Troca o jogador atual e aumenta o número de jogadas
            jogadorAtual = (jogadorAtual == 'X') ? 'O' : 'X';
            jogadas++;

        }

    }
    //Funçao que exibe o tabuleiro 
    static void Tabuleiro()
    {
        Console.WriteLine("  {0}  |  {1}  |  {2}  ", p1, p2, p3);
        Console.WriteLine("-----|-----|-----");
        Console.WriteLine("  {0}  |  {1}  |  {2}  ", p4, p5, p6);
        Console.WriteLine("-----|-----|-----");
        Console.WriteLine("  {0}  |  {1}  |  {2}  ", p7, p8, p9);
    }


    // Função para atualizar o tabuleiro
    static bool AtualizaTabuleiro(string entrada, char jogador)
    {
        //Subistitue a posição do tabuleiro em "X" ou "O"
        switch (entrada)
        {
            case "1":
                if (p1 == '1') { p1 = jogador; return true; }
                break;
            case "2":
                if (p2 == '2') { p2 = jogador; return true; }
                break;
            case "3":
                if (p3 == '3') { p3 = jogador; return true; }
                break;
            case "4":
                if (p4 == '4') { p4 = jogador; return true; }
                break;
            case "5":
                if (p5 == '5') { p5 = jogador; return true; }
                break;
            case "6":
                if (p6 == '6') { p6 = jogador; return true; }
                break;
            case "7":
                if (p7 == '7') { p7 = jogador; return true; }
                break;
            case "8":
                if (p8 == '8') { p8 = jogador; return true; }
                break;
            case "9":
                if (p9 == '9') { p9 = jogador; return true; }
                break;
        }
        return false;
    }

    //Função que verifica se houve vencedor
    static bool VerificarVencedor()
    {
        // Verifica combinações vencedoras
        if ((p1 == p2 && p2 == p3) || // Linha superior
            (p4 == p5 && p5 == p6) || // Linha do meio
            (p7 == p8 && p8 == p9) || // Linha inferior
            (p1 == p4 && p4 == p7) || // Coluna esquerda
            (p2 == p5 && p5 == p8) || // Coluna do meio
            (p3 == p6 && p6 == p9) || // Coluna direita
            (p1 == p5 && p5 == p9) || // Diagonal principal
            (p3 == p5 && p5 == p7))   // Diagonal secundária
        {
            return true;
        }
        // Retorna falso se não houver vencedor
        return false;
    }
}