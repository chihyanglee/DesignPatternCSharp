# Simple Factory (Factory) Design Pattern #

---

> "A factory is an object which is used for creating other objects".
Gan of Four

In the Simple Factory Design Pattern, we create an object without exposing the creation logic to the client and the client will refer to the newly created object using a common interface.

In simple words, if we have a superclass and n number of subclasses, and based on the data provided, if we have to create and return the object of one of the subclasses, then we need to use the factory design pattern.

The basic principle behind the factory design pattern is that, at run time, we get an object of similar type based on the parameter we pass.

將客戶端建立同一系列物件的邏輯抽出為Factory Method

以下列一系列信用卡class為例

``` C#

    interface CreditCard
    {
        string GetCardType();
        int GetCreditLimit();
        int GetAnnualCharge();
    }

    class MoneyBack: CreditCard
    {
        public string GetCardType()
        {
            return "Money Back Card";
        }

        public int GetCreditLimit()
        {
            return 15000;
        }

        public int GetAnnualCharge()
        {
            return 500;
        }
    }

    class Titanium : CreditCard
    {
        public string GetCardType()
        {
            return "Titanium Edge";
        }
        public int GetCreditLimit()
        {
            return 25000;
        }
        public int GetAnnualCharge()
        {
            return 1500;
        }
    }

    class Platinum : CreditCard
    {
        public string GetCardType()
        {
            return "Platinum Plus";
        }
        public int GetCreditLimit()
        {
            return 35000;
        }
        public int GetAnnualCharge()
        {
            return 2000;
        }
    }

```

在使用Simple Factory Design Pattern煎的客戶端程式碼如下

``` C#

static void Main(string[] args)
{
    string cardType = "MoneyBack";

    CreditCard cardDetail = null;

    if (cardType == "MoneyBack")
    {
        cardDetail = new MoneyBack();
    }
    else if (cardType == "Titanium")
    {
        cardDetails = new Titanum();
    }
    else if (cardType == "Platinum")
    {
        cardDetails = new Platinum();
    }
}
```

使用Simple Factory Method將建立物件邏輯抽離

``` C#
class CreditCardFactory
{
    public static CreditCard GetCreditCard(string cardType)
    {
        CreditCard cardDetails = null;

        if (cardType == "Money")
        {
            cardDetails = new MoneyBack();
        }
        else if (cardType == "Titanium")
        {
            cardDetails = new Titanium();
        }
        else if (cardType == "Platinum")
        {
            cardDetails = new Platinum();
        }
        return cardDetails;
    }

}
```
