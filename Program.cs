try
{
    string[,] field = new string[9, 9];
    Console.Write("Введите позицию коня на доске: ");
    string h_position = Console.ReadLine();
    while (h_position.Length >= 3 || h_position.Length < 2 || h_position[0] < 49 || h_position[0] > 56 || h_position[1] < 65 || h_position[1] > 104 || (h_position[1] > 72 & h_position[1] < 97))
    {
        Console.WriteLine("Неверный формат!");
        Console.Write("Введите позицию коня на доске: ");
        h_position = Console.ReadLine();
    }
    Console.Write("Введите позицию пешки на доске: ");
    string p_position = Console.ReadLine();
    while (p_position.Length >= 3 || p_position.Length < 2 || p_position[0] < 49 || p_position[0] > 56 || p_position[1] < 65 || p_position[1] > 104 || (p_position[1] > 72 & p_position[1] < 97))
    {
        Console.WriteLine("Неверный формат!");
        Console.Write("Введите позицию пешки на доске: ");
        p_position = Console.ReadLine();
    }
    Console.Write("Введите позицию ферзя на доске: ");
    string q_position = Console.ReadLine();
    while (q_position.Length >= 3 || q_position.Length < 2 || q_position[0] < 49 || q_position[0] > 56 || q_position[1] < 65 || q_position[1] > 104 || (q_position[1] > 72 & q_position[1] < 97))
    {
        Console.WriteLine("Неверный формат!");
        Console.Write("Введите позицию ферзя на доске: ");
        q_position = Console.ReadLine();
    }
    IChessFigure horse = new Horse(h_position);
    IChessFigure pawn = new Pawn(p_position);
    IChessFigure queen = new Queen(q_position);

    horse.CheckPosition(field);
    pawn.CheckPosition(field);
    queen.CheckPosition(field);

    horse.PossibleMoves();
    pawn.PossibleMoves();
    queen.PossibleMoves();

    horse.ChessAttack(field);
    pawn.ChessAttack(field);
    queen.ChessAttack(field);

    horse.Print();
    pawn.Print();
    queen.Print();
}
catch (Exception exp)
{
    Console.WriteLine(exp.Message);
}
interface IChessFigure
{
    void CheckPosition(string[,] field);
    void PossibleMoves();
    string ChessAttack(string[,] field);
    void Print();
}
abstract class ChessFigure : IChessFigure
{
    protected string position;
    protected int line;
    protected int column;
    protected List<string> moves;
    protected string rivals;
    public virtual void CheckPosition(string[,] field)
    {
        if (position[position.Length - 1] == 'A' || position[position.Length - 1] == 'a')
        {
            string convert = position[0] + "1";
            position = convert;
        }
        if (position[position.Length - 1] == 'B' || position[position.Length - 1] == 'b')
        {
            string convert = position[0] + "2";
            position = convert;
        }
        if (position[position.Length - 1] == 'C' || position[position.Length - 1] == 'c')
        {
            string convert = position[0] + "3";
            position = convert;
        }
        if (position[position.Length - 1] == 'D' || position[position.Length - 1] == 'd')
        {
            string convert = position[0] + "4";
            position = convert;
        }
        if (position[position.Length - 1] == 'E' || position[position.Length - 1] == 'e')
        {
            string convert = position[0] + "5";
            position = convert;
        }
        if (position[position.Length - 1] == 'F' || position[position.Length - 1] == 'f')
        {
            string convert = position[0] + "6";
            position = convert;
        }
        if (position[position.Length - 1] == 'G' || position[position.Length - 1] == 'g')
        {
            string convert = position[0] + "7";
            position = convert;
        }
        if (position[position.Length - 1] == 'H' || position[position.Length - 1] == 'h')
        {
            string convert = position[0] + "8";
            position = convert;
        }
        column = int.Parse(position) % 10;
        line = (int.Parse(position) / 10) % 10;
    }
    public virtual string ChessAttack(string[,] field)
    {
        rivals = "";
        foreach (string e in moves)
        {
            column = int.Parse(e) % 10;
            line = (int.Parse(e) / 10) % 10;
            if (field[line, column] != null)
                rivals += $"{field[line, column]} ";
        }
        return rivals;
    }
    public abstract void PossibleMoves();
    public abstract void Print();
}

