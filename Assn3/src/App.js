import NavBar from "./components/NavBar";
import "./styles.css";
import Dogs from "./components/Dogs";
import Cats from "./components/Cats";
import About from "./components/About";
import Home from "./components/Home";
import AdoptForm from "./components/AdoptForm";
import Register from "./components/Register";
import Login from "./components/Login";
import ReleaseForm from "./components/ReleaseForm";

import { BrowserRouter as Router, Route, Routes } from "react-router-dom";

NavBar
function App() {
  return (
    <>
      <Router>
        <NavBar />
        
        <div className="container">
          <Routes>
            <Route path="/home" exact element={<Home />} />
            <Route path="/about" element={<About />} />
            <Route path="/faq" element={<FAQ />} />
            <Route path="/funcat" element={<Cats />} />
            <Route path="/fundog" element={<Dogs />} />
            <Route path="/adopt" element={<AdoptForm />} />
            <Route path="/release" element={<ReleaseForm />} />
            <Route path="/register" element={<Register />} />
            <Route path="/login" element={<Login />} />
          </Routes>
        </div>
        <div
        style={{
          backgroundColor: 'darkblue',
          width: '100px',
          height: '100px'
        }}
    />
      </Router>
    </>
  );
}

export default App;
