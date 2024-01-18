const express=require('express');
const mysql=require('mysql');
const bodyparser=require('body-parser');
const cors=require('cors');


const app=express();
app.use(express.json());
app.use(bodyparser.urlencoded({extended:true}));
app.use(cors());


const db=mysql.createPool({
    host:'localhost',
    user:"root",
    password:'root',
    database:'productstore'
});


app.get('/',(req,res)=>{
    res.send("Welcome to the API");
})

app.get('/products',(req,res)=>{
    const sql="SELECT * FROM products";
    db.query(sql,(err,data)=>{
        if(!err) {
            console.log("products clicked");
            res.send(data);
        }
        else{
            throw(err);
        }
    })
})

app.get('/products/:id',(req,res)=>{
    const id = req.params.id;
    const sql='SELECT * FROM products WHERE ID=?';
    db.query(sql,[id],(err,data)=> {
        if (!err){
            res.send(data);
            console.log("data of id= "+id);
        }else{
            throw(err);
        }
    
})
})


app.get('/products/delete/:id',(req,res)=>{
    const id=req.params.id;
    const sql="delete from products where id=?";
    db.query(sql,[id],(err,data)=>{
        if(!err){
            res.send(data);
        }
        else{
            throw(err);
        }
    })
})
//post request for adding new product
app.post("/products/add",(req,res)=>{
    const name=req.body.name;
    const description=req.body.description;
    const sql="insert into products(name,description)values(?,?)";
    const params=[];
    if(req.body.name!=null && req.body.description!=null){
        console.log(req.body.name)
        db.query(sql,[name,description],(err,data)=>{
            if(!err){
                res.send(data);
            }
            else{
                throw(err);
            }
        })
    }
    else{
        res.send({"message":"please fill all fields!"});
    }
})



app.listen(4000,()=>{
console.log("app running on 4000")
});