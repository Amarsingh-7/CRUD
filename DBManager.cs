using BOL;
using MySql.Data.MySqlClient;

public class DBManager

{
    public DBManager(){

    }

    public List<Employee> GetAll(){
        // Employee emp=new Employee();
        List<Employee>employees=new List<Employee>();
        
        MySqlConnection con=new MySqlConnection();
        con.ConnectionString=@"server=localhost;port=3306;user=root;password=root;database=transflower";
        MySqlCommand cmd=new MySqlCommand();
        cmd.Connection=con;
        cmd.CommandText="select * from employees";

        try{
            con.Open();
            MySqlDataReader reader=cmd.ExecuteReader();
            while(reader.Read()){
                int id= int.Parse(reader["id"].ToString());
                string?  firstName= reader["firstName"].ToString();
                string?  lastName= reader["lastName"].ToString();
                string?  email= reader["email"].ToString();
                string?  address= reader["address"].ToString();
                Employee emp=new Employee();
                emp.Id=id;
                emp.Firstname=firstName;
                emp.Lastname=lastName;
                emp.Address=address;
                emp.Email=email;
                employees.Add(emp);
            }
            reader.Close();
        }catch(Exception e){
            Console.WriteLine(e.Message);


        }finally{
            con.Close();
        }
        return employees;

    }

    public  Employee GetById(int id){

        Console.WriteLine(" Getting Employee Details");
        

        Employee  employee=new Employee();
        MySqlConnection con=new MySqlConnection();
        con.ConnectionString=@"server=localhost; port=3306; user=root; password=root; database=transflower";
        MySqlCommand cmd=new MySqlCommand();
        cmd.Connection=con;
        cmd.CommandText="SELECT * from employees WHERE id="+ id;
        try{
            con.Open();
            MySqlDataReader reader=cmd.ExecuteReader();
            if(reader.Read()){
                int empId= int.Parse(reader["id"].ToString());
                string?  firstName= reader["firstName"].ToString();
                string?  lastName= reader["lastName"].ToString();
                string?  email= reader["email"].ToString();
                string?  address= reader["address"].ToString();
                employee.Id=empId;
                employee.FirstName=firstName;
                employee.Lastname=lastName;
                employee.Address=address;
                employee.Email=email;
               
            } 
            reader.Close();
        }
        catch(Exception e){
            
        }
        finally{
            con.Close();
        }
        return employee;
    }


 public void DeleteById(int id){
        MySqlConnection con=new MySqlConnection();
        con.ConnectionString=@"server=localhost; port=3306; user=root; password=root; database=transflower";
        MySqlCommand cmd=new MySqlCommand();
        cmd.Connection=con;
        cmd.CommandText="delete from employees where id="+id;

         try{
            con.Open();
            cmd.ExecuteNonQuery();
         }
        
        catch(Exception e){
            Console.WriteLine(e.Message);
        }
        finally{
            con.Close();
        }
    }

public void insert(Employee emp){
     MySqlConnection con=new MySqlConnection();
        con.ConnectionString=@"server=localhost; port=3306; user=root; password=root; database=transflower";
        MySqlCommand cmd=new MySqlCommand();
        cmd.Connection=con;
        cmd.CommandText="insert into employees values("+emp.Id+",'"+emp.FirstName+"','"+emp.Lastname+"','"+emp.Email+"','"+emp.Address+"')";

    
         try{
            con.Open();
            cmd.ExecuteNonQuery();
         }
        
        catch(Exception e){
            Console.WriteLine(e.Message);
        }
        finally{
            con.Close();
        }
    
}


 public void update(Employee emp) 
    {
         MySqlConnection con=new MySqlConnection();
        con.ConnectionString=@"server=localhost; port=3306; user=root; password=root; database=transflower";
        MySqlCommand cmd=new MySqlCommand();
        cmd.Connection=con;
        cmd.CommandText="update employees set firstName='"+emp.FirstName+"',lastName='"+emp.Lastname+"',email='"+emp.Email+"',address='"+emp.Address+"' where id="+emp.Id+"";

         try{
            con.Open();
            cmd.ExecuteNonQuery();
         }
        
        catch(Exception e){
            Console.WriteLine(e.Message);
        }
        finally{
            con.Close();
        }
        
    }


}
