using BOL;
using Microsoft.AspNetCore.Mvc;

public class EmployeeController:Controller{

    private DBManager mgr=new DBManager();

    public IActionResult getall(){
        
        List<Employee> employees= mgr.GetAll();
        employees.ForEach((e)=>{
            Console.WriteLine(e);
        });
        return View(employees);
    }

     public IActionResult Register()
    {
        return View();
    }


    [HttpPost]
    public IActionResult Register(IFormCollection form)
    {
        //This is one way
        /* string id=this.HttpContext.Request.Form["Id"] ;
        string name=HttpContext.Request.Form["Name"];
        */
        //This is another way
        Console.WriteLine("inside register");
        Console.WriteLine(form["FirstName"].ToString());
        var id = int.Parse(form["Id"].ToString());
        var firstName = form["FirstName"].ToString();
        var lastName=form["LastName"].ToString();
        var email=form["Email"].ToString();
        var address=form["Address"].ToString();
        Employee emp=new Employee();
        emp.Id=id;
        emp.FirstName=firstName;
        emp.Lastname=lastName;
        emp.Email=email;
        emp.Address=address;
        Console.WriteLine(emp);
        mgr.insert(emp);
        
       return RedirectToAction("getall","Employee",null);

    }


     public IActionResult Delete(int id){
        mgr.DeleteById(id);
        Console.WriteLine("after calling delete");
         List<Employee> employees=mgr.GetAll();
        return RedirectToAction("getall","Employee",null);
    }
        
 public IActionResult Edit(int id){
         List<Employee> employees=mgr.GetAll();
        //  Employee emp=_svc.Updatebyid();
         var e= employees.Find((emp)=>emp.Id==id);    
        return View(e);
     }


[HttpPost]
    public IActionResult Edit(IFormCollection form){  

        var id = int.Parse(form["Id"].ToString());
        var firstName = form["fName"].ToString();
        var lastName=form["lName"].ToString();
        var email=form["email"].ToString();
        var address=form["ddress"].ToString();
        Employee emp=new Employee();
        emp.Id=id;
        emp.FirstName=firstName;
        emp.Lastname=lastName;
        emp.Email=email;
        emp.Address=address;
        Console.WriteLine(emp);
        mgr.update(emp); 

         return RedirectToAction("getall","Employee",null);


}
}