class Horse : ChessFigure
{
    public Horse(string position) : base()
    {
        this.position = position;
    }
    public override void CheckPosition(string[,] field)
    {
        base.CheckPosition(field);
        field[line, column] = "Horse";
    }
    public override void PossibleMoves()
    {
        moves = new List<string>();
        if ((column + 1 <= 8) && (line + 3 <= 8))
        {
            string a = (line + 3).ToString();
            a += (column + 1).ToString();
            moves.Add(a);
        }
        if ((column - 1 >= 1) && (line + 3 <= 8))
        {
            string a = (line + 3).ToString();
            a += (column - 1).ToString();
            moves.Add(a);
        }
        if ((column + 3 <= 8) && (line + 1 <= 8))
        {
            string a = (line + 1).ToString();
            a += (column + 3).ToString();
            moves.Add(a);
        }
        if ((column - 3 >= 1) && (line + 1 <= 8))
        {
            string a = (line + 1).ToString();
            a += (column - 3).ToString();
            moves.Add(a);
        }
        if ((column + 1 <= 8) && (line - 3 >= 1))
        {
            string a = (line - 3).ToString();
            a += (column + 1).ToString();
            moves.Add(a);
        }
        if ((column - 1 >= 1) && (line - 3 >= 1))
        {
            string a = (line - 3).ToString();
            a += (column - 1).ToString();
            moves.Add(a);
        }
        if ((column + 3 <= 8) && (line - 1 >= 1))
        {
            string a = (line - 1).ToString();
            a += (column + 3).ToString();
            moves.Add(a);
        }
        if ((column - 3 >= 1) && (line - 1 >= 1))
        {
            string a = (line - 1).ToString();
            a += (column - 3).ToString();
            moves.Add(a);
        }
    }
    public override void Print()
    {
        Console.WriteLine($"Могу срубить: {rivals}");
    }
}

class Pawn : ChessFigure
{
    public Pawn(string position) : base()
    {
        this.position = position;
    }
    public override void CheckPosition(string[,] field)
    {
        base.CheckPosition(field);
        field[line, column] = "Pawn";
    }
    public override void PossibleMoves()
    {
        moves = new List<string>();
        if ((column + 1 <= 8) && (line + 1 <= 8))
        {
            string a = (line + 1).ToString();
            a += (column + 1).ToString();
            moves.Add(a);
        }
        if ((column - 1 >= 1) && (line + 1 <= 8))
        {
            string a = (line + 1).ToString();
            a += (column - 1).ToString();
            moves.Add(a);
        }
    }
    public override void Print()
    {
        Console.WriteLine($"Могу срубить: {rivals}");
    }
}

class Queen : ChessFigure
{
    public Queen(string position) : base()
    {
        this.position = position;
    }
    public override void CheckPosition(string[,] field)
    {
        base.CheckPosition(field);
        field[line, column] = "Queen";
    }
    public override void PossibleMoves()
    {
        moves = new List<string>();
        int cline = line, ccolumn = column;
        for (int i = 1; (line + i) <= 8; i++)
        {
            string a = (line + i).ToString();
            a += column.ToString();
            moves.Add(a);
        }
        for (int i = 1; (line - i) >= 1; i++)
        {
            string a = (line - i).ToString();
            a += column.ToString();
            moves.Add(a);
        }
        for (int j = 1; (column + j) <= 8; j++)
        {
            string a = line.ToString();
            a += (column + j).ToString();
            moves.Add(a);
        }
        for (int j = 1; (column - j) >= 1; j++)
        {
            string a = line.ToString();
            a += (column - j).ToString();
            moves.Add(a);
        }
        while ((column < 8) && (line < 8))
        {
            string a = (line + 1).ToString();
            a += (column + 1).ToString();
            moves.Add(a);
            line++; column++;
        }
        line = cline; column = ccolumn;
        while ((column > 1) && (line > 1))
        {
            string a = (line - 1).ToString();
            a += (column - 1).ToString();
            moves.Add(a);
            line--; column--;
        }
        line = cline; column = ccolumn;
        while ((column > 1) && (line < 8))
        {
            string a = (line + 1).ToString();
            a += (column - 1).ToString();
            moves.Add(a);
            line++; column--;
        }
        line = cline; column = ccolumn;
        while ((column < 8) && (line > 1))
        {
            string a = (line - 1).ToString();
            a += (column + 1).ToString();
            moves.Add(a);
            line--; column++;
        }
    }
    public override void Print()
    {
        Console.WriteLine($"Могу срубить: {rivals}");
    }
}