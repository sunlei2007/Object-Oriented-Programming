VendingMachine vendingMachin = new VendingMachine(1000);
vendingMachin.StockFloat(20,10);
vendingMachin.StockFloat(10, 10);
vendingMachin.StockFloat(5, 10);
vendingMachin.StockFloat(2, 10);
vendingMachin.StockFloat(1, 10);

vendingMachin.StockItem(new Product("Egg", 10, "A10"),10);
vendingMachin.StockItem(new Product("Pock", 15, "A11"), 10);
vendingMachin.StockItem(new Product("Bread", 6, "A12"), 10);
vendingMachin.StockItem(new Product("Milk", 12, "A13"), 10);

Console.WriteLine(vendingMachin.VendItem("A10",23));
class VendingMachine
{
    public int SerialNumber { get; set; }
    public Dictionary<int, int> MoneyFloat { get; set; }
    public Dictionary<Product, int> Inventory { get; set; }

    private Dictionary<int, int> backCoinResult;

    public VendingMachine(int serialNumber)
    {
        SerialNumber = serialNumber;
        MoneyFloat = new Dictionary<int, int>();
        Inventory = new Dictionary<Product, int>();
    }
    public string StockItem(Product product, int quantity)
    {
        Inventory.Add(product, 10);
        return $"Added product name:{product.Name} price:{product.Price} quantity:{quantity}";
    }
    public string StockFloat(int moneyDenomination, int quantity)
    {
        MoneyFloat.Add(moneyDenomination,quantity);
        return $"Added money ${moneyDenomination} quatity:{quantity}";
    }
    public string VendItem(string code, int money)
    {
        bool isExistItem = false;
        bool isOutOfStock = false;
        bool isSufficentMoney = false;
        Product? product=null;
        foreach (var dic in Inventory)
        {
            if (dic.Key.Code == code)
            {
                isExistItem = true;
                product = dic.Key;

                if ( dic.Value == 0)
                {
                    isOutOfStock = true;
                }
                if (  dic.Key.Price <= money)
                {
                    isSufficentMoney = true;
                }
                break;
            }
            
        }
        if (!isExistItem)
        {
            return $"Error, no item with code {code} !";
        }

        if (isOutOfStock){
            return $"Error, Item is out of stock!";
        }

        if (!isSufficentMoney)
        {
            return $"Error, insufficient money provided!";
        }

        //change product quantity
        Inventory[product] = Inventory[product] - 1;

        //change MoneyFloat quatity
        backCoinResult = new Dictionary<int, int>();
        ComputeCoinCount(money-product.Price);
        foreach(var dic in backCoinResult)
        {
            if (dic.Value != 0)
            {
                MoneyFloat[dic.Key] = MoneyFloat[dic.Key] - dic.Value;
            }
        }

        return $"Please enjoy your ‘{product.Name}’ and take your change of ${product.Price}!";

    }
    private void ComputeCoinCount(int backAmount)
    {
        int coinCount;

        foreach (var temp in MoneyFloat)
        {
            if (!backCoinResult.ContainsKey(temp.Key))
            {
                coinCount = backAmount / temp.Key;
                int coinMod = backAmount % temp.Key;

               
                backCoinResult.Add(temp.Key, coinCount);
                if (coinMod == 0)
                {
                    break;
                }
                if (coinMod > 0)
                {
                    ComputeCoinCount(coinMod);
                    break;
                 
                }
                 
            }

        }


    }
}

public class Product
{
    public string Name { get; set; }
    public int Price { get; set; }
    public string Code { get; set; }

    public Product(string name,int price,string code)
    {
        Name = name;
        Price = price;
        Code = code;
    }
}