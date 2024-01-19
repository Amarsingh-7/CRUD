namespace BOL;
[Serializable]
public class Employee
{
    public Employee(){

    }

    public int Id{get;set;}
    public String Firstname{get;set;}
    public string? FirstName { get; internal set; }
    public String Lastname{get;set;}
    public String Email{get;set;}
    public String Address{get;set;}


    public override string ToString()
    {
        return Id+" "+Firstname+" "+Lastname+" "+Email+" "+Address;
    }


}
