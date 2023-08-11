namespace CSharpPractice.Class01;

public class OperatorOverloading {
    
    public static void OperatorOverloadingMain()
    {
        Player player1 = new Player();
        Player player2 = new Player();

        player1.Level = 10;
        player2.Level = 10;
        player1.Name = "Bob";
        player2.Name = "Bob";

        Console.WriteLine("-----------------Equals重写-----------------");
        Console.WriteLine(player1.Equals(player2));
        
        player2.Name = "Jack";
        
        Console.WriteLine(player1.Equals(player2));
        
        player2.Name = "Bob";
        
        Console.WriteLine(player1.Equals(player2));
        Console.WriteLine("-----------------运算符重载-----------------");
        Console.WriteLine(player1 == player2);
        Console.WriteLine(player1 != player2);

        player2.Level = 11;
        player2.Name = "John";

        Console.WriteLine(player1+player2);

        int level = player1;
        Player player3 = 12;

        Console.WriteLine("-----------------转型操作符重载-----------------");
        Console.WriteLine(level);
        Console.WriteLine(player3);
    }
}

public class Player
{
    public int Level { get; set; }
    public string Name { get; set; }

    public override string ToString()
    {
        return $"Level:{Level},Name:{Name}";
    }
    // 重写Equals
    public override bool Equals(object? obj)
    {
        if (obj is null || obj is not Player)
        {
            return false;
        }
        else
        {
            return ((Player) obj).Name.Equals(Name) && ((Player) obj).Level.Equals(Level);
        }
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name.GetHashCode(), Level.GetHashCode());
    }
    // 重载运算符
    public static bool operator ==(Player? player1, Player? player2)
    {
        if (player1 is null)
        {
            return player2 is null;
        }

        return player1.Equals(player2);
    }
    
    public static bool operator !=(Player player1, Player player2)
    {
        return !(player1 == player2);
    }

    public static Player operator +(Player player1, Player player2)
    {
        Player player = new Player();
        player.Level = player1.Level + player2.Level;
        player.Name = player1.Name + " " + player2.Name;
        return player;
    }
    // 重载转型操作符
    public static implicit operator int(Player player)
    {
        return player.Level;
    }

    public static implicit operator Player(int level)
    {
        Player player = new Player();
        player.Level = level;
        return player;
    }
}