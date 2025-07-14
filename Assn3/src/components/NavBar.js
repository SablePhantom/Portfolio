import React from "react";
import { Link } from "react-router-dom";
import "./NavBarStyle.css";


const NavBar = () => {
  return (
    <>
      <nav>
        <div className="menuitem">
          <Link to="/home">Pet Heaven</Link>
          <Link to="/about">About</Link>
          <Link to="/faq">FAQ</Link>
          <Link to="/funcat">Cats</Link>
          <Link to="/fundog">Dogs</Link>
          <Link to="/adopt">Adopt</Link>
          <Link to="/release">Release</Link>
          <Link to="/login">Login</Link>
        </div>
      </nav>
      <footer>
        <p>&copy; 2023 Pet Heaven. All rights reserved</p>
      </footer> 
    </>
  );
};

export default NavBar;
