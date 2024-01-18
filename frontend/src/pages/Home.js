import React,{useState,useEffect} from "react";
import axios from 'axios';
import { Link } from "react-router-dom";


const Home = () => {
  const [data,setData]=useState([]);
  const loadData=async()=>{
    const response=await axios.get("http://localhost:4000/products");
    setData(response.data);
  };
  useEffect(()=>{
    loadData();
  },[]);
    return (
    <div className="container-sm" style={{marginTop:"150px"}}>
         
        <Link to={"/addproduct"}>
        <button className="btn btn-primary">Add product</button>
        </Link>
        <table className="table table-light" >
          <thead>
            <tr>
                <th>id</th>
                <th>name</th>
                <th>description</th>
                <th></th>
            </tr>
          </thead>
          <tbody>
            {
                data.map((item,index)=>{
                    return(
                        <tr>
                            <td>{item.id}</td>
                            <td>{item.name}</td>
                            <td>{item.description}</td>
                            <td></td>
                            <td>
                                <Link to={"/update/${item.id}"}>
                                <button className="btn btn-primary">view</button>
                                </Link>
                                <Link to={"/update/${item.id}"}>
                                <button className="btn btn-secondary">update</button>
                                </Link>
                                <Link to={"/update/${item.id}"}>
                                <button className="btn btn-danger">delete</button>
                                </Link>
                            </td>
                        </tr>
                    )
                })
            }

          </tbody>


        </table>
        
    </div>
  )
}

export default Home