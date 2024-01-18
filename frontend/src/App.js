import{BrowserRouter,Routes,Route} from 'react-router-dom';
import Home from "./pages/Home";
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import Addprod from './pages/Addprod';
// import 'bootstrap/dist/js/bootstrap.bundle.min';

function App() {
  return (
    <div className="App">
     <BrowserRouter>
     <Routes>
      <Route path='/' element={<Home />}/>
      <Route path='/addproduct/' element={<Addprod/>}/>
     </Routes>
     </BrowserRouter>
    </div>
  );
}

export default App;